using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockWeightPressurePlate : BlockData
    {
        public int Power { get; private set; }
        public int Weight { get; private set; }
        
        public BlockWeightPressurePlate(int weight, Material type) : base(type)
        {
            Weight = weight;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockWeightPressurePlate(Weight, Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockWeightPressurePlate) block).Power = properties.GetInt("power");
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockWeightPressurePlate o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockWeightPressurePlate o) return false;

            return o1.Power == o.Power && o1.Weight == o.Weight && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockWeightPressurePlate o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockWeightPressurePlate data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("power", new NBTTagString(Power.ToString()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Power;
    }
}