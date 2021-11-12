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
	public class LoginInStart
	{
        internal static void Read(NetworkManager networkManager, ByteBuf buf)
        {
			string name = buf.ReadString();
			
			// GameProfile profile = new GameProfile(Uuid.FromUserName("OfflinePlayer: " + name), name);
			GameProfile profile = new GameProfile(Uuid.FromUserName(name), name);
			
			if (Bukkit.Players.ContainsKey(profile.Uuid))
			{
				networkManager.Kick("Player Already Connected.");
				return;
			}
			
			//TODO: Load World
			networkManager.Player =
				new EntityPlayer(networkManager, profile, Bukkit.MainWorld, ServerProperties.GameMode);
			
			if(!ServerProperties.OnlineMode)
			{
				networkManager.SendPacket(new LoginOutEncryptionRequest(
					SelfCryptography.PublicKeyToAsn1(Bukkit.MinecraftServer.ServerKey),
					SelfCryptography.GetRandomToken()
				));
			}
			else
			{
				networkManager.SendPacket(new LoginOutSetCompression(ServerSettings.UseCompression
					? ServerSettings.CompressionThreshold
					: -1));
				networkManager.SendPacket(new LoginOutSuccess(profile));
				
				networkManager.PacketMode = PacketMode.Play;
				networkManager.SendPacket(new PlayOutJoinGame(networkManager.Player));
				networkManager.SendPacket(new PlayOutServerDifficulty(networkManager.Player.World.Difficulty));
				networkManager.SendPacket(new PlayOutPlayerAbilities(((EntityPlayer) networkManager.Player).PlayerAbilities));
				networkManager.SendPacket(new PlayOutHeldItemSlot(networkManager.Player.HeldItemSlot));
				networkManager.SendPacket(new PlayOutEntityStatus(networkManager.Player.EntityId, 9));
				
				//TODO: PacketPlayOutRecipes
				//TODO: PacketPlayOutSetSlot
				
				networkManager.InitPlayer();

				Bukkit.AddPlayer(networkManager.Player);
				
				//TODO: PacketPlayOutEntityMetadata
				//
				//
				networkManager.SetPosition(networkManager.Player.Location, Enumerable.Empty<TeleportFlags>());
				networkManager.SendPacket(new PlayOutSpawnPosition(networkManager.Player.Location));
				
				// networkManager.SendPacket(new PlayOutChunkData(networkManager.Player.World.GetChunk(0, 0)));
				// networkManager.SendPacket(new PlayOutChunkData(networkManager.Player.World.GetChunk(1, 0)));
				// networkManager.SendPacket(new PlayOutChunkData(networkManager.Player.World.GetChunk(-1, 0)));
			}
        }
	}
}