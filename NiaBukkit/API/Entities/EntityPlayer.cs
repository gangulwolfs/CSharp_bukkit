using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NiaBukkit.API.Config;
using NiaBukkit.API.Threads;
using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.Network;
using NiaBukkit.Network.Protocol.Play;

namespace NiaBukkit.API.Entities
{
	public class EntityPlayer : Player
	{
		public readonly NetworkManager NetworkManager;
		public ChatMode ChatMode { get; internal set; }
		public bool ChatColor { get; internal set; }
		public int SkinPart { get; internal set; }
		public int Ping { get; private set; } = 0;

		public readonly PlayerAbilities PlayerAbilities = new();

		private readonly List<Player> _hidePlayers = new();

		private ChunkCoord _currentChunkCoord;

		private readonly ConcurrentBag<ChunkCoord> _loadedChunk = new();

		private Location _beforeLocation;

		public object[] Properties { get; private set; }


		public EntityPlayer(NetworkManager networkManager, GameProfile profile, World.World world, GameMode gameMode, object[] properties) : base(profile, world, gameMode)
		{
			NetworkManager = networkManager;
			_beforeLocation = (Location) Location.Clone();
			Properties = properties ?? Array.Empty<object>();
		}

		/**
		 * <summary>Send Message To Player</summary>
		 */
		public override void SendMessage(object message)
		{
			if (message == null)
				message = "null";
			
			SendMessage(message.ToString());
		}

		/**
		 * <summary>Send Message To Player</summary>
		 */
		public override void SendMessage(string message) => SendMessage(Uuid.RandomUuid(), ChatMessageType.Chat, message);

		public override void SendMessage(Uuid sender, string message) => SendMessage(sender, ChatMessageType.Chat, message);

		public override void SendMessage(ChatMessageType position, string message) =>
			SendMessage(Uuid.RandomUuid(), position, message);
		
		public override void SendMessage(Uuid sender, ChatMessageType position, string message)
		{
			NetworkManager.SendPacket(new PlayOutChatMessage(message, ChatMessageType.Chat, Uuid.RandomUuid()));
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
			PlayerChunkMoveUpdate();
			
			_beforeLocation = (Location) Location.Clone();
		}

		private void PlayerChunkMoveUpdate()
		{
			if (_loadedChunk.Contains(_currentChunkCoord)) return;

			if (_beforeLocation != Location)
			{
				NetworkManager?.Teleport(_beforeLocation, Enumerable.Empty<TeleportFlags>());
			}
		}

		private void ChunkUpdate()
		{
			if (NetworkManager == null) return;
			
			if (_currentChunkCoord != null && _currentChunkCoord.X == (int) Location.X >> 4 &&
			    _currentChunkCoord.Z == (int) Location.Z >> 4)
				return;
			_currentChunkCoord = new ChunkCoord(World, (int) Location.X >> 4, (int) Location.Z >> 4);

			var list = new List<ChunkCoord>();

			var radius = ServerProperties.ViewDistance;
			
			for (var x = -radius; x <= radius; x++)
			{
				for (var z = -radius; z <= radius; z++)
				{
					var target = new ChunkCoord(World, _currentChunkCoord.X + x, _currentChunkCoord.Z + z);
					if(!_loadedChunk.Contains(target))
						list.Add(target);
				}
			}
			
			list.Sort((x1, x2) => x1.DistancePow(_currentChunkCoord).CompareTo(x2.DistancePow(_currentChunkCoord)));
			
			foreach (var chunkCoord in list)
			{
				WorldThreadManager.AddRequireChunk(chunkCoord, this);
			}
		}

		internal void SetPing(int ping)
        {
			if (Ping != ping)
			{
				Ping = ping;
				MinecraftServer.Broadcast(new PlayOutPlayerInfo(PlayOutPlayerInfo.EnumPlayerInfoAction.UpdateLatency, this));
			}
        }

		internal void UpdateAbilities(bool isFly)
        {
			PlayerAbilities.IsFly = isFly && PlayerAbilities.CanFly;
			NetworkManager.SendPacket(new PlayOutPlayerAbilities(PlayerAbilities));
        }
	}
}