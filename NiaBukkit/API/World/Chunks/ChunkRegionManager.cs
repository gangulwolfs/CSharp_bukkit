using System;
using NiaBukkit.API.Blocks;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;
using NiaBukkit.Network.Protocol;

namespace NiaBukkit.API.World.Chunks
{
    public class ChunkRegionManager
    {
        private const byte MaxBitsBlock = 15;
        
        internal static Chunk GetChunk(World world, int x, int z)
        {
            var buf = RegionFile.Load($"D:/마인크래프트/1.16.5/world_b/region/r.{x >> 5}.{z >> 5}.mca", x, z);
            // var buf = RegionFile.Load($"C:/Users/skyne/AppData/Roaming/.minecraft/saves/New World-/region/r.{x >> 5}.{z >> 5}.mca", x, z);
            if (buf == null)
                return null;

            var nbt = NBTBase.CreateTag((byte) buf.ReadByte());
            
            if (nbt is not NBTTagCompound nbtTagCompound)
                return null;
            buf.ReadUtf();
            try
            {
                nbt.Load(buf, 0);
                return GetChunk(world, x, z, nbtTagCompound);
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
            var nbtLevelCompound = nbtTagCompound.GetCompound("Level");
            if (posX != nbtLevelCompound.GetInt("xPos") || posZ != nbtLevelCompound.GetInt("zPos"))
                throw new Exception($"Chunk file at {new ChunkCoord(world, posX, posZ)} is in the wrong location;");


            var chunk = new Chunk(world, posX, posZ);
            // chunk.Done = nbtTagCompound.GetBool("TerrainPopulated");
            // chunk.SetHeightMap(nbtTagCompound.GetIntArray("HeightMap"));
            var hasLight = nbtLevelCompound.GetBool(nbtLevelCompound.HasKey("isLightOn") ? "isLightOn" : "LightPopulated");

            // chunk.InhabitedTime = nbtTagCompound.GetBool("InhabitedTime");
            var nbtTagList = nbtLevelCompound.GetList("Sections");
            if (nbtTagList.Type != (byte) NBTType.Compound)
                return null;
            
            var chunkSections = new ChunkSection[16];
            var hasSkyLight = world.Dimension == Dimention.OverWorld;
            for (var i = 0; i < nbtTagList.Length; i++)
            {
                var nbt = nbtTagList[i];
                if(nbt is not NBTTagCompound nbtChunkSection) continue;
                
                var yPos = nbtChunkSection.GetByte("Y");
                ChunkSection section = null;
                if (nbtChunkSection.HasKeyOfType("Palette", NBTType.List) &&
                    nbtChunkSection.HasKeyOfType("BlockStates", NBTType.LongArray))
                    section = LoadChunkSectionPalette((byte) (yPos << 4), nbtChunkSection);
                
                else if (nbtChunkSection.HasKeyOfType("Blocks", NBTType.ByteArray) &&
                         nbtChunkSection.HasKeyOfType("Data", NBTType.ByteArray))
                    section = LoadChunkSectionBlock((byte) (yPos << 4), nbtChunkSection);
                
                if(section == null) continue;
                if (hasLight)
                {
                    if(nbtChunkSection.HasKeyOfType("BlockLight", NBTType.ByteArray))
                        section.SetBlockLight(nbtChunkSection.GetByteArray("BlockLight"));
            
                    if(hasSkyLight && nbtChunkSection.HasKeyOfType("SkyLight", NBTType.ByteArray))
                        section.SetSkyLight(nbtChunkSection.GetByteArray("SkyLight"));
                }

                chunkSections[yPos] = section;
            }

            chunk.SetChunkSections(chunkSections);

            return chunk;
        }

        private static ChunkSection LoadChunkSectionPalette(byte yPos, NBTTagCompound nbtTagCompound)
        {
            var paletteList = nbtTagCompound.GetList("Palette");
            if (paletteList.Length == 1) return null;
            var blockStateList = nbtTagCompound.GetLongArray("BlockStates");

            var section = new ChunkSection(yPos);
            
            var bits = blockStateList.Length * 64 / ChunkSection.Size;

            for (var i = 0; i < paletteList.Length; i++)
            {
                if(paletteList[i] is not NBTTagCompound paletteCompound) continue;
                var T = section.GetOrCreatePaletteIndex(BlockData.GetBlockDataByName(paletteCompound.GetString("Name"))
                    .GetBlockData(paletteCompound.GetCompound("Properties")));

                Bukkit.ConsoleSender.SendMessage(paletteCompound);
                Bukkit.ConsoleSender.SendMessage(T + ": " + BlockData
                    .GetBlockDataByName(paletteCompound.GetString("Name"))
                    .GetBlockData(paletteCompound.GetCompound("Properties")));
            }

            ChunkDataVersionUtil.IterateCompactArrayWithPadding(bits, blockStateList, section.SetBlock);

            if (yPos == 64)
            {
                // Bukkit.ConsoleSender.SendMessage(Convert.ToString(blockStateList[0], 2));
                
                // for(var i = 0; i < 16 * 16; i++)
                //     Bukkit.ConsoleSender.SendMessage(section.GetBlock(i));
            }
            
            return section;
        }

        private static ChunkSection LoadChunkSectionBlock(byte yPos, NBTTagCompound nbtTagCompound)
        {
            var section = new ChunkSection(yPos);
            
            var blockArray = nbtTagCompound.GetByteArray("Blocks");
            var subIdList = new NibbleArray(nbtTagCompound.GetByteArray("Data"));
            
            //what's this?
            var nibbleArray1 = nbtTagCompound.HasKeyOfType("Add", NBTType.ByteArray)
                ? new NibbleArray(nbtTagCompound.GetByteArray("Add"))
                : null;
            
            for (var k = 0; k < blockArray.Length; k++)
            {
                var x = k & 0xF;
                var y = k >> 8 & 0xF;
                var z = k >> 4 & 0xF;
            
                var data = nibbleArray1 != null ? nibbleArray1[x, y, z] : 0;
                var id = blockArray[k] & 0xFF;
                var subId = subIdList[x, y, z];
                
                // Bukkit.ConsoleSender.SendMessage(BlockData.GetBlockDataById(id, subId).Type);
                section.SetBlock(x, y, z, BlockData.GetBlockDataById(id, subId).Type);
                // var packed = data << 12 | id << 4 | blockData;
            }
            

            return section;
                
            // var blockArray = nbtChunkSection.GetByteArray("Blocks");
            // var subIdList = new NibbleArray(nbtChunkSection.GetByteArray("Data"));
            // var nibbleArray1 = nbtChunkSection.HasKeyOfType("Add", NBTType.ByteArray) ? new NibbleArray(nbtChunkSection.GetByteArray("Add")) : null;
            //
            // var charArray = new char[blockArray.Length];
            // for (var k = 0; k < blockArray.Length; k++)
            // {
            //     var x = k & 0xF;
            //     var y = k >> 8 & 0xF;
            //     var z = k >> 4 & 0xF;
            //
            //     var data = nibbleArray1 != null ? nibbleArray1[x, y, z] : 0;
            //     var id = blockArray[k] & 0xFF;
            //     var subId = subIdList[x, y, z];
            //     Bukkit.ConsoleSender.SendMessage(subId);
            //     // var packed = data << 12 | id << 4 | blockData;
            // }
        }
    }
}