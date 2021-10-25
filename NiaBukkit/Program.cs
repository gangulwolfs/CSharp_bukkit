using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using NiaBukkit.API;
using NiaBukkit.API.Config;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit
{
    class Program
    {
        public const string Name = "MC";
        
        static void Main(string[] args)
        {
            Console.WriteLine("Loading libraries, please wait...");
            Init();
            
            ServerProperties.LoadSettings();

            Bukkit.minecraftServer = new MinecraftServer();
            Bukkit.ConsoleSender.SendMessage("Starting Minecraft server on *:" + ServerProperties.Port);
            
            Bukkit.PluginManager.LoadPlugins();
        }

        private static void Init()
        {
            Thread.CurrentThread.Name = "Server Thread";
            
            Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;
            Console.SetError(new ConsoleSenderError(Console.Error));

            ChatColor.InitColors();
        }
    }
}