using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Login
{
	/**
	 * <summary>Server Protocol Security</summary>
	 */
	public class LoginOutEncryptionRequest : Packet
	{
		private readonly string _serverId;
		private readonly byte[] _publicKey;
		private readonly byte[] _verificationToken;
		
		public LoginOutEncryptionRequest(string serverId, byte[] publicKey, byte[] verificationToken)
		{
			_serverId = serverId;
			_publicKey = publicKey;
			_verificationToken = verificationToken;
		}
		
		internal override void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) LoginPacket.EncryptionRequest);
			buf.WriteString(_serverId);
			buf.WriteVarInt(_publicKey.Length);
			buf.Write(_publicKey);
			buf.WriteVarInt(_verificationToken.Length);
			buf.Write(_verificationToken);
		}
	}
}