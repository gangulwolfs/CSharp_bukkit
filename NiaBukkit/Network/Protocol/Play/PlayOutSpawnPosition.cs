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
            
            buf.WriteVarInt(70);
            buf.WriteLong(data);
        }
    }
}