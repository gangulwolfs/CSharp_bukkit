namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutHeldItemSlot : Packet
    {
        private readonly int _slot;

        public PlayOutHeldItemSlot(int slot)
        {
            _slot = slot;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteByte((byte) _slot);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 72;
            if (protocol > ProtocolVersion.v1_15_2)
                return 63;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 64;
            if (protocol > ProtocolVersion.v1_13_2)
                return 63;
            if (protocol > ProtocolVersion.v1_12_2)
                return 61;
            if (protocol > ProtocolVersion.v1_11_2)
                return 58;
            if (protocol > ProtocolVersion.v1_8_9)
                return 55;
            return 9;
        }
    }
}