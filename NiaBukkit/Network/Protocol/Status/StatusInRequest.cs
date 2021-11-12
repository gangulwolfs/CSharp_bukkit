using NiaBukkit.API;
using NiaBukkit.API.Config;

namespace NiaBukkit.Network.Protocol.Status
{
    /**
     * <summary>Client Request Server Info</summary>
     */
    public class StatusInRequest
    {
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
            networkManager.SendPacket(new StatusOutResponse(Bukkit.MinecraftServer.Protocol, ServerProperties.MaxPlayers, 0,
                ServerProperties.Motd));
        }
    }
}