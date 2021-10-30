namespace NiaBukkit.Network.Protocol
{
    public abstract class PlayInPacket
    {
        internal abstract void Read(NetworkManager networkManager, ByteBuf buf);
        internal abstract int GetPacketId(ProtocolVersion protocol);
    }
}