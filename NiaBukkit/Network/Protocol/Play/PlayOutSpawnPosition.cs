using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutSpawnPosition : IPacket
    {
        private readonly Location _location;
        public PlayOutSpawnPosition(Location location)
        {
            _location = location;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            long data = ((long) _location.X & 0x3FFFFFF) << 38 | (long) _location.Y & 0xFFF << 26 |
                        (long) _location.Z & 0x3FFFFFF;
            
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteLong(data);
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 75,
                > ProtocolVersion.v1_15_2 => 66,
                > ProtocolVersion.v1_14_3_CT => 78,
                > ProtocolVersion.v1_13_2 => 77,
                > ProtocolVersion.v1_12_2 => 73,
                > ProtocolVersion.v1_11_2 => 70,
                >= ProtocolVersion.v1_9 => 67,
                _ => 5
            };
        }
    }
}