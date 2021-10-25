using NiaBukkit.API.Command;

namespace NiaBukkit.API.Util
{
    public interface Player : CommandSender, Entity.Entity
    {
        GameMode GameMode { get; }
        public World.World World { get; }
    }
}