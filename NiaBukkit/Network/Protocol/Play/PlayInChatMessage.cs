using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInChatMessage : IPacket
    {
        public void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.MessageReceived(buf.ReadString());
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_13_2 => 3,
                >= ProtocolVersion.v1_9 => 2,
                _ => 1
            };
        }
    }
}