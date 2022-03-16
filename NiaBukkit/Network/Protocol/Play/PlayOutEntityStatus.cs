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
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 27,
                > ProtocolVersion.v1_15_2 => 26,
                > ProtocolVersion.v1_14_3_CT => 28,
                > ProtocolVersion.v1_13_2 => 27,
                > ProtocolVersion.v1_12_2 => 28,
                >= ProtocolVersion.v1_9 => 27,
                _ => 26
            };
        }
    }
}