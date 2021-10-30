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
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.Network
{
    public class NetworkManager
    {
        internal static ConcurrentBag<NetworkManager> networkManagers = new ConcurrentBag<NetworkManager>();

        internal long lastPacketMillis = 0;
        internal TcpClient client;
        
        public bool IsAvilable { get; private set; }

        public PacketMode PacketMode { get; internal set; } = PacketMode.Ping;
        public ProtocolVersion Protocol { get; internal set; }
        public string Host { get; internal set; }
        public short Port { get; internal set; }

        internal ICryptoTransform Encrypter;
        internal ICryptoTransform Decrypter;
		
		public Player Player { get; internal set; }

        private int _teleportAwait = 0;

        internal NetworkManager(TcpClient client)
        {
            IsAvilable = true;
            
            this.client = client;
            lastPacketMillis = TimeManager.CurrentTimeMillis;
            
            networkManagers.Add(this);
        }

        internal void Disconnect()
        {
            IsAvilable = false;
            
            NetworkManager manager = this;
            networkManagers.TryTake(out manager);
            
            // TODO: Client Disconnected
        }

        private int GetPacketLength()
        {
            if (ServerSettings.UseCompression && PacketMode == PacketMode.Play)
            {
                int packetLength = ByteBuf.ReadVarInt(client.GetStream());
                int dataLength = ByteBuf.ReadVarInt(client.GetStream());

                if (dataLength == 0) return packetLength - ByteBuf.GetVarInt(dataLength).Length;
                return dataLength;
            }

            return ByteBuf.ReadVarInt(client.GetStream());
        }

        internal void Update()
        {
            lastPacketMillis = TimeManager.CurrentTimeMillis;
            
            byte[] bytes = new byte[GetPacketLength()];
            client.GetStream().Read(bytes, 0, bytes.Length);
            //TODO: 압축 추가

            if (Decrypter != null)
            {
                byte[] data = bytes;
                bytes = new byte[data.Length];
                Decrypter.TransformBlock(data, 0, data.Length, bytes, 0);
            }

            ByteBuf buf = new ByteBuf(bytes);
            var packetId = buf.ReadVarInt();
			Bukkit.ConsoleSender.SendMessage(PacketMode.ToString() +", " + packetId);
            PacketFactory.Handle(this, buf, packetId);
        }

        internal void Teleport(Location loc, IEnumerable<TeleportFlags> flags)
        {
            if (++_teleportAwait == Int32.MaxValue)
                _teleportAwait = 0;
            
            SendPacket(new PlayOutPosition(loc.X, loc.Y, loc.Z, loc.Yaw, loc.Pitch, flags, _teleportAwait));
            Location pos = (Location) loc.Clone();

            if (flags.Contains(TeleportFlags.X))
                pos.X += Player.Location.X;
            if (flags.Contains(TeleportFlags.Y))
                pos.Y += Player.Location.Y;
            if (flags.Contains(TeleportFlags.Z))
                pos.Z += Player.Location.Z;
            
            if (flags.Contains(TeleportFlags.YRot))
                pos.Yaw += Player.Location.Yaw;
            if (flags.Contains(TeleportFlags.XRot))
                pos.Pitch += Player.Location.Pitch;

            ((EntityPlayer) Player).SetLocation(pos.X, pos.Y, pos.Z, pos.Yaw, pos.Pitch);
        }

        public void SendPacket(Packet packet)
        {
            if (client == null || !client.Connected) return;
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

                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
                else
                {
                    client.Client.Send(data);
                }
            }
            catch (Exception e)
            {
                //TODO: client disconnect and send error
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}