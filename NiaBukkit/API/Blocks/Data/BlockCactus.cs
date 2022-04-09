using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockCactus : BlockData
    {
        public int Age { get; private set; }

        public BlockCactus(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockCactus(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockCactus) block).Age = properties.GetInt("age");
            return base.GetBlockData(block, properties);
        }
        
        internal override bool CanPlace(BlockPosition position)
        {
            return position.Down().GetBlockData().Type is Material.Cactus or Material.Sand or Material.RedSand &&
                   !position.Up().GetBlockData().Type.IsLiquid();
        }

        public static bool operator ==(BlockCactus o1, BlockData o2)
        {
            if (o1 is null || o2 is not BlockCactus o) return o1 is null && o2 is null;

            return o1.Age == o.Age && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockCactus o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockCactus data) return false;
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