using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutPlayerAbilities : Packet
    {
        private readonly PlayerAbilities _abilities;
        
        public PlayOutPlayerAbilities(PlayerAbilities abilities)
        {
            _abilities = abilities;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
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

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 50;
            if (protocol > ProtocolVersion.v1_15_2)
                return 48;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 50;
            if (protocol > ProtocolVersion.v1_13_2)
                return 49;
            if (protocol > ProtocolVersion.v1_12_2)
                return 46;
            if (protocol > ProtocolVersion.v1_11_2)
                return 44;
            if (protocol >= ProtocolVersion.v1_9)
                return 43;
            return 57;
        }
    }
}