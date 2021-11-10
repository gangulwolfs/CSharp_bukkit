using System.Collections.Generic;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.Entity
{
	public class EntityPlayer : Player
	{
		public readonly NetworkManager NetworkManager;
		public readonly GameProfile Profile;

		private World.World _world;

		private GameMode _gameMode;

		private int _entityId;

		
		private Location _location;
		
		private string _locate;
		private byte _viewDistance;
		private MainHand _mainHand = MainHand.Right;
		private int _heldItemSlot;
		private bool _isOnGround;
		private string _listName;

		public int HeldItemSlot
		{
			get => _heldItemSlot;
			internal set => _heldItemSlot = value;
		}

		public GameMode GameMode
		{
			get => _gameMode;
			internal set => _gameMode = value;
		}

		public string Locate
		{
			get => _locate;
			internal set => _locate = value;
		}

		public byte ViewDistance
		{
			get => _viewDistance;
			internal set => _viewDistance = value;
		}

		public MainHand MainHand
		{
			get => _mainHand;
			internal set => _mainHand = value;
		}

		public World.World World
		{
			get => _world;
			internal set => _world = value;
		}

		public bool IsOnGround
		{
			get => _isOnGround;
			internal set => _isOnGround = value;
		}

		public int EntityId
		{
			get => _entityId;
			internal set => _entityId = value;
		}

		public Location Location
		{
			get => _location;
			internal set => _location = value;
		}
		public string ListName => _listName;
		
		public Uuid Uuid => Profile.Uuid;
		public string Name => Profile.Name;

		public ChatMode ChatMode { get; internal set; }
		public bool ChatColor { get; internal set; }
		public int SkinPart { get; internal set; }
		public int Ping { get; internal set; } = 0;

		public readonly PlayerAbilities PlayerAbilities = new PlayerAbilities();

		private readonly List<Player> _hidePlayers = new List<Player>();

		public EntityPlayer(NetworkManager networkManager, GameProfile profile, World.World world, GameMode gameMode)
		{
			NetworkManager = networkManager;
			Profile = profile;
			_gameMode = gameMode;
			_world = world;
			_location = new Location(world, 0, 6, 0);

			_world.Players.Add(this);
			Bukkit.Players.TryAdd(Profile.Uuid, this);
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