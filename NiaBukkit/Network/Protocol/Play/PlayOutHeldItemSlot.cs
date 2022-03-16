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
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 72,
                > ProtocolVersion.v1_15_2 => 63,
                > ProtocolVersion.v1_14_3_CT => 64,
                > ProtocolVersion.v1_13_2 => 63,
                > ProtocolVersion.v1_12_2 => 61,
                > ProtocolVersion.v1_11_2 => 58,
                >= ProtocolVersion.v1_9 => 55,
                _ => 9
            };
        }
    }
}