using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInPosition : PlayInPacket
    {
        internal override void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.Move(buf.ReadDouble(), buf.ReadDouble(), buf.ReadDouble()
                , networkManager.Player.Location.Yaw, networkManager.Player.Location.Pitch
                , buf.ReadBool());
        }

        internal override int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol > ProtocolVersion.v1_16_5)
                return 17;
            if (protocol > ProtocolVersion.v1_15_2)
                return 18;
            if (protocol > ProtocolVersion.v1_13_2)
                return 17;
            if (protocol > ProtocolVersion.v1_12_2)
                return 16;
            if (protocol > ProtocolVersion.v1_11_2)
                return 13;
            if (protocol >= ProtocolVersion.v1_9)
                return 12;
            return 4;
        }
    }
}