using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutServerDifficulty : IPacket
    {
        private readonly Difficulty _difficulty;

        public PlayOutServerDifficulty(Difficulty difficulty)
        {
            _difficulty = difficulty;
        }
        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteByte((byte) _difficulty);
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 14,
                > ProtocolVersion.v1_15_2 => 13,
                > ProtocolVersion.v1_14_3_CT => 14,
                >= ProtocolVersion.v1_9 => 13,
                _ => 65
            };
        }
    }
}