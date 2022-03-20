using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutEntityLook : IPacket
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
        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteVarInt(_entityId);
            buf.WriteByte((byte) (_yaw * 256.0F / 360.0F));
            buf.WriteByte((byte) (_pitch * 256.0F / 360.0F));
            buf.WriteBool(_onGround);
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 43,
                > ProtocolVersion.v1_15_2 => 41,
                > ProtocolVersion.v1_14_3_CT => 43,
                > ProtocolVersion.v1_12_2 => 42,
                > ProtocolVersion.v1_11_2 => 40,
                >= ProtocolVersion.v1_9 => 39,
                _ => 22
            };
        }
    }
}