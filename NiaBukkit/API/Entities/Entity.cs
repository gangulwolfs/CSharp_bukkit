using System;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Entities
{
    public class Entity
    {
        public readonly int EntityId;
        public Location Location { get; internal set; }
        public World.World World => Location.World;
        public bool IsOnGround { get; internal set; }

        public readonly Uuid Uuid;

        public Entity(World.World world) : this(Uuid.RandomUuid(), world) { }
        public Entity(Uuid uuid, World.World world) : this(uuid, world, world.WorldSpawn.X, world.WorldSpawn.Y, world.WorldSpawn.Z) { }

        public Entity(Uuid uuid, World.World world, double x, double y, double z)
        {
            Uuid = uuid;
            Location = new Location(world, x, y, z);
            Location.Changeable = false;
            EntityId = GenerateEntityId();
        }

        public void SetLocation(double x, double y, double z, float yaw, float pitch)
        {
            Location = new Location(Location.World, x, y, z, yaw, pitch);
        }

        private static int _currentEntityId;

        public static int GenerateEntityId()
        {
            return _currentEntityId++;
        }

        internal virtual void Update() { }
    }
}