using NiaBukkit.API.Util;

namespace NiaBukkit.API.Entity
{
    public interface Entity
    {
        public int EntityId { get; }
        public Location Location { get; }
        public World.World World { get; }

        public void SetLocation(double x, double y, double z, float yaw, float pitch);
    }
}