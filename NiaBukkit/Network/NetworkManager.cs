using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Entity;
using NiaBukkit.API.Util;
using NiaBukkit.Network.Protocol;
using NiaBukkit.Network.Protocol.Login;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.Network
{
    public class NetworkManager
    {
        internal static ConcurrentBag<NetworkManager> NetworkManagers = new ConcurrentBag<NetworkManager>();

        internal long LastPacketMillis = 0;
        internal TcpClient Client;
        
        public bool IsAvilable { get; private set; }

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
            IsAvilable = true;
            
            Client = client;
            LastPacketMillis = TimeManager.CurrentTimeMillis;
            
            NetworkManagers.Add(this);
        }

        internal void Disconnect()
        {
            IsAvilable = false;
            
            NetworkManager manager = this;
            NetworkManagers.Remove(manager);

            if (Player != null)
            {
                Player.World.Players.Remove(Player);
                Player player;
                Bukkit.Players.Remove(Player.Uuid, out player);
            }

            Bukkit.minecraftServer.AddDestroySocket(this);
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

        internal void SetPosition(Location loc, IEnumerable<TeleportFlags> flags)
        {
            if (++_teleportAwait == Int32.MaxValue)
                _teleportAwait = 0;
            List<TeleportFlags> flagsList = flags.ToList();
            SendPacket(new PlayOutPosition(loc.X, loc.Y, loc.Z, loc.Yaw, loc.Pitch, flagsList, _teleportAwait));
            Location pos = (Location) loc.Clone();

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

            Player.SetLocation(pos.X, pos.Y, pos.Z, pos.Yaw, pos.Pitch);
        }

        internal void LookUpdate(float yaw, float pitch, bool onGround)
        {
            Player.Location.Yaw = yaw;
            Player.Location.Pitch = pitch;
            
            ((EntityPlayer) Player).IsOnGround = onGround;
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityLook(Player.EntityId, yaw, pitch, onGround), false);
        }

        internal void Teleport(double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            Player.Location.X = x;
            Player.Location.Y = y;
            Player.Location.Z = z;
            Player.Location.Yaw = yaw;
            Player.Location.Pitch = pitch;
            
            ((EntityPlayer) Player).IsOnGround = onGround;
            MinecraftServer.BroadcastInWorld(Player, Player.World, new PlayOutEntityTeleport(Player.EntityId, x, y, z, yaw, pitch, onGround), false);
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
            Packet playerInfo = new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, (EntityPlayer) Player);
            Packet spawnPlayer = new PlayOutSpawnPlayer(Player);
            
            SendPacket(playerInfo);
            foreach (Player onlinePlayer in Bukkit.OnlinePlayers)
            {
                EntityPlayer player = (EntityPlayer) onlinePlayer;
                if (player.CanSee(Player))
                {
                    player.NetworkManager.SendPacket(playerInfo);
                    player.NetworkManager.SendPacket(spawnPlayer);
                }

                if (((EntityPlayer) Player).CanSee(player))
                {
                    SendPacket(
                        new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.AddPlayer, player));
                    SendPacket(new PlayOutSpawnPlayer(player));
                }
            }
        }

        public void SendPacket(Packet packet)
        {
            if (Client == null || !Client.Connected) return;
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
                if (e.ErrorCode != 10053 && e.SocketErrorCode != SocketError.Disconnecting && Client != null && Client.Connected)
                {
                    Console.Error.WriteLine(e.Message);
                    Kick(e.Message);
                }
                Disconnect();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                if(Client != null && Client.Connected)
                    try
                    {
                        Kick(e.Message);
                    }
                    catch (Exception err) {}
                
                Disconnect();
            }
        }
    }
}