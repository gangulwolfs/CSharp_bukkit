namespace NiaBukkit.Network.PacketList
{
    public abstract class Packet
    {
        internal virtual void Write(ByteBuf buf) {}
    }
}