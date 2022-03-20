using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInPosition : IPacket
    {
        public void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.Move(buf.ReadDouble(), buf.ReadDouble(), buf.ReadDouble()
                , networkManager.Player.Location.Yaw, networkManager.Player.Location.Pitch
                , buf.ReadBool());
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 17,
                > ProtocolVersion.v1_15_2 => 18,
                > ProtocolVersion.v1_13_2 => 17,
                > ProtocolVersion.v1_12_2 => 16,
                > ProtocolVersion.v1_11_2 => 13,
                >= ProtocolVersion.v1_9 => 12,
                _ => 4
            };
        }
    }
}