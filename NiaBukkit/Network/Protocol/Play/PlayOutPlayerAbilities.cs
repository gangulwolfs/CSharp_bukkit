using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPlayerAbilities : IPacket
    {
        private readonly PlayerAbilities _abilities;
        
        public PlayOutPlayerAbilities(PlayerAbilities abilities)
        {
            _abilities = abilities;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            byte data = 0;
            if (_abilities.IsInvulnerable)
                data |= 0x1;
            if (_abilities.IsFly)
                data |= 0x2;
            if (_abilities.CanFly)
                data |= 0x4;
            if (_abilities.CanInstantlyBuild)
                data |= 0x8;
            
            buf.WriteByte(data);
            buf.WriteFloat(_abilities.FlySpeed);
            buf.WriteFloat(_abilities.WalkSpeed);
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 50,
                > ProtocolVersion.v1_15_2 => 48,
                > ProtocolVersion.v1_14_3_CT => 50,
                > ProtocolVersion.v1_13_2 => 49,
                > ProtocolVersion.v1_12_2 => 46,
                > ProtocolVersion.v1_11_2 => 44,
                >= ProtocolVersion.v1_9 => 43,
                _ => 57
            };
        }
    }
}