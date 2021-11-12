using NiaBukkit.API;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityLook : Packet
    {
        private readonly int _entityId;
        private readonly float _yaw, _pitch;
        private readonly bool _onGround;
        public PlayOutEntityLook(int entityId, float yaw, float pitch, bool onGround)
        {
            _entityId = entityId;
            _yaw = yaw;
            _pitch = pitch;
            _onGround = onGround;
        }
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_entityId);
            buf.WriteByte((byte) (_yaw * 256.0F / 360.0F));
            buf.WriteByte((byte) (_pitch * 256.0F / 360.0F));
            buf.WriteBool(_onGround);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 43;
            if (protocol > ProtocolVersion.v1_15_2)
                return 41;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 43;
            if (protocol > ProtocolVersion.v1_12_2)
                return 42;
            if (protocol > ProtocolVersion.v1_11_2)
                return 40;
            if (protocol >= ProtocolVersion.v1_9)
                return 39;
            return 22;
        }
    }
}