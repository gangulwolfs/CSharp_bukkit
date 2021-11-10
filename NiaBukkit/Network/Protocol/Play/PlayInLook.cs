namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInLook : PlayInPacket
    {
        internal override void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.LookUpdate(buf.ReadFloat(), buf.ReadFloat(), buf.ReadBool());
        }

        internal override int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 19;
            if (protocol > ProtocolVersion.v1_15_2)
                return 20;
            if (protocol > ProtocolVersion.v1_13_2)
                return 19;
            if (protocol > ProtocolVersion.v1_12_2)
                return 18;
            if (protocol > ProtocolVersion.v1_11_2)
                return 15;
            if (protocol >= ProtocolVersion.v1_9)
                return 14;
            return 5;
        }
    }
}