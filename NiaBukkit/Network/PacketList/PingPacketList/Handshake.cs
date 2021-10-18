namespace NiaBukkit.Network.PacketList.PingPacketList
{
    public class Handshake : Packet
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