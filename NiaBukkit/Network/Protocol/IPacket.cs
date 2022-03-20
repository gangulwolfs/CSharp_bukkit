using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.Network.Protocol
{
    public interface IPacket
    {
        void Write(ByteBuf buf, ProtocolVersion protocol)
        {
        }

        void Read(NetworkManager manager, ByteBuf buf)
        {
        }

        int GetPacketId(ProtocolVersion protocol) => 0;
    }
}