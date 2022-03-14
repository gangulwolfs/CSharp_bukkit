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
		
		public EntityPlayer Player { get; internal set; }

        private int _teleportAwait;


        private readonly NetworkBuf _networkBuf = new();

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
            _networkBuf.Clear();
            
            //TODO: 압축 추가

            if (Decryptor != null)
            {
                var data = packet;
                packet = new byte[data.Length];
                Decryptor.TransformBlock(data, 0, data.Length, packet, 0);
            }

            var buf = new ByteBuf(packet);
            var packetId = buf.ReadVarInt();
            PacketFactory.Handle(this, buf, packetId);
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
            
            ((EntityPlayer) Player).IsOnGround = onGround;
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

            string format = ChatSettings.ChatFormat(Player, message);
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
                SelfCryptography.PublicKeyToAsn1(Bukkit.MinecraftServer.ServerKey),
                _verifyToken = SelfCryptography.GetRandomToken()));
        }

        internal async void EncryptionResponse(byte[] sharedKey, IEnumerable<byte> packetToken)
        {
            if (!packetToken.SequenceEqual(_verifyToken))
            {
                Bukkit.ConsoleSender.SendWarnMessage($"{Host}:{Port} Wrong token");
                return;
            }
            
            var recv = SelfCryptography.GenerateAes((byte[]) sharedKey.Clone());
            var cipher = SelfCryptography.GenerateAes((byte[]) sharedKey.Clone());

            Decryptor = recv.CreateDecryptor();
            Encryptor = cipher.CreateEncryptor();

            if (await Player.IsAuthenticate(sharedKey))
            {
                Bukkit.ConsoleSender.SendMessage($"§eUser {Player.Name} authenticated with UUID {Player.Uuid}");
                Play();
            }
            else
            {
                Bukkit.ConsoleSender.SendWarnMessage($"§eUser {Player.Name} authentication failed!");
                Kick("Authentication failed! Try restarting your client.");
            }
        }

        internal void Play()
        {
            SendPacket(new LoginOutSetCompression(ServerSettings.UseCompression
                ? ServerSettings.CompressionThreshold
                : -1));
            SendPacket(new LoginOutSuccess(Player.Profile));
				
            PacketMode = PacketMode.Play;
            // SendPacket(new PlayOutJoinGame(Player));
            // SendPacket(new PlayOutServerDifficulty(Player.World.Difficulty));
            // SendPacket(new PlayOutPlayerAbilities(Player.PlayerAbilities));
            // SendPacket(new PlayOutHeldItemSlot(Player.HeldItemSlot));
            // SendPacket(new PlayOutEntityStatus(Player.EntityId, 9));
				
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

        internal void InitPlayer()
        {
            //TODO: removeSpawnPlayer
            Packet playerInfo = new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, (EntityPlayer) Player);
            Packet spawnPlayer = new PlayOutSpawnPlayer(Player);
            
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

        public Task SendPacket(Packet packet)
        {
            if (_client is not {Connected: true}) return Task.CompletedTask;
            var buf = new ByteBuf();
            packet.Write(buf, Protocol);
            
            // var data = buf.Flush();
            try
            {
                if (Encryptor != null)
                {
                    var data = buf.GetBytes();
                    data = Encryptor.TransformFinalBlock(data, 0, data.Length);
                    // using var ms = new MemoryStream();
                    // using var cs = new CryptoStream(ms, Encryptor, CryptoStreamMode.Write);
                    // cs.Write(data, 0, data.Length);
                    // cs.FlushFinalBlock();

                    // data = ms.ToArray();

                    // data = Encryptor.TransformFinalBlock(data, 0, data.Length);
                    // Encryptor.TransformBlock(toEncrypt, 0, toEncrypt.Length, data, 0);

                    var stream = _client.GetStream();
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
                else
                {
                    _client.Client.Send(buf.Flush(), SocketFlags.None);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                if (e is SocketException socketException)
                {
                    if (socketException.ErrorCode != 10053 && socketException.SocketErrorCode != SocketError.Disconnecting && _client is {Connected: true})
                    {
                        Kick(e.Message);
                    }
                }//else
                 //   Kick(e.Message);
                
                Disconnect();
            }
            
            return Task.CompletedTask;
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