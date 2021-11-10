using NiaBukkit.API.Util;

namespace NiaBukkit.API.Entity
{
    public interface Entity
    {
        int EntityId { get; }
        Location Location { get; }
        World.World World { get; }
        bool IsOnGround { get; }

        void SetLocation(double x, double y, double z, float yaw, float pitch);
    }
}