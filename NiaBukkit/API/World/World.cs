using System;
using NiaBukkit.API.Config;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.World
{
    public class World
    {
        internal Dimention Dimension = Dimention.OverWorld;
        public Difficulty Difficulty = ServerProperties.Difficulty;
        public WorldType WorldType = WorldType.Default;

        public long Seed = new Random().Next(-10, 10);

        public bool IsHardCore { get; internal set; } = ServerProperties.Hardcore;
    }
}