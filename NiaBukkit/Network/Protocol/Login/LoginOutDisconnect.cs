using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Login
{
    public class LoginOutDisconnect : IPacket
    {
        private readonly string _reason;
        
        public LoginOutDisconnect(string reason)
        {
            _reason = reason;
        }

        public void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt(0);
            buf.WriteString(new JsonBuilder().Set("text", _reason).ToString());
        }
    }
}