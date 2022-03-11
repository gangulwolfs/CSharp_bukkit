using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockBell : BlockData
    {
        public PropertyBellAttach Attachment { get; private set; }
        public bool Powered { get; private set; }
        public Direction Facing { get; private set; }

        public BlockBell(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockBell(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockBell) block;
            o.Attachment = properties.GetState(PropertyBellAttach.Floor);
            o.Powered = properties.GetBool("powered");
            o.Facing = properties.GetState(Direction.East);
            
            return base.GetBlockData(block, properties);
        }

        internal override bool CanPlace(BlockPosition position)
        {
            return !position.Down().GetBlockData().Type.IsTransparent();
        }

        public static bool operator ==(BlockBell o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockBell o) return false;

            return o1.Attachment == o.Attachment && o1.Powered == o.Powered && o1.Facing == o.Facing && (BlockData) o1 == o;
        }

        public static bool operator !=(BlockBell o1, BlockData o2) => !(o1 == o2);
        
        public override bool Equals(object obj)
        {
            if (obj is not BlockBell data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("attachment", new NBTTagString(Attachment.ToString()));
            properties.Set("powered", new NBTTagString(Powered.ToString()));
            properties.Set("facing", new NBTTagString(Facing.ToString()));
            
            return tag;
        }

        //TODO: Flat Id
        public override int GetFlatId() => base.GetFlatId();
    }
}