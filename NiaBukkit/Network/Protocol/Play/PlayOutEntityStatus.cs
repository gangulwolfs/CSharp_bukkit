namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityStatus : Packet
    {
        private readonly int _id;
        private readonly byte _data;

        public PlayOutEntityStatus(int id, byte data)
        {
            _id = id;
            _data = data;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteInt(_id);
            buf.WriteByte(_data);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 27;
            if (protocol > ProtocolVersion.v1_15_2)
                return 26;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 28;
            if (protocol > ProtocolVersion.v1_13_2)
                return 27;
            if (protocol > ProtocolVersion.v1_12_2)
                return 28;
            if (protocol > ProtocolVersion.v1_8_9)
                return 27;
            return 26;
        }
    }
}