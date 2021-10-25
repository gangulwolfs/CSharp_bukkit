using NiaBukkit.Network.Protocol;
using NiaBukkit.Network.Protocol.Ping;
using NiaBukkit.Network.Protocol.Status;
using NiaBukkit.Network.Protocol.Login;

namespace NiaBukkit.Network.Protocol
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
					PacketInLogin(networkManager, buf, packetId);
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
                    PingInHandshake.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInStatus(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((StatusPacket) packetId)
            {
                case StatusPacket.Request:
                    StatusInRequest.Read(networkManager, buf);
                    break;
                case StatusPacket.Ping:
                    StatusInPing.Read(networkManager, buf);
                    break;
            }
        }

        private static void PacketInLogin(NetworkManager networkManager, ByteBuf buf, int packetId)
        {
            switch ((LoginPacket) packetId)
            {
                case LoginPacket.LoginStart:
                    LoginInStart.Read(networkManager, buf);
                    break;
                case LoginPacket.EncryptionResponse:
                    LoginInEncryptionResponse.Read(networkManager, buf);
                    break;
            }
        }
    }
}