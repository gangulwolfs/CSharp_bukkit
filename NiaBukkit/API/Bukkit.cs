using System.IO;
using System.Reflection;
using NiaBukkit.Network;

namespace NiaBukkit.API
{
    public class Bukkit
    {
        internal static PluginManager pluginManager = new PluginManager();
        public static PluginManager PluginManager => pluginManager;

        internal static MinecraftServer minecraftServer;

        public static string ServerPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}