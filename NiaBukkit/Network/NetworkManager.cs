using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using NiaBukkit.API;
using NiaBukkit.API.Compress;
using NiaBukkit.API.Config;
using NiaBukkit.API.Cryptography;
using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;
using NiaBukkit.Minecraft;
using NiaBukkit.Network.Protocol;
using NiaBukkit.Network.Protocol.Login;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.Network
{
    public class NetworkManager
    {
        private const int Timeout = 25000;
        private const long KeepAliveTime = 50;

        private long _lastPacketMillis = TimeManager.CurrentTimeMillis;
        private readonly TcpClient _client;

        public bool IsAvailable { get; private set; }

        public bool CompressionEnabled { get; private set; }

        public PacketMode PacketMode { get; internal set; } = PacketMode.Ping;
        public ProtocolVersion Protocol { get; internal set; }
        public string Host { get; internal set; }
        public short Port { get; internal set; }

        private byte[] _verifyToken;
        
        public string Name { get; internal set; }
		
		public EntityPlayer Player { get; private set; }

        private int _teleportAwait;

        private Stream _sendStream;
        private NetworkBuf _receiveStream;

        private event Action<byte[]> _sendEventHandler;

        internal NetworkManager(TcpClient client)
        {
            IsAvailable = true;
            _sendEventHandler += OnSendEvent;

            client.NoDelay = true;
            
            _client = client;
            _sendStream = _client.GetStream();
            _receiveStream = new NetworkBuf();

            var so = new StateObject(_client.Client);
            so.TargetSocket.BeginReceive(so.Buffer, 0, StateObject.BufferSize, SocketFlags.None, ReceiveAsync, so);
        }

        private void Disconnect()
        {
            IsAvailable = false;
            // TODO: Client Disconnected
        }

        internal void Close()
        {
            if (IsAvailable)
            {
                Disconnect();
            }

            try
            {
                _client.Close();
                _client.Dispose();
                _sendStream.Dispose();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
            if (Player != null)
                Bukkit.RemovePlayer(Player);
        }

        private void ReceiveAsync(IAsyncResult rs)
        {
            var so = (StateObject) rs.AsyncState;
            try
            {
                var read = so!.TargetSocket.EndReceive(rs);
                if (read > 0)
                {
                    _lastPacketMillis = TimeManager.CurrentTimeMillis;
                    
                    _receiveStream.Read(so.Buffer, read);

                    var result = _receiveStream.ReadPacket();
                    while (result != null)
                    {
                        PacketHandle(result);
                        result = _receiveStream.ReadPacket();
                    }

                    so.TargetSocket.BeginReceive(so.Buffer, 0, StateObject.BufferSize, 0, ReceiveAsync, so);
                }

                else
                    Disconnect();
            }
            catch (Exception e)
            {
                SocketExceptionCheck(e);
            }
        }
        
        private void PacketHandle(byte[] packet)
        {
            if (CompressionEnabled)
                packet = Decompress(packet);

            var buf = new ByteBuf(packet);
            var packetId = buf.ReadVarInt();
            PacketFactory.Handle(this, buf, packetId);
            /*if(packetId != 11 && packetId != 13 && packetId != 15 && packetId != 14)
                Bukkit.ConsoleSender.SendMessage(packetId);*/
        }

        internal void Update()
        {
            if (TimeoutUpdate()) return;
            KeepAliveUpdate();
        }

        private bool TimeoutUpdate()
        {
            if (_client.Connected && TimeManager.CurrentTimeMillis - _lastPacketMillis <= Timeout) return false;
            Disconnect();
            return true;
        }

        private void KeepAliveUpdate()
        {
            if (Player == null || PacketMode != PacketMode.Play || TimeManager.CurrentTimeMillis - _lastPacketMillis < KeepAliveTime) return;
            SendPacket(new PlayOutKeepAlive(TimeManager.CurrentTimeMillis));
        }

        private int TeleportAwaitUpdate()
        {
            if (++_teleportAwait == int.MaxValue)
                _teleportAwait = 0;

            return _teleportAwait;
        }

        private Location GetFlagLocation(ICloneable loc, ICollection<TeleportFlags> flagsList)
        {
            var pos = (Location) loc.Clone();

            if (flagsList.Contains(TeleportFlags.X))
                pos.X += Player.Location.X;
            if (flagsList.Contains(TeleportFlags.Y))
                pos.Y += Player.Location.Y;
            if (flagsList.Contains(TeleportFlags.Z))
                pos.Z += Player.Location.Z;
            
            if (flagsList.Contains(TeleportFlags.YRot))
                pos.Yaw += Player.Location.Yaw;
            if (flagsList.Contains(TeleportFlags.XRot))
                pos.Pitch += Player.Location.Pitch;

            return pos;
        }

        internal void SetPosition(Location loc, IEnumerable<TeleportFlags> flags)
        {
            var flagsList = flags.ToList();
            SendPacket(new PlayOutPosition(loc.X, loc.Y, loc.Z, loc.Yaw, loc.Pitch, flagsList, TeleportAwaitUpdate()));
            Player.Location = GetFlagLocation(loc, flagsList);
        }

        internal void LookUpdate(float yaw, float pitch, bool onGround)
        {
            Player.Location.Yaw = yaw;
            Player.Location.Pitch = pitch;
            
            Player.IsOnGround = onGround;
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityLook(Player.EntityId, yaw, pitch, onGround), false);
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityHeadRotation(Player.EntityId, yaw), false);
        }

        internal void Move(double x, double y, double z, float yaw, float pitch, bool onGround) =>
            Move(new Location(Player.World, x, y, z, yaw, pitch), onGround);

        private void Move(Location loc, bool onGround)
        {
            Player.Location = (Location) loc.Clone();
            
            Player.IsOnGround = onGround;
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityTeleport(Player.EntityId, loc.X, loc.Y, loc.Z, loc.Yaw, loc.Pitch, onGround), false);
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityHeadRotation(Player.EntityId, loc.Yaw), false);
        }

        internal void Teleport(double x, double y, double z, float yaw, float pitch, IEnumerable<TeleportFlags> flags) =>
            Teleport(new Location(Player.World, x, y, z, yaw, pitch), flags);

        internal void Teleport(Location loc, IEnumerable<TeleportFlags> flags)
        {
            //TODO: Teleport Event
            loc = GetFlagLocation(loc, flags.ToList());
            SetPosition(loc, Enumerable.Empty<TeleportFlags>());
        }

        internal void MessageReceived(string message)
        {
            if (message.StartsWith(ChatSettings.CommandPrefix))
            {
                //TODO: Command
                return;
            }

            var format = ChatSettings.ChatFormat(Player, message);
            Bukkit.BroadcastMessage(Player.Uuid, format);
        }

        public void Kick(string reason)
        {
            IPacket packet = PacketMode == PacketMode.Login
                ? new LoginOutDisconnect(reason)
                : new PlayOutDisconnect(reason);
            
            SendPacket(packet);
            Disconnect();
        }

        internal void Encryption()
        {
            SendPacket(new LoginOutEncryptionRequest(MinecraftServer.ServerId,
                Bukkit.MinecraftServer.Cryptography.PublicKey,
                _verifyToken = SelfCryptography.GetRandomToken()));
        }

        internal async void EncryptionResponse(byte[] sharedKey, IEnumerable<byte> packetToken)
        {
            if (!packetToken.SequenceEqual(_verifyToken))
            {
                Bukkit.ConsoleSender.SendWarnMessage($"{Host}:{Port} Wrong token");
                return;
            }

            _sendStream = new AesStream(new AesCipher(sharedKey, sharedKey), _sendStream);
            _receiveStream = new CryptoNetworkBuf(new AesCipher(sharedKey, sharedKey));
            
            var (key, value) = await MojangAuth.IsAuthenticate(this, sharedKey);
            if(key)
            {
                var profile = new GameProfile(new Uuid(value.Get<string>("id")), value.Get<string>("name"));
                if (!InitEntityPlayer(profile, value.Get<object[]>("properties")))
                    return;

                Bukkit.ConsoleSender.SendMessage($"§eUser {profile.Name} authenticated with UUID {value.Get<string>("id")}");
                Play();
            }
            else
            {
                Bukkit.ConsoleSender.SendWarnMessage($"§4User {Name} authentication failed!");
                Kick("Authentication failed! Try restarting your client.");
            }
        }

        internal bool InitEntityPlayer(GameProfile profile, object[] properties = null)
        {
            if (Bukkit.Players.ContainsKey(profile.Uuid))
            {
                Kick("Player Already Connected.");
                return false;
            }
            
            Player = new EntityPlayer(this, profile, Bukkit.MainWorld, ServerProperties.GameMode, properties);
            return true;
        }

        internal void Play()
        {
            if(ServerSettings.UseCompression)
            {
                SendPacket(new LoginOutSetCompression(ServerSettings.CompressionThreshold));
                CompressionEnabled = true;
            }else
                SendPacket(new LoginOutSetCompression(-1));


            SendPacket(new LoginOutSuccess(Player.Profile));
				        
            PacketMode = PacketMode.Play;
            SendPacket(new PlayOutJoinGame(Player));
            SendPacket(new PlayOutServerDifficulty(Player.World.Difficulty));
            SendPacket(new PlayOutPlayerAbilities(Player.PlayerAbilities));
            SendPacket(new PlayOutHeldItemSlot(Player.HeldItemSlot));
            SendPacket(new PlayOutEntityStatus(Player.EntityId, 9));
				
            //TODO: PacketPlayOutRecipes
            //TODO: PacketPlayOutSetSlot 

            if (!IsAvailable) return;
            
            Bukkit.AddPlayer(Player);
            InitPlayer();
				
            //TODO: PacketPlayOutEntityMetadata
            //
            //
            SetPosition(Player.Location, Enumerable.Empty<TeleportFlags>());
            SendPacket(new PlayOutSpawnPosition(Player.Location));
        }

        private void InitPlayer()
        {
            //TODO: removeSpawnPlayer
            var playerInfo = new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, Player);
            var spawnPlayer = new PlayOutSpawnPlayer(Player);
            
            SendPacket(playerInfo);
            foreach (var onlinePlayer in Bukkit.OnlinePlayers)
            {
                var player = (EntityPlayer) onlinePlayer;
                if(player == Player) continue;
                if (player.CanSee(Player))
                {
                    player.NetworkManager.SendPacket(playerInfo);
                    player.NetworkManager.SendPacket(spawnPlayer);
                }

                if (!Player.CanSee(player)) continue;
                SendPacket(
                    new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, player));
                SendPacket(new PlayOutSpawnPlayer(player));
            }
        }

        private static byte[] Decompress(byte[] buf)
        {
            var result = new ByteBuf(buf);
            var length = result.ReadVarInt();

            var compressed = result.Read(result.Length);
            if (length == 0)
                return compressed;

            return ByteCompress.ZLipDecompress(compressed);
        }


        private static byte[] Compress(ByteBuf buf)
        {
            var result = new ByteBuf();
            if(buf.WriteLength >= ServerSettings.CompressionThreshold)
            {
                var compressed = ByteCompress.ZLipCompress(buf.GetBytes());
                result.WriteVarInt(buf.WriteLength);
                result.Write(compressed);
            }else
            {
                result.WriteVarInt(0);
                result.Write(buf.GetBytes());
            }

            return result.Flush();
        }

        private void OnSendEvent(byte[] data)
        {
            try
            {
                _sendStream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                SocketExceptionCheck(e);
                Disconnect();
            }
        }

        public void SendPacket(IPacket packet)
        {
            if (_client is not {Connected: true}) return;
            
            var buf = new ByteBuf();
            packet.Write(buf, Protocol);

            _sendEventHandler?.Invoke(CompressionEnabled ? Compress(buf) : buf.Flush());
        }

        private void SocketExceptionCheck(Exception e)
        {
            while (true)
            {
                if (e.InnerException != null)
                {
                    e = e.InnerException;
                    continue;
                }

                if (_client is not {Connected: true}) return;
                if (e is SocketException exception)
                {
                    if (exception.ErrorCode == 10053 || exception.SocketErrorCode == SocketError.Disconnecting || _client is not {Connected: true}) return;

                    Kick(e.Message);
                    Console.Error.WriteLine(e);
                }
                else if (e is not InvalidOperationException && e is not NullReferenceException && e is not ObjectDisposedException)
                {
                    Kick(e.Message);
                    Console.Error.WriteLine(e);
                }

                break;
            }
        }

        private class StateObject : IDisposable
        {
            public const int BufferSize = 1024;
            public readonly byte[] Buffer = new byte[BufferSize];
            public Socket TargetSocket { get; }

            public StateObject(Socket socket)
            {
                TargetSocket = socket;
            }

            public void Dispose()
            {
                try
                {
                    TargetSocket?.Dispose();
                }catch(Exception) { }
            }
        }
    }
}