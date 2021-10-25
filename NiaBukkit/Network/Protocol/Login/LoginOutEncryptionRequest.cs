namespace NiaBukkit.Network.Protocol.Login
{
	/**
	 * <summary>Server Protocol Security</summary>
	 */
	public class LoginOutEncryptionRequest : Packet
	{
		private readonly byte[] publicKey;
		private readonly string serverId;
		private readonly byte[] vertificationToken;
		
		public LoginOutEncryptionRequest(byte[] publicKey, byte[] vertificationToken)
		{
			this.publicKey = publicKey;
			this.vertificationToken = vertificationToken;
			serverId = "";
		}
		
		internal override void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) LoginPacket.EncryptionRequest);
			buf.WriteString(serverId);
			buf.WriteVarInt(publicKey.Length);
			buf.Write(publicKey);
			buf.WriteVarInt(vertificationToken.Length);
			buf.Write(vertificationToken);
		}
	}
}