using System;
using System.IO;
using System.Text;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Config
{
    public class ServerProperties
    {
        private const string Name = "server.properties";
        public static GameMode GameMode { get; private set; } = GameMode.Survival;
        public static bool EnableCommandBlock { get; private set; } = false;
        public static string Motd { get; private set; } = "§b§lA Minecraft Server";
        public static bool Pvp { get; private set; } = false;
        public static bool GenerateStructures { get; private set; } = true;
        public static Difficulty Difficulty { get; private set; } = Difficulty.Easy;
        public static int MaxPlayers { get; set; } = 20;
        public static bool OnlineMode { get; private set; } = true;
        public static int ViewDistance { get; private set; } = 10;
        public static int MaxBuildHeight { get; private set; } = 256;
        public static int Port { get; private set; } = 25565;
        public static bool ForceGameMode { get; private set; } = false;
        public static bool Hardcore { get; private set; } = false;
        public static bool WhiteList { get; private set; } = false;
        public static bool SpawnNPCs { get; private set; } = false;
        public static bool SpawnAnimals { get; private set; } = false;
        
        internal static void LoadSettings()
        {
            if (!File.Exists(Path.Join(Bukkit.ServerPath, Name)))
            {
                WriteSettings();
                return;
            }
            
            //TODO: load settings
        }

        private static void WriteSettings()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("#Minecraft server properties");
            builder.AppendLine(DateTime.Now.ToString("# ddd MMM dd HH:mm:ss yyyy"));
            builder.Append("gamemode=");
            builder.AppendLine(GameMode.ToString().ToLower());
            builder.Append("enable-command-block=");
            builder.AppendLine(EnableCommandBlock.ToString());
            builder.Append("motd=");
            builder.AppendLine(Motd);
            builder.Append("pvp=");
            builder.AppendLine(Pvp.ToString());
            builder.Append("generate-structures=");
            builder.AppendLine(GenerateStructures.ToString());
            builder.Append("difficulty=");
            builder.AppendLine(Difficulty.ToString().ToLower());
            builder.Append("max-players=");
            builder.AppendLine(MaxPlayers.ToString());
            builder.Append("online-mode=");
            builder.AppendLine(OnlineMode.ToString());
            builder.Append("view-distance=");
            builder.AppendLine(ViewDistance.ToString());
            builder.Append("max-build-height=");
            builder.AppendLine(MaxBuildHeight.ToString());
            builder.Append("server-port=");
            builder.AppendLine(Port.ToString());
            builder.Append("force-gamemode=");
            builder.AppendLine(ForceGameMode.ToString());
            builder.Append("hardcore=");
            builder.AppendLine(Hardcore.ToString());
            builder.Append("white-list=");
            builder.AppendLine(WhiteList.ToString());
            builder.Append("spawn-npcs=");
            builder.AppendLine(SpawnNPCs.ToString());
            builder.Append("spawn-animals=");
            builder.AppendLine(SpawnAnimals.ToString());
            
            File.WriteAllTextAsync(Path.Join(Bukkit.ServerPath, Name), builder.ToString());
        }
    }
}