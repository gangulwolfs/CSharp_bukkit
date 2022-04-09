using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockSugarCane : BlockData
    {
        public int Age { get; private set; }

        public BlockSugarCane(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockSugarCane(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockSugarCane) block).Age = properties.GetInt("age");
            return base.GetBlockData(block, properties);
        }
        
        internal override bool CanPlace(BlockPosition position)
        {
            var down = position.Down();
            switch (down.GetBlockData().Type)
            {
                case Material.SugarCane:
                    return true;
                case Material.GrassBlock: case Material.Dirt: case Material.CoarseDirt: case Material.Podzol: case Material.Sand: case Material.RedSand:
                    foreach (var block in down.GetBesideBlocks())
                    {
                        if(block.GetBlockData().Type is Material.Water or Material.FrostedIce)
                            return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public static bool operator ==(BlockSugarCane o1, BlockData o2)
        {
            if (o1 is null || o2 is not BlockSugarCane o) return o1 is null && o2 is null;

            return o1.Age == o.Age && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockSugarCane o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockSugarCane data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("age", new NBTTagString(Age.ToString()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Age;
    }
}