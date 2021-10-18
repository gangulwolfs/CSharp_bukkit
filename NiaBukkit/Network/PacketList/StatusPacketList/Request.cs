using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Module;

namespace NiaBukkit.Network.PacketList.StatusPacketList
{
    public class Request
    {
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.SendPacket(new StatusRequestPacket(Bukkit.minecraftServer.Protocol, ServerProperties.MaxPlayers, 0,
                ServerProperties.Motd));
        }

        public class StatusRequestPacket : Packet
        {
            private readonly string status;
            
            public StatusRequestPacket(ProtocolVersion protocol, int maxPlayers, int onlinePlayers, string description)
            {
                JsonBuilder json = new JsonBuilder();
                json.Add("version", new JsonBuilder().Add("name", protocol.ToString()).Add("protocol", (int) protocol));
                json.Add("players", new JsonBuilder().Add("max", maxPlayers).Add("online", onlinePlayers));
                json.Add("description", new JsonBuilder().Add("text", description));

                status = json.ToString();
            }

            internal override void Write(ByteBuf buf)
            {
                buf.WriteVarInt((int) StatusPacket.Request);
                buf.WriteString(status);
            }
        }
    }
}