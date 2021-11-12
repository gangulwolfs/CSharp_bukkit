using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
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
        internal static readonly ConcurrentBag<NetworkManager> NetworkManagers = new ConcurrentBag<NetworkManager>();

        internal long LastPacketMillis = 0;
        internal readonly TcpClient Client;
        
        public bool IsAvailable { get; private set; }

        public PacketMode PacketMode { get; internal set; } = PacketMode.Ping;
        public ProtocolVersion Protocol { get; internal set; }
        public string Host { get; internal set; }
        public short Port { get; internal set; }

        internal ICryptoTransform Encrypter;
        internal ICryptoTransform Decrypter;
		
		public Player Player { get; internal set; }

        private int _teleportAwait = 0;
        
        public const long KeepAliveTime = 50;

        internal NetworkManager(TcpClient client)
        {
            IsAvailable = true;
            
            Client = client;
            LastPacketMillis = TimeManager.CurrentTimeMillis;
            
            NetworkManagers.Add(this);
        }

        internal void Disconnect()
        {
            IsAvailable = false;
            
            NetworkManager manager = this;
            NetworkManagers.Remove(manager);

            if (Player != null)
                Bukkit.RemovePlayer(Player);

            Bukkit.MinecraftServer.AddDestroySocket(this);
            // TODO: Client Disconnected
        }

        private int GetPacketLength()
        {
            if (ServerSettings.UseCompression && PacketMode == PacketMode.Play)
            {
                int packetLength = ByteBuf.ReadVarInt(Client.GetStream());
                int dataLength = ByteBuf.ReadVarInt(Client.GetStream());

                if (dataLength == 0) return packetLength - ByteBuf.GetVarInt(dataLength).Length;
                return dataLength;
            }

            return ByteBuf.ReadVarInt(Client.GetStream());
        }

        internal void Update()
        {
            PacketUpdate();
            KeepAliveUpdate();
        }

        private void PacketUpdate()
        {
            if (Client.Available == 0) return;
            LastPacketMillis = TimeManager.CurrentTimeMillis;
            
            byte[] bytes = new byte[GetPacketLength()];
            Client.GetStream().Read(bytes, 0, bytes.Length);
            //TODO: 압축 추가

            if (Decrypter != null)
            {
                byte[] data = bytes;
                bytes = new byte[data.Length];
                Decrypter.TransformBlock(data, 0, data.Length, bytes, 0);
            }

            ByteBuf buf = new ByteBuf(bytes);
            var packetId = buf.ReadVarInt();
            // Bukkit.ConsoleSender.SendMessage(PacketMode +", " + packetId);
            PacketFactory.Handle(this, buf, packetId);
        }

        private void KeepAliveUpdate()
        {
            if (TimeManager.CurrentTimeMillis - LastPacketMillis < KeepAliveTime || Player == null) return;
            SendPacket(new PlayOutKeepAlive(TimeManager.CurrentTimeMillis));
        }

        private int TeleportAwaitUpdate()
        {
            if (++_teleportAwait == Int32.MaxValue)
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
            List<TeleportFlags> flagsList = flags.ToList();
            SendPacket(new PlayOutPosition(loc.X, loc.Y, loc.Z, loc.Yaw, loc.Pitch, flagsList, TeleportAwaitUpdate()));
            Player.Location = GetFlagLocation(loc, flagsList);
        }

        internal void LookUpdate(float yaw, float pitch, bool onGround)
        {
            Player.Location.Yaw = yaw;
            Player.Location.Pitch = pitch;
            
            ((EntityPlayer) Player).IsOnGround = onGround;
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

        internal void InitPlayer()
        {
            //TODO: removeSpawnPlayer
            Packet playerInfo = new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, (EntityPlayer) Player);
            Packet spawnPlayer = new PlayOutSpawnPlayer(Player);
            
            SendPacket(playerInfo);
            foreach (var onlinePlayer in Bukkit.OnlinePlayers)
            {
                EntityPlayer player = (EntityPlayer) onlinePlayer;
                if(player == Player) continue;
                if (player.CanSee(Player))
                {
                    player.NetworkManager.SendPacket(playerInfo);
                    player.NetworkManager.SendPacket(spawnPlayer);
                }

                if (!((EntityPlayer) Player).CanSee(player)) continue;
                SendPacket(
                    new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, player));
                SendPacket(new PlayOutSpawnPlayer(player));
            }
        }

        public void SendPacket(Packet packet)
        {
            if (Client is not {Connected: true}) return;
            ByteBuf buf = new ByteBuf();
            packet.Write(buf, Protocol);

            byte[] data = buf.Flush();

            try
            {
                if (Encrypter != null)
                {
                    byte[] encrypt = data;
                    data = new byte[encrypt.Length];

                    Encrypter.TransformBlock(encrypt, 0, encrypt.Length, data, 0);

                    NetworkStream stream = Client.GetStream();
                    stream.WriteAsync(data, 0, data.Length);
                    stream.Flush();
                }
                else
                {
                    Client.Client.Send(data);
                }
            }
            catch (SocketException e)
            {
                if (e.ErrorCode != 10053 && e.SocketErrorCode != SocketError.Disconnecting && Client is {Connected: true})
                {
                    Console.Error.WriteLine(e.Message);
                    Kick(e.Message);
                }
                Disconnect();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                if(Client is {Connected: true})
                    try
                    {
                        Kick(e.Message);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                Disconnect();
            }
        }
    }
}