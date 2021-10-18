namespace NiaBukkit.Network.PacketList
{
    public enum PacketMode
    {
        Ping,
        Status,
        Login,
        Play
    }

    public enum PingPacket
    {
        Handshake
    }

    public enum StatusPacket
    {
        Request,
        Ping
    }
}