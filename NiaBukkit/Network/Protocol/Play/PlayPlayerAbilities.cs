using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInPlayerAbilities : IPacket
    {
        public void Read(NetworkManager manager, ByteBuf buf)
        {
            manager.Player?.UpdateAbilities((buf.ReadByte() & 0x02) != 0);
            //manager.Player?.UpdateAbilities(buf.ReadByte(), buf.ReadFloat(), buf.ReadFloat());
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                >= ProtocolVersion.v1_16 => 26,
                >= ProtocolVersion.v1_14 => 25,
                >= ProtocolVersion.v1_13 => 23,
                >= ProtocolVersion.v1_12 => 19,
                >= ProtocolVersion.v1_9 => 18,
                _ => 19
            };
        }
    }

    public class PlayOutPlayerAbilities : IPacket
    {
        private readonly byte _flag;
        private readonly float _flySpeed, _walkSpeed;

        public PlayOutPlayerAbilities(PlayerAbilities abilities)
        {
            _flag = GetFlag(abilities);
            _flySpeed = abilities.FlySpeed;
            _walkSpeed = abilities.WalkSpeed;
        }
        public PlayOutPlayerAbilities(byte flag, float flySpeed, float walkSpeed)
        {
            _flag = flag;
            _flySpeed = flySpeed;
            _walkSpeed = walkSpeed;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));

            buf.WriteByte(_flag);
            buf.WriteFloat(_flySpeed);
            buf.WriteFloat(_walkSpeed);
        }

        private static byte GetFlag(PlayerAbilities abilities)
        {
            byte data = 0;
            if (abilities.IsInvulnerable)
                data |= 0x1;
            if (abilities.IsFly)
                data |= 0x2;
            if (abilities.CanFly)
                data |= 0x4;
            if (abilities.CanInstantlyBuild)
                data |= 0x8;

            return data;
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