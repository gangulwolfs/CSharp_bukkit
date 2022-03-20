using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityTeleport : IPacket
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
        public void Write(ByteBuf buf, ProtocolVersion protocol)
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

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 97,
                > ProtocolVersion.v1_15_2 => 86,
                > ProtocolVersion.v1_14_3_CT => 87,
                > ProtocolVersion.v1_12_2 => 80,
                > ProtocolVersion.v1_11_2 => 76,
                > ProtocolVersion.v1_9_4 => 73,
                >= ProtocolVersion.v1_9 => 74,
                _ => 24
            };
        }
    }
}