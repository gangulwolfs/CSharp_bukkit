using System;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public class ChunkRegionManager
    {
        internal static Chunk GetChunk(World world, int x, int z)
        {
            var buf = RegionFile.Load($"D:/마인크래프트/1.16.5/world/region/r.{x >> 5}.{z >> 5}.mca", x, z);
            if (buf == null)
                return null;

            var nbt = NBTBase.CreateTag((byte) buf.ReadByte());
            
            if (nbt is not NBTTagCompound nbtTagCompound)
                return null;
            buf.ReadUtf();
            try
            {
                nbt.Load(buf, 0);
                Bukkit.ConsoleSender.SendMessage(nbtTagCompound.Get("Status"));
                return GetChunk(world, x, z, nbtTagCompound.GetCompound("Level"));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                Console.Error.WriteLine($"(world={world.Name}, x={x}, z={z}) 'r.{x}.{z}.mca' file load error");
            }

            return null;
        }

        private static Chunk GetChunk(World world, int posX, int posZ, NBTTagCompound nbtTagCompound)
        {
            var chunk = new Chunk(world, posX, posZ);
            
            // chunk.SetHeightMap(nbtTagCompound.GetIntArray("HeightMap"));
            // chunk.Done = nbtTagCompound.GetBool("TerrainPopulated");
            // chunk.Light = nbtTagCompound.GetBool("LightPopulated");
            // chunk.InhabitedTime = nbtTagCompound.GetBool("InhabitedTime");
            // var nbtTagList = nbtTagCompound.GetList("Sections");
            // if (nbtTagList.Type != (byte) NBTType.Compound)
            //     return null;
            //
            // var chunkSections = new ChunkSection[16];
            // var hasSkyLight = world.Dimension == Dimention.OverWorld;
            // for (var i = 0; i < nbtTagList.Length; i++)
            // {
            //     var nbt = nbtTagList[i];
            //     if(nbt is not NBTTagCompound nbtChunkSection) continue;
            //     var yPos = nbtChunkSection.GetByte("Y");
            //     var chunkSection = new ChunkSection(yPos);
            //     
            //     var blockArray = nbtChunkSection.GetByteArray("Blocks");
            //     var subIdList = new NibbleArray(nbtChunkSection.GetByteArray("Data"));
            //     var nibbleArray1 = nbtChunkSection.HasKeyOfType("Add", NBTType.ByteArray) ? new NibbleArray(nbtChunkSection.GetByteArray("Add")) : null;
            //
            //     var charArray = new char[blockArray.Length];
            //     for (var k = 0; k < blockArray.Length; k++)
            //     {
            //         var x = k & 0xF;
            //         var y = k >> 8 & 0xF;
            //         var z = k >> 4 & 0xF;
            //
            //         var data = nibbleArray1 != null ? nibbleArray1[x, y, z] : 0;
            //         var id = blockArray[k] & 0xFF;
            //         var subId = subIdList[x, y, z];
            //         Bukkit.ConsoleSender.SendMessage(subId);
            //         // var packed = data << 12 | id << 4 | blockData;
            //     }
            // }

            return chunk;
        }
    }
}