using System.Diagnostics.CodeAnalysis;

namespace NiaBukkit.API.Threads
{
    public static class EntityThreadManager
    {
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: Enumerator[NiaBukkit.API.Entities.Entity]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: NiaBukkit.API.Entities.Entity[]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Collections.ObjectModel.ReadOnlyCollection`1[NiaBukkit.API.Entities.Entity]")]
        [SuppressMessage("ReSharper.DPA", "DPA0002: Excessive memory allocations in SOH", MessageId = "type: System.Collections.Generic.List`1[NiaBukkit.API.Entities.Entity]")]
        internal static void Worker()
        {
            while (Bukkit.MinecraftServer.IsAvailable)
            {
                foreach (var entity in Bukkit.Entities.Values)
                    entity.Update();
            }
        }
    }
}