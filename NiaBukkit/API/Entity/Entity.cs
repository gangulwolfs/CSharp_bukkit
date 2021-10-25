using NiaBukkit.API.Util;

namespace NiaBukkit.API.Entity
{
    public interface Entity
    {
        int EntityId { get; }
        Location Location { get; }
    }
}