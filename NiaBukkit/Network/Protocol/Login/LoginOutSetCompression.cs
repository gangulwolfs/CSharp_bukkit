namespace NiaBukkit.Network.Protocol.Login
{
    /**
     * <summary>Use Packet Compress</summary>
     */
    public class LoginOutSetCompression : Packet
    {
        private readonly int _compress;
        public LoginOutSetCompression(int compress)
        {
            _compress = compress;
        }

        internal override void Write(ByteBuf buf, ProtocolVersion protocol)
        {
            buf.WriteVarInt((int) LoginPacket.SetCompress);
            buf.WriteVarInt(_compress);
        }
    }
}