using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockChest : BlockWaterlogged
    {
        //Properties=NBTTagCompound(waterlogged="false", facing="north", type="single")
        public Direction Facing { get; private set; }
        public PropertyChestType ChestType { get; private set; }
        
        public BlockChest(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockChest(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockChest) block).Facing = properties.GetState(Direction.East);
            ((BlockChest) block).ChestType = properties.GetState(PropertyChestType.Single);
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockChest o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockChest o) return false;

            return o1.Facing == o.Facing && o1.ChestType == o.ChestType && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockChest o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockChest data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().ToLower()));
            properties.Set("type", new NBTTagString(ChestType.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Facing.GetMetaNSWE() + 2;
    }
}