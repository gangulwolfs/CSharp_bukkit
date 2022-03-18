using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Ping
{
    /**
     * <summary>Client Info Received</summary>
     */
    public class PingInHandshake
    {
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.Protocol = (ProtocolVersion) buf.ReadVarInt();
            networkManager.Host = buf.ReadString();
            networkManager.Port = buf.ReadShort();
            int protocol = buf.ReadVarInt();

            switch (protocol)
            {
                case (int) PacketMode.Status:
                    networkManager.PacketMode = PacketMode.Status;
                    break;
                case (int) PacketMode.Login:
                    networkManager.PacketMode = PacketMode.Login;
                    break;
            }
        }
    }
}