using NiaBukkit.API.NBT;
using NiaBukkit.API.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiaBukkit.API.Blocks.Data
{
    class BlockWetSponge : BlockData
    {
        internal BlockWetSponge(Material type) : base(type)
        {
        }

        internal override BlockData GetBlockData(NBTTagCompound properties)
        {
            return GetBlockData(new BlockWetSponge(Type), properties);
        }

        public static bool operator ==(BlockWetSponge o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            if (o2 is not BlockWetSponge o) return false;
            return (BlockData)o1 == o;
        }

        public static bool operator !=(BlockWetSponge o1, BlockData o2) => !(o1 == o2);

        public override bool Equals(object obj)
        {
            if (obj is not BlockWetSponge data) return false;
            return this == data;
        }
    }
}
