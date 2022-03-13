using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockFurnace : BlockData
    {
        public bool Lit { get; private set; }
        public Direction Facing { get; private set; }
        
        public BlockFurnace(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockFurnace(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockFurnace) block;
            o.Lit = properties.GetBool("lit");
            o.Facing = properties.GetState(Direction.North);
            
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockFurnace o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockFurnace o) return false;

            return o1.Lit == o.Lit && o1.Facing == o.Facing && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockFurnace o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockFurnace data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("lit", new NBTTagString(Lit.ToString().ToLower()));
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId() => Type.GetBlockId() + Lit.ToInt() << 4 | Type.GetMetaData() | Facing.GetMetaNSWE() + 2;
    }
}