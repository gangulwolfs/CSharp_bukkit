using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Play
{
    public class PlayOutDisconnect : IPacket
    {
        private readonly string _reason;
        
        public PlayOutDisconnect(string reason)
        {
            _reason = reason;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(GetPacketId(protocol));
            buf.WriteString(new JsonBuilder().Set("text", _reason).ToString());
        }

        public int GetPacketId(ProtocolVersion protocol)
        {
            if (protocol >= ProtocolVersion.v1_9)
                return 26;
            return 64;
        }
    }
}