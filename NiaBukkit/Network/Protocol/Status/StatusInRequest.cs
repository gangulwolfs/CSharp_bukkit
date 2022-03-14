using System;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network.Protocol.Status
{
    /**
     * <summary>Client Request Server Info</summary>
     */
    public class StatusInRequest
    {
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
            var players = Bukkit.OnlinePlayers;
            
            var size = Math.Min(players.Count, 5);
            var profiles = new GameProfile[size];
            for (var i = 0; i < size; i++)
                profiles[i] = players[i].Profile;
            
            networkManager.SendPacket(new StatusOutResponse(Bukkit.MinecraftServer.Protocol, ServerProperties.MaxPlayers, players.Count,
                ServerProperties.Motd, profiles));
        }
    }
}