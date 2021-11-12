using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutSpawnPosition : Packet
    {
        private readonly Location _location;
        public PlayOutSpawnPosition(Location location)
        {
            _location = location;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            long data = ((long) _location.X & 0x3FFFFFF) << 38 | (long) _location.Y & 0xFFF << 26 |
                        (long) _location.Z & 0x3FFFFFF;
            
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteLong(data);
        }

        private static int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 75;
            if (protocol > ProtocolVersion.v1_15_2)
                return 66;
            if (protocol > ProtocolVersion.v1_14_3_CT)
                return 78;
            if (protocol > ProtocolVersion.v1_13_2)
                return 77;
            if (protocol > ProtocolVersion.v1_12_2)
                return 73;
            if (protocol > ProtocolVersion.v1_11_2)
                return 70;
            if (protocol >= ProtocolVersion.v1_9)
                return 67;
            return 5;
        }
    }
}