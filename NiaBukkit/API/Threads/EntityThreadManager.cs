using System.Threading;

namespace NiaBukkit.API.Threads
{
    public static class EntityThreadManager
    {
        private const int ThreadDelay = 200;
        internal static void Worker()
        {
            while (Bukkit.MinecraftServer.IsAvailable)
            {
                if (Bukkit.Entities.IsEmpty)
                {
                    Thread.Sleep(ThreadDelay);
                    continue;
                }
                
                foreach (var entity in Bukkit.Entities.Values)
                    entity.Update();
            }
        }
    }
}