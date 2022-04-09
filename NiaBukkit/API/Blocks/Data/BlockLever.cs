using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockLever : BlockData
    {
        //Properties=NBTTagCompound(face="ceiling", powered="false", facing="east")
        public PropertyAttachPosition Face { get; private set; }
        public bool Powered { get; private set; }
        public Direction Facing { get; private set; }
        
        public BlockLever(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockLever(Type), properties);
        }

        internal override BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            var o = (BlockLever)block;
            o.Face = properties.GetState(PropertyAttachPosition.Ceiling);
            o.Powered = properties.GetBool("powered");
            o.Facing = properties.GetState(Direction.Down);
            return base.GetBlockData(block, properties);
        }

        public static bool operator ==(BlockLever o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockLever o) return false;

            return o1.Face == o.Face && o1.Powered == o.Powered && o1.Facing == o.Facing && (BlockData)o1 == o;
        }

        public static bool operator !=(BlockLever o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockLever data) return false;
            return this == data;
        }

        public override NBTTagCompound ToNBT()
        {
            var tag = base.ToNBT();
            var properties = tag.GetOrCreateCompound("Properties");
            properties.Set("face", new NBTTagString(Face.ToString().Name2Minecraft()));
            properties.Set("powered", new NBTTagString(Powered.ToString()));
            properties.Set("facing", new NBTTagString(Facing.ToString().Name2Minecraft()));

            return tag;
        }
        public override int GetFlatId()
        {
            var baseId = base.GetFlatId() | Powered.ToInt() << 3;
            switch (Face)
            {
                case PropertyAttachPosition.Ceiling:
                    switch (Facing)
                    {
                        case Direction.South: case Direction.North:
                            baseId |= 7;
                            break;
                    }
                    break;
                case PropertyAttachPosition.Wall:
                    baseId |= Facing.GetMetaEWSN() + 1;
                    break;
                case PropertyAttachPosition.Floor:
                    switch (Facing)
                    {
                        case Direction.South: case Direction.North:
                            baseId |= 5;
                            break;
                        case Direction.East: case Direction.West:
                            baseId |= 6;
                            break;
                    }
                    break;
                    
            }
            return baseId;
        }
    }
}