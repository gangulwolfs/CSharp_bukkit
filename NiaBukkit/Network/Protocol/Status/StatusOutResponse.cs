using System;
using System.IO;
using NiaBukkit.API;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Status
{
	/**
	 * <summary>Client Server Info(Max Players, Online Players, Motd) Send</summary>
	 */
	public class StatusOutResponse : Packet {
		private readonly string _status;

		public StatusOutResponse(ProtocolVersion protocol, int maxPlayers, int onlinePlayers, string description, params GameProfile[] profiles)
		{
			var json = new JsonBuilder();
			var version = new JsonBuilder().Set("name", protocol.GetProtocolName()).Set("protocol", (int) protocol);
			var players = new JsonBuilder().Set("max", maxPlayers).Set("online", onlinePlayers);

			var sampleLength = profiles.Length;
			if (sampleLength > 0)
			{
				var array = new JsonBuilder[sampleLength];
				for (var i = 0; i < sampleLength; i++)
				{
					var profile = profiles[i];
					array[i] = new JsonBuilder().Set("name", profile.Name).Set("id", profile.Uuid);
				}

				players.Set("sample", array);
			}

			json.Set("version", version);
			json.Set("players", players);
			json.Set("description", new JsonBuilder().Set("text", description));
			_status = json.ToString();
		}

		internal override void Write(ByteBuf buf, ProtocolVersion protocol)
		{
			buf.WriteVarInt((int) StatusPacket.Response);
			buf.WriteString(_status);
		}
	}
}
