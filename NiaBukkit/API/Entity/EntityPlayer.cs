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

		private GameMode _gameMode;

		private int _entityId;

		
		internal Location _location;
		
		internal string locate;
		internal byte viewDistance;
		internal MainHand mainHand;
		internal int heldItemSlot;

		int Player.HeldItemSlot => heldItemSlot;
		GameMode Player.GameMode => _gameMode;
		string Player.Locate => locate;
		byte Player.ViewDistance => viewDistance;
		MainHand Player.MainHand => mainHand;
		
		World.World Entity.World => _world;
		int Entity.EntityId => _entityId;
		Location Entity.Location => _location;

		public ChatMode ChatMode { get; internal set; }
		public bool ChatColor { get; internal set; }
		public int SkinPart { get; internal set; }

		public readonly PlayerAbilities PlayerAbilities = new PlayerAbilities();

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

		public void SetLocation(double x, double y, double z, float yaw, float pitch)
		{
			_location.X = x;
			_location.Y = y;
			_location.Z = z;
			_location.Yaw = yaw;
			_location.Pitch = pitch;
		}
	}
}