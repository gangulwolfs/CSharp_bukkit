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
            buf.WriteByte((byte) (_yaw / 360 * 256));
            buf.WriteByte((byte) (_pitch / 360 * 256));
            
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
    
    public class PlayOutEntityTeleport : Packet
    {
        private readonly int _entityId;
        private readonly double _x, _y, _z;
        private readonly float _yaw, _pitch;
        private readonly bool _onGround;
        public PlayOutEntityTeleport(int entityId, double x, double y, double z, float yaw, float pitch, bool onGround)
        {
            _entityId = entityId;
            _x = x;
            _y = y;
            _z = z;
            _yaw = yaw;
            _pitch = pitch;
            _onGround = onGround;
        }
        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_entityId);
            if (protocol < ProtocolVersion.v1_9)
            {
                buf.WriteInt((int) (_x * 32));
                buf.WriteInt((int) (_y * 32));
                buf.WriteInt((int) (_z * 32));
            }
            else
            {
                buf.WriteDouble(_x);
                buf.WriteDouble(_y);
                buf.WriteDouble(_z);
            }

            buf.WriteByte((byte) (_yaw / 360 * 256));
            buf.WriteByte((byte) (_pitch / 360 * 256));
            buf.WriteBool(_onGround);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 97;
            if (protocol > ProtocolVersion.v1_15_2)
                return 86;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 87;
            if (protocol > ProtocolVersion.v1_12_2)
                return 80;
            if (protocol > ProtocolVersion.v1_11_2)
                return 76;
            if (protocol > ProtocolVersion.v1_9_4)
                return 73;
            if (protocol >= ProtocolVersion.v1_9)
                return 74;
            return 24;
        }
    }
}