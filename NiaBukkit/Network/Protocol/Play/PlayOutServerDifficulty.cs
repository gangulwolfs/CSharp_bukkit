using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutServerDifficulty : Packet
    {
        private readonly Difficulty _difficulty;

        public PlayOutServerDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteByte((byte) _difficulty);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 14;
            if (protocol > ProtocolVersion.v1_15_2)
                return 13;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 14;
            if (protocol > ProtocolVersion.v1_8_9)
                return 13;
            return 65;
        }
    }
}