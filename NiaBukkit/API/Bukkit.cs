using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NiaBukkit.API.Entities;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API
{
    public class Bukkit
    {
	    /// <summary>플러그인 관련 클래스를 가져옵니다.</summary>
        public static readonly PluginManager PluginManager = new PluginManager();
		
	    /// <summary>콘솔 출력을 가져옵니다.</summary>
		public static readonly ConsoleSender ConsoleSender = new ConsoleSender();

        internal static MinecraftServer MinecraftServer;
        
        internal static readonly ConcurrentDictionary<Uuid, Player> Players = new ConcurrentDictionary<Uuid, Player>();
        internal static readonly ConcurrentDictionary<Uuid, Entity> Entities = new ConcurrentDictionary<Uuid, Entity>();
        public static ICollection<Player> OnlinePlayers => Players.Values;

		/// <summary>서버 파일이 있는 디렉터리 위치를 가져옵니다.</summary>
        public static string ServerPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

		public static World.World MainWorld = new World.World("world");

		internal static void AddPlayer(Player player)
		{
			player.World.Players.Add(player);
			player.World.Entities.Add(player);
			Players.TryAdd(player.Uuid, player);
			Entities.TryAdd(player.Uuid, player);
		}

		internal static void RemovePlayer(Player player)
		{
			player.World.Players.Remove(player);
			player.World.Entities.Remove(player);
			Players.Remove(player.Uuid, out var resultPlayer);
			Entities.Remove(player.Uuid, out var resultEntity);
		}
    }
}