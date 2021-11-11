using System;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Entity
{
    public class Entity
    {
        public readonly int EntityId;
        public Location Location { get; internal set; }
        public World.World World => Location.World;
        public bool IsOnGround { get; internal set; }

        public Entity(World.World world) : this(world, 0, 0, 0) { }

        public Entity(World.World world, double x, double y, double z)
        {
            Location = new Location(world, 0, 0, 0);
            EntityId = GenerateEntityId();
        }

        public void SetLocation(double x, double y, double z, float yaw, float pitch)
        {
            Location = new Location(Location.World, x, y, z, yaw, pitch);
        }

        private static int _currentEntityId = -1;

        public static int GenerateEntityId()
        {
            if (_currentEntityId == Int32.MaxValue)
                return _currentEntityId = 0;

            return ++_currentEntityId;
        }
    }
}