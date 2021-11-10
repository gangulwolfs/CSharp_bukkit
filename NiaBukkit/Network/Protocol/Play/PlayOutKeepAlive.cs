namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutKeepAlive : Packet
    {
        private readonly long _data;
        public PlayOutKeepAlive(long data)
        {
            _data = data;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            if(protocol < ProtocolVersion.v1_9)
                buf.WriteVarInt((int) (_data / 1000000L));
            else
                buf.WriteLong(_data);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 33;
            if (protocol > ProtocolVersion.v1_15_2)
                return 31;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 33;
            if (protocol > ProtocolVersion.v1_13_2)
                return 32;
            if (protocol > ProtocolVersion.v1_12_2)
                return 33;
            if (protocol >= ProtocolVersion.v1_9)
                return 31;
            return 0;
        }
    }
}