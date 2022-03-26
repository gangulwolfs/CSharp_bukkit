using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockComposter : BlockData
    {
        public int Level { get; private set; }
        
        public BlockComposter(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockComposter(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockComposter) block).Level = properties.GetInt("level");
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockComposter o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockComposter o) return false;

            return o1.Level == o.Level && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockComposter o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockComposter data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("level", new NBTTagString(Level.ToString()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Level;
    }
}