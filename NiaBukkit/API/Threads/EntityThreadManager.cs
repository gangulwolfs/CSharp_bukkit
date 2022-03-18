using System.Threading;

namespace NiaBukkit.API.Threads
{
    public static class EntityThreadManager
    {
        private const int ThreadEmptyDelay = 500;
        private const int ThreadDelay = 50;
        internal static void Worker()
        {
            while (Bukkit.MinecraftServer.IsAvailable)
            {
                if (Bukkit.Entities.IsEmpty)
                {
                    Thread.Sleep(ThreadEmptyDelay);
                    continue;
                }
                
                foreach (var entity in Bukkit.Entities.Values)
                    entity.Update();
                
                Thread.Sleep(ThreadDelay);
            }
        }
    }
}