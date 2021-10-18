using NiaBukkit.Network.PacketList.PingPacketList;
using NiaBukkit.Network.PacketList.StatusPacketList;

namespace NiaBukkit.Network.PacketList
{
    public class PacketFactory
    {
        internal static void Handle(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch (networkManager.PacketMode)
            {
                case PacketMode.Ping:
                    PacketInPing(networkManager, buf, packetId);
                    break;
                case PacketMode.Status:
                    PacketInStatus(networkManager, buf, packetId);
                    break;
                case PacketMode.Login:
                    break;
                case PacketMode.Play:
                    break;
            }
        }

        private static void PacketInPing(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((PingPacket) packetId)
            {
                case PingPacket.Handshake:
                    Handshake.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInStatus(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((StatusPacket) packetId)
            {
                case StatusPacket.Request:
                    Request.Read(networkManager, buf);
                    break;
                case StatusPacket.Ping:
                    Ping.Read(networkManager, buf);
                    break;
            }
        }
    }
}