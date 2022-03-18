using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInLook : PlayInPacket
    {
        internal override void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.LookUpdate(buf.ReadFloat(), buf.ReadFloat(), buf.ReadBool());
        }

        internal override int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 19,
                > ProtocolVersion.v1_15_2 => 20,
                > ProtocolVersion.v1_13_2 => 19,
                > ProtocolVersion.v1_12_2 => 18,
                > ProtocolVersion.v1_11_2 => 15,
                >= ProtocolVersion.v1_9 => 14,
                _ => 5
            };
        }
    }
}