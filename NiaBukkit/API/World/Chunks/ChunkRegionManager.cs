using System;
using NiaBukkit.API.NBT;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public class ChunkRegionManager
    {
        internal static Chunk GetChunk(World world, int x, int z)
        {
            var buf = RegionFile.Load($"D:/마인크래프트/1.8.8/world/region/r.{x >> 5}.{z >> 5}.mca", x, z);

            var nbt = NBTBase.CreateTag((byte) buf.ReadByte());
            
            if (nbt is not NBTTagCompound)
                return null;
            buf.ReadUtf();
            try
            {
                nbt.Load(buf, 0);

                var chunk = new Chunk(world, x, z);
                return chunk;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Console.Error.WriteLine($"(world={world.Name}, x={x}, z={z}) 'r.{x}.{z}.mca' file load error");
            }

            return null;
        }
    }
}