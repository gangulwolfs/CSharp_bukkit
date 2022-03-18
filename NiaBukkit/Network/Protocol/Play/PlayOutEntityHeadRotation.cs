using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityHeadRotation : Packet
    {
        private readonly int _entityId;
        private readonly float _yaw;
        
        public PlayOutEntityHeadRotation(int entityId, float yaw)
        {
            _entityId = entityId;
            _yaw = yaw;
        }
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_entityId);
            buf.WriteByte((byte) (_yaw / 360 * 256));
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 62;
            if (protocol > ProtocolVersion.v1_15_2)
                return 58;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 60;
            if (protocol > ProtocolVersion.v1_13_2)
                return 59;
            if (protocol > ProtocolVersion.v1_12_2)
                return 57;
            if (protocol > ProtocolVersion.v1_11_2)
                return 54;
            if (protocol >= ProtocolVersion.v1_9)
                return 52;
            return 25;
        }
    }
}