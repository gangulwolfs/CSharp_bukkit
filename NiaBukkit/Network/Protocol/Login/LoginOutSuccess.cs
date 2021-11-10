using System;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Login
{
	/**
	 * <summary>Login Success Packet</summary>
	 */
	public class LoginOutSuccess : Packet
	{
		private readonly GameProfile _profile;
		
		public LoginOutSuccess(GameProfile profile)
		{
			_profile = profile;
		}
		
		internal override void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) LoginPacket.LoginSuccess);
			
			if(protocol > ProtocolVersion.v1_15_2)
			{
				foreach (int i in GuidSerialize(_profile.Uuid.ToGuid()))
					buf.WriteInt(i);
			}
			else
				buf.WriteString(_profile.Uuid.ToString());
				
			buf.WriteString(_profile.Name);
		}
		
		private static int[] GuidSerialize(Guid guid)
		{
			byte[] bytes = guid.ToByteArray();

			// guid bytes to uuid packet
			(bytes[4], bytes[6]) = (bytes[6], bytes[4]); // swap 4 <> 6
			(bytes[5], bytes[7]) = (bytes[7], bytes[5]); // swap 5 <> 7

			(bytes[8], bytes[11]) = (bytes[11], bytes[8]); // swap 8 <> 11
			(bytes[9], bytes[10]) = (bytes[10], bytes[9]); // swap 9 <> 10

			(bytes[12], bytes[15]) = (bytes[15], bytes[12]); // swap 12 <> 15
			(bytes[13], bytes[14]) = (bytes[14], bytes[13]); // swap 13 <> 14
			
			return new [] {
				BitConverter.ToInt32(bytes, 0),
				BitConverter.ToInt32(bytes, 4),
				BitConverter.ToInt32(bytes, 8),
				BitConverter.ToInt32(bytes, 12)
			};
		}
	}
}