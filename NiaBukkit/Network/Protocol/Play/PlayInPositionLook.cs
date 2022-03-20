using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInPositionLook : IPacket
    {
        public void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.Move(buf.ReadDouble(), buf.ReadDouble(), buf.ReadDouble()
                , buf.ReadFloat(), buf.ReadFloat()
                , buf.ReadBool());
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 18,
                > ProtocolVersion.v1_15_2 => 19,
                > ProtocolVersion.v1_13_2 => 18,
                > ProtocolVersion.v1_12_2 => 17,
                > ProtocolVersion.v1_11_2 => 14,
                >= ProtocolVersion.v1_9 => 13,
                _ => 6
            };
        }
    }
}