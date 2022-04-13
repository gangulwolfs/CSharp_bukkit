using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockTrapdoor : BlockWaterlogged
    {
        public Direction Facing { get; private set; }
        public PropertyHalf Half { get; private set; }
        public bool Open { get; private set; }
        public bool Powered { get; private set; }
        
        public BlockTrapdoor(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockTrapdoor(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockTrapdoor) block;
            o.Facing = properties.GetState(Direction.North);
            o.Half = properties.GetState(PropertyHalf.Bottom);
            o.Open = properties.GetBool("open");
            o.Powered = properties.GetBool("powered");
            
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("facing", new NBTTagString(Facing.ToString().Name2Minecraft()));
            properties.Set("half", new NBTTagString(Half.ToString().Name2Minecraft()));
            properties.Set("open", new NBTTagString(Open.ToString().ToLower()));
            properties.Set("powered", new NBTTagString(Powered.ToString().ToLower()));
            
            return tag;
        }
        
        public static bool operator ==(BlockTrapdoor o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            
            if (o2 is not BlockTrapdoor o) return false;
            return o1.Facing == o.Facing && o1.Half == o.Half && o1.Open == o.Open && o1.Powered == o.Powered && (BlockWaterlogged) o1 == o;
        }

        public static bool operator !=(BlockTrapdoor o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            return obj is BlockTrapdoor data && this == data;
        }

        public override int GetFlatId() =>
            base.GetFlatId() | Half.GetMeta() << 3 | Open.ToInt() << 2 | Facing.GetMetaNSWE();
    }
}