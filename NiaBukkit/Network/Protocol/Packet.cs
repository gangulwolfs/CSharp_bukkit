using NiaBukkit.Network;

namespace NiaBukkit.Network.Protocol
{
    public abstract class Packet
    {
        internal virtual void Write(ByteBuf buf, ProtocolVersion protocol) {}
    }
}