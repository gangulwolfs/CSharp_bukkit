using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;
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

        public PacketMode PacketMode { get; internal set; } = PacketMode.Ping;
        public ProtocolVersion Protocol { get; internal set; }
        public string Host { get; internal set; }
        public short Port { get; internal set; }

        private byte[] _verifyToken;

        internal ICryptoTransform Encryptor;
        internal ICryptoTransform Decryptor;
        
        public string Name { get; internal set; }
		
		public EntityPlayer Player { get; private set; }

        private int _teleportAwait;


        private readonly NetworkBuf _networkBuf = new();

        private readonly object _packetLockObject = new();

        internal NetworkManager(TcpClient client)
        {
            IsAvailable = true;
            client.NoDelay = true;
            
            _client = client;
        }

        private void Disconnect()
        {
            IsAvailable = false;
            
            // TODO: Client Disconnected
        }

        internal void Close()
        {
            if(IsAvailable)
                Disconnect();

            try
            {
                _client.Close();
                _client.Dispose();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
            if (Player != null)
                Bukkit.RemovePlayer(Player);
        }

        private int GetPacketLength()
        {
            if (!ServerSettings.UseCompression || PacketMode != PacketMode.Play)
                return ByteBuf.ReadVarInt(_client.GetStream());
            
            var packetLength = ByteBuf.ReadVarInt(_client.GetStream());
            var dataLength = ByteBuf.ReadVarInt(_client.GetStream());

            if (dataLength == 0) return packetLength - ByteBuf.GetVarInt(dataLength).Length;
            return dataLength;
        }

        internal void Update()
        {
            if (TimeoutUpdate()) return;
            ReceiveUpdate();
            PacketHandleUpdate();
            KeepAliveUpdate();
        }

        private bool TimeoutUpdate()
        {
            if (_client.Connected && TimeManager.CurrentTimeMillis - _lastPacketMillis <= Timeout) return false;
            Disconnect();
            return true;
        }

        private void ReceiveUpdate()
        {
            if (_client.Available == 0) return;
            
            _lastPacketMillis = TimeManager.CurrentTimeMillis;
            
            _networkBuf.Buf ??= new byte[GetPacketLength()];

            _networkBuf.Offset += _client.GetStream().Read(_networkBuf.Buf, _networkBuf.Offset,
                _networkBuf.Buf.Length - _networkBuf.Offset);
        }

        private void PacketHandleUpdate()
        {
            if(_networkBuf.Buf == null || _networkBuf.Offset != _networkBuf.Buf.Length) return;
            
            var packet = _networkBuf.Buf;
            packet = Decryptor != null ? Decrypt(packet) : packet;
            _networkBuf.Clear();
            
            //TODO: 압축 추가

            var buf = new ByteBuf(packet);
            var packetId = buf.ReadVarInt();
            PacketFactory.Handle(this, buf, packetId);
        }

        private void KeepAliveUpdate()
        {
            if (Player == null || PacketMode != PacketMode.Play || TimeManager.CurrentTimeMillis - _lastPacketMillis < KeepAliveTime) return;
            // SendPacket(new PlayOutKeepAlive(TimeManager.CurrentTimeMillis));
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
            Packet packet = PacketMode == PacketMode.Login
                ? new LoginOutDisconnect(reason)
                : new PlayOutDisconnect(reason);
            
            SendPacket(packet);
            Disconnect();
        }

        internal void Encryption()
        {
            SendPacket(new LoginOutEncryptionRequest(MinecraftServer.ServerId,
                Bukkit.MinecraftServer._cryptography.PublicKey,
                _verifyToken = SelfCryptography.GetRandomToken()));
        }

        internal async void EncryptionResponse(byte[] sharedKey, IEnumerable<byte> packetToken)
        {
            if (!packetToken.SequenceEqual(_verifyToken))
            {
                Bukkit.ConsoleSender.SendWarnMessage($"{Host}:{Port} Wrong token");
                return;
            }
            
            Bukkit.ConsoleSender.SendMessage("§aShared Key: " + string.Join(", ", sharedKey));
            
            using var receive = SelfCryptography.GenerateAes(sharedKey);
            using var send = SelfCryptography.GenerateAes(sharedKey);

            Encryptor = send.CreateEncryptor(sharedKey, sharedKey);
            Decryptor = receive.CreateDecryptor(sharedKey, sharedKey);

            var (key, value) = await EntityPlayer.IsAuthenticate(this, sharedKey);
            if(key)
            {
                var profile = new GameProfile(new Uuid(value.Get<string>("id")),
                    value.Get<string>("name"));
                InitEntityPlayer(profile);
                Bukkit.ConsoleSender.SendMessage($"§eUser {Name} authenticated with UUID {value.Get<string>("id")}");
                Play();
                // Kick("Authentication failed! Try restarting your client.");
            }
            else
            {
                Bukkit.ConsoleSender.SendWarnMessage($"§4User {Player.Name} authentication failed!");
                Kick("Authentication failed! Try restarting your client.");
            }
        }

        internal void InitEntityPlayer(GameProfile profile)
        {
            Player = new EntityPlayer(this, profile, Bukkit.MainWorld, ServerProperties.GameMode);
        }

        internal async void Play()
        {
            await SendPacket(new LoginOutSetCompression(ServerSettings.UseCompression
                ? ServerSettings.CompressionThreshold
                : -1));
            await SendPacket(new LoginOutSuccess(Player.Profile));
				        
            PacketMode = PacketMode.Play;
            await SendPacket(new PlayOutJoinGame(Player));
            await SendPacket(new PlayOutServerDifficulty(Player.World.Difficulty));
            await SendPacket(new PlayOutPlayerAbilities(Player.PlayerAbilities));
            await SendPacket(new PlayOutHeldItemSlot(Player.HeldItemSlot));
            await SendPacket(new PlayOutEntityStatus(Player.EntityId, 9));
				
            //TODO: PacketPlayOutRecipes
            //TODO: PacketPlayOutSetSlot 

            if (!IsAvailable) return;
            
            Bukkit.AddPlayer(Player);
            await InitPlayer();
				
            //TODO: PacketPlayOutEntityMetadata
            //
            //
            SetPosition(Player.Location, Enumerable.Empty<TeleportFlags>());
            await SendPacket(new PlayOutSpawnPosition(Player.Location));
        }

        private async Task InitPlayer()
        {
            //TODO: removeSpawnPlayer
            var playerInfo = new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, Player);
            var spawnPlayer = new PlayOutSpawnPlayer(Player);
            
            await SendPacket(playerInfo);
            foreach (var onlinePlayer in Bukkit.OnlinePlayers)
            {
                var player = (EntityPlayer) onlinePlayer;
                if(player == Player) continue;
                if (player.CanSee(Player))
                {
                    await player.NetworkManager.SendPacket(playerInfo);
                    await player.NetworkManager.SendPacket(spawnPlayer);
                }

                if (!Player.CanSee(player)) continue;
                await SendPacket(
                    new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, player));
                await SendPacket(new PlayOutSpawnPlayer(player));
            }
        }

        private byte[] Encrypt(byte[] data)
        {
            return WriteCrypto(Encryptor, data);
        }

        private byte[] Decrypt(byte[] data)
        {
            return WriteCrypto(Decryptor, data);
        }

        private static byte[] WriteCrypto(ICryptoTransform transform, byte[] data)
        {
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(data);
            // var result = new byte[data.Length];
            // transform.TransformBlock(data, 0, data.Length, result, 0);
            cs.FlushFinalBlock();
            cs.Close();

            // return ms.ToArray();
            return ms.ToArray();
        }

        public Task SendPacket(Packet packet)
        {
            if (_client is not {Connected: true}) return Task.CompletedTask;

            return Task.Run(() =>
            {
                lock (_packetLockObject)
                {
                    var buf = new ByteBuf();
                    packet.Write(buf, Protocol);
                    var data = buf.Flush();
                    try
                    {
                        if (data.Length < 42)
                            Bukkit.ConsoleSender.SendMessage(ChatColor.Blue + "Before Encryption: " +
                                                             string.Join(", ", data));

                        _client.Client.Send(Encryptor != null ? data = Encrypt(data) : data, SocketFlags.None);

                        if (data.Length < 42 && Encryptor != null)
                            Bukkit.ConsoleSender.SendMessage("§6After Encryption: " + string.Join(", ", data));
                    }
                    catch (Exception e)
                    {
                        SocketSendExceptionCheck(e);
                        Disconnect();
                    }
                }
            });
        }

        private void SocketSendExceptionCheck(Exception e)
        {
            if (_client is not {Connected: true}) return;
            if (e is SocketException exception)
            {
                if (exception.ErrorCode == 10053 || exception.SocketErrorCode == SocketError.Disconnecting ||
                    _client is not {Connected: true}) return;
                
                Kick(e.Message);
                Console.Error.WriteLine(e);
            }else if (e is not InvalidOperationException && e is not NullReferenceException)
            {
                Kick(e.Message);
                Console.Error.WriteLine(e);
            }
        }

        private class NetworkBuf
        {
            public byte[] Buf;
            public int Offset;

            public void Clear()
            {
                Buf = null;
                Offset = 0;
            }
        }
    }
}