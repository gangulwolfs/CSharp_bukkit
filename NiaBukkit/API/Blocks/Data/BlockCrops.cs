using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockCrops : BlockPlant
    {
        public int Age { get; private set; }

        public BlockCrops(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockCrops(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockCrops) block).Age = properties.GetInt("age");
            return base.GetBlockData(block, properties);
        }
        
        internal override bool CanPlace(BlockPosition position)
        {
            return position.GetLightLevel() >= 8 && position.Down().GetBlockData().Type == Material.Farmland;
        }

        public static bool operator ==(BlockCrops o1, BlockData o2)
        {
            if (o1 is null || o2 is not BlockCrops o) return o1 is null && o2 is null;

            return o1.Age == o.Age && (BlockPlant) o1 == o;
        }

        public static bool operator !=(BlockCrops o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockCrops data) return false;
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