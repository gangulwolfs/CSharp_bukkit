using System.Collections.Generic;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.Entity
{
	public class EntityPlayer : Player
	{
		public readonly NetworkManager NetworkManager;
		public ChatMode ChatMode { get; internal set; }
		public bool ChatColor { get; internal set; }
		public int SkinPart { get; internal set; }
		public int Ping { get; internal set; } = 0;

		public readonly PlayerAbilities PlayerAbilities = new PlayerAbilities();

		private readonly List<Player> _hidePlayers = new List<Player>();

		public EntityPlayer(NetworkManager networkManager, GameProfile profile, World.World world, GameMode gameMode) : base(profile, world, gameMode)
		{
			NetworkManager = networkManager;
		}

		/**
		 * <summary>Send Message To Player</summary>
		 */
		public override void SendMessage(object message)
		{
			SendMessage(message.ToString());
		}

		/**
		 * <summary>Send Message To Player</summary>
		 */
		public void SendMessage(string message)
		{
			//TODO: SendMessage
		}

		public bool CanSee(Player player)
		{
			return !_hidePlayers.Contains(player);
		}

		public void AddHidePlayer(Player player)
		{
			_hidePlayers.Add(player);
		}
	}
}