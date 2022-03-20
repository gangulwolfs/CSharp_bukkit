using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.Network.Protocol
{
    public interface Packet
    {
        internal virtual void Write(ByteBuf buf, ProtocolVersion protocol) {}
        int GetPacketId(ProtocolVersion protocol);
    }
}