using NiaBukkit.API.Command;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.Entity
{
	public class EntityPlayer : Player
	{
		public readonly NetworkManager NetworkManager;
		public readonly GameProfile Profile;

		public World.World _world;
		public World.World World => _world;
		
		private GameMode _gameMode;
		public GameMode GameMode => _gameMode;

		private int _entityId;
		public int EntityId => _entityId;

		private Location _location;
		public Location Location => _location;

		public EntityPlayer(NetworkManager networkManager, GameProfile profile, World.World world, GameMode gameMode)
		{
			NetworkManager = networkManager;
			Profile = profile;
			_gameMode = gameMode;
			_world = world;
			_location = new Location(world, 0, 0, 0);
		}

		/**
		 * <summary>Send Message To Player</summary>
		 */
		public void SendMessage(object message)
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
	}
}