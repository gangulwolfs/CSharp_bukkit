using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Module;
using NiaBukkit.Network.PacketList;

namespace NiaBukkit.Network
{
    public class NetworkManager
    {
        internal static ConcurrentBag<NetworkManager> networkManagers = new ConcurrentBag<NetworkManager>();

        internal long lastPacketMillis = 0;
        internal TcpClient client;

        public PacketMode PacketMode { get; internal set; } = PacketMode.Ping;
        public ProtocolVersion Protocol { get; internal set; }
        public string Host { get; internal set; }
        public short Port { get; internal set; }

        private ICryptoTransform Encrypter;
        private ICryptoTransform Decrypter;

        internal NetworkManager(TcpClient client)
        {
            this.client = client;
            lastPacketMillis = TimeManager.CurrentTimeMillis;
            
            networkManagers.Add(this);
        }

        internal void Disconnect()
        {
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
            PacketFactory.Handle(this, buf, packetId);
        }

        public void SendPacket(Packet packet)
        {
            ByteBuf buf = new ByteBuf();
            packet.Write(buf);

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

                throw e;
            }
        }
    }
}