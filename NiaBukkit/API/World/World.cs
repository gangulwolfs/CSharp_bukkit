using System;
using System.Collections.Concurrent;
using NiaBukkit.API.Config;
using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;
using NiaBukkit.API.World.Provider;

namespace NiaBukkit.API.World
{
    public class World
    {
        // WorldProvider
        internal Dimention Dimension = Dimention.OverWorld;
        public Difficulty Difficulty = ServerProperties.Difficulty;
        public WorldType WorldType = WorldType.Default;

        public long Seed = new Random().Next(-10, 10);

        public readonly ConcurrentBag<Player> Players = new ConcurrentBag<Player>();

        internal WorldProvider _provider;
        public bool IsHardCore { get; internal set; } = ServerProperties.Hardcore;

        public World()
        {
            _provider = new WorldProviderFlat(this);
        }

        internal Chunk GetChunk(int x, int z) => _provider.GetChunk(x, z);
    }
}