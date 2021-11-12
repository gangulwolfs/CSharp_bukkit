using NiaBukkit.API.Util;

namespace NiaBukkit.API.Config
{
    public static class ChatSettings
    {
        public static char CommandPrefix = '/';

        public static string ChatFormat(Player sender, string message) => $"<{sender.Name}> {message}";

        public static string CommandFormat(Player sender, string command) =>
            $"{sender.Name} issued server command ${CommandPrefix}{command}";
    }
}