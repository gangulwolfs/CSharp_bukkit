using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockPressurePlate : BlockData
    {
        public EnumMobType MobType { get; private set; }
        public bool Powered { get; private set; }
        
        public BlockPressurePlate(EnumMobType mobType, Material type) : base(type)
        {
            MobType = mobType;
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockPressurePlate(MobType, Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            ((BlockPressurePlate) block).Powered = properties.GetBool("powered");
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockPressurePlate o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockPressurePlate o) return false;

            return o1.Powered == o.Powered && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockPressurePlate o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockPressurePlate data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("powered", new NBTTagString(Powered.ToString().ToLower()));
            
            return tag;
        }

        public override int GetFlatId() => base.GetFlatId() | Powered.ToInt();
        
        public enum EnumMobType
        {
            EveryThing,
            Mobs
        }
    }
}