using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NiaBukkit.API.Config;
using NiaBukkit.API.Threads;
using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.Network;

namespace NiaBukkit.API.Entities
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

		private ChunkCoord _currentChunkCoord;

		private readonly ConcurrentBag<ChunkCoord> _loadedChunk = new ConcurrentBag<ChunkCoord>();

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

		internal void ChunkLoaded(ChunkCoord coord)
		{
			if(!_loadedChunk.Contains(coord))
				_loadedChunk.Add(coord);
		}

		internal override void Update()
		{
			ChunkUpdate();
		}

		private void ChunkUpdate()
		{
			if (_currentChunkCoord != null && _currentChunkCoord.X == (int) Location.X >> 4 &&
			    _currentChunkCoord.Z == (int) Location.Z >> 4)
				return;
			_currentChunkCoord = new ChunkCoord(World, (int) Location.X >> 4, (int) Location.Z >> 4);

			var radius = ServerProperties.ViewDistance;
			for (var x = -radius; x <= radius; x++)
			{
				for (var z = -radius; z <= radius; z++)
				{
					var target = new ChunkCoord(World, _currentChunkCoord.X + x, _currentChunkCoord.Z + z);
					if(!_loadedChunk.Contains(target))
						WorldThreadManager.AddRequireChunk(target, this);
				}
			}
		}
	}
}