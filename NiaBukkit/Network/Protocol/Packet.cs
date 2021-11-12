using NiaBukkit.Network;

namespace NiaBukkit.Network.Protocol
{
    public class Packet
    {
        internal virtual void Write(ByteBuf buf, ProtocolVersion protocol) {}
    }
}