using System.Linq;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.Network.Protocol.Login
{
	/**
	 * <summary>Client Server Connect Request</summary>
	 */
	public static class LoginInStart
	{
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
			var name = buf.ReadString();
			GetPlayer(networkManager, name);
        }

        private static void GetPlayer(NetworkManager networkManager, string name)
        {
	        if(ServerProperties.OnlineMode)
	        {
		        networkManager.Encryption();
		        return;
	        }
	        
	        var profile = new GameProfile(Uuid.FromUserName(name), name);
	        networkManager.Name = profile.Name;
	        
	        if (Bukkit.Players.ContainsKey(profile.Uuid))
	        {
		        networkManager.Kick("Player Already Connected.");
		        return;
	        }
	        
	        networkManager.InitEntityPlayer(profile);
	        networkManager.Play();
        }
	}
}