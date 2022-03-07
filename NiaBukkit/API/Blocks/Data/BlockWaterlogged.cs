using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockWaterlogged : BlockData
    {
        public bool Waterlogged { get; private set; }
        internal BlockWaterlogged(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockWaterlogged(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockWaterlogged) block).Waterlogged = bool.Parse(properties.GetString("waterlogged"));
            return base.GetBlockData(block, properties);
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            tag.GetCompound("Properties").Set("waterlogged", new NBTTagString(Waterlogged.ToString().ToLower()));
            
            return tag;
        }

        public override string ToString()
        {
            return ToNBT().ToString();
        }
    }
}