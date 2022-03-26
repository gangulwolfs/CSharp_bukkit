using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayInKeepAlive : IPacket
    {
        public void Read(NetworkManager manager, ByteBuf buf)
        {
            manager.Player.SetPing((int) (TimeManager.CurrentTimeMillis - buf.ReadLong()));
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 15,
                > ProtocolVersion.v1_15_2 => 16,
                > ProtocolVersion.v1_13_2 => 15,
                > ProtocolVersion.v1_12_2 => 14,
                >= ProtocolVersion.v1_9 => 11,
                _ => 0
            };
        }
    }
    public class PlayOutKeepAlive : IPacket
    {
        private readonly long _data;
        public PlayOutKeepAlive(long data)
        {
            _data = data;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            if (protocol < ProtocolVersion.v1_12)
                buf.WriteVarInt((int)_data);
            else
                buf.WriteLong(_data);
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            return protocol switch
            {
                > ProtocolVersion.v1_16_5 => 33,
                > ProtocolVersion.v1_15_2 => 31,
                > ProtocolVersion.v1_14_3_CT => 33,
                > ProtocolVersion.v1_13_2 => 32,
                > ProtocolVersion.v1_12_2 => 33,
                >= ProtocolVersion.v1_9 => 31,
                _ => 0
            };
        }
    }
}