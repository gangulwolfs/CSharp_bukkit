using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API
{
    public class Bukkit
    {
        internal static PluginManager pluginManager = new PluginManager();
		
		/// <summary>플러그인 관련 클래스를 가져옵니다.</summary>
        public static PluginManager PluginManager => pluginManager;
		
		private static ConsoleSender consoleSender = new ConsoleSender();
		
		/// <summary>콘솔 출력을 가져옵니다.</summary>
		public static ConsoleSender ConsoleSender => consoleSender;

        internal static MinecraftServer minecraftServer;
        
        internal static readonly ConcurrentDictionary<Uuid, Player> Players = new ConcurrentDictionary<Uuid, Player>();
        public static ICollection<Player> OnlinePlayers => Players.Values;

		/// <summary>서버 파일이 있는 디렉터리 위치를 가져옵니다.</summary>
        public static string ServerPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

		internal static void AddPlayer(Player player)
		{
			player.World.Players.Add(player);
			Players.TryAdd(player.Uuid, player);
		}
    }
}