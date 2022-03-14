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

        private static async void GetPlayer(NetworkManager networkManager, string name)
        {
	        var profile = new GameProfile(await Uuid.FromUserName(name), name);
			
	        if (Bukkit.Players.ContainsKey(profile.Uuid))
	        {
		        networkManager.Kick("Player Already Connected.");
		        return;
	        }
	        
	        networkManager.Player = new EntityPlayer(networkManager, profile, Bukkit.MainWorld, ServerProperties.GameMode);

	        if(ServerProperties.OnlineMode)
	        {
		        networkManager.Encryption();
	        }
	        else
	        {
		        networkManager.Play();
	        }
        }
	}
}