using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityHeadRotation : IPacket
    {
        private readonly int _entityId;
        private readonly float _yaw;
        
        public PlayOutEntityHeadRotation(int entityId, float yaw)
        {
            _entityId = entityId;
            _yaw = yaw;
        }
        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_entityId);
            buf.WriteByte((byte) (_yaw / 360 * 256));
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 62,
                > ProtocolVersion.v1_15_2 => 58,
                > ProtocolVersion.v1_14_3_CT => 60,
                > ProtocolVersion.v1_13_2 => 59,
                > ProtocolVersion.v1_12_2 => 57,
                > ProtocolVersion.v1_11_2 => 54,
                >= ProtocolVersion.v1_9 => 52,
                _ => 25
            };
        }
    }
}