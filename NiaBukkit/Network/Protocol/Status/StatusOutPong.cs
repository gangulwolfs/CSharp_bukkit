using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Status
{
	/**
	 * <summary>Ping Speed Send To Client</summary>
	 */
	public class StatusOutPong : IPacket {
		private readonly long time;
		
		public StatusOutPong(long time)
		{
			this.time = time;
		}

		public void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) StatusPacket.Pong);
			buf.WriteLong(time);
		}
	}
}
