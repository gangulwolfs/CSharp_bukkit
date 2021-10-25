using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Status
{
	/**
	 * <summary>Client Server Info(Max Players, Online Players, Motd) Send</summary>
	 */
	public class StatusOutResponse : Packet {
		private readonly string _status;

		public StatusOutResponse(ProtocolVersion protocol, int maxPlayers, int onlinePlayers, string description)
		{
			JsonBuilder json = new JsonBuilder();
			json.Add("version", new JsonBuilder().Add("name", protocol.GetProtocolName()).Add("protocol", (int) protocol));
			json.Add("players", new JsonBuilder().Add("max", maxPlayers).Add("online", onlinePlayers));
			json.Add("description", new JsonBuilder().Add("text", description));

			_status = json.ToString();
		}

		internal override void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) StatusPacket.Response);
			buf.WriteString(_status);
		}
	}
}
