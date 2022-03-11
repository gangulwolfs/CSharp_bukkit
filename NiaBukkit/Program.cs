using System;
using System.Text;
using System.Threading;
using NiaBukkit.API;
using NiaBukkit.API.Blocks;
using NiaBukkit.API.Config;
using NiaBukkit.API.Threads;
using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.Network;

namespace NiaBukkit
{
    public static class Program
    {
        public const string Name = "MC";

        private static void Main()
        {
            Console.WriteLine("Loading libraries, please wait...");
            Init();
            
            ServerProperties.LoadSettings();

            Bukkit.MinecraftServer = new MinecraftServer();
            Bukkit.ConsoleSender.SendMessage("Starting Minecraft server on *:" + ServerProperties.Port);
            
            Bukkit.PluginManager.LoadPlugins();

            Console.CancelKeyPress += ConsoleCloseEvent;

            Bukkit.MainWorld.WorldSpawn.Set(318.5, 4, 60);
            ChunkRegionManager.GetChunk(Bukkit.MainWorld, 321 >> 4, 63 >> 4);
        }

        private static void Init()
        {
            Thread.CurrentThread.Name = "Server Thread";
            
            Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;
            Console.SetError(new ConsoleSenderError(Console.Error));

            ChatColor.InitColors();
            BlockFactory.InitBlocks();
        }

        private static void ConsoleCloseEvent(object sender, ConsoleCancelEventArgs args)
        {
            Bukkit.PluginManager.DisablePlugins();
            ThreadFactory.KillAll();
        }
    }
}