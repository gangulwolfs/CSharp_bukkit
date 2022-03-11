using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFarmland : BlockData
    {
        public int Moisture { get; private set; }
        
        public BlockFarmland(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFarmland(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockFarmland) block).Moisture = properties.GetInt("moisture");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockFarmland o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockFarmland o) return false;

            return o1.Moisture == o.Moisture && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockFarmland o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockFarmland data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("moisture", new NBTTagString(Moisture.ToString()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Moisture;
    }
}