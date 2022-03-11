using System;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks.Data
{
    public class BlockBeetroot : BlockCrops
    {
        public BlockBeetroot(Material type) : base(type)
        {
        }

        internal override void Update(BlockPosition position, Random random)
        {
            if(random.Next(3) != 0)
                base.Update(position, random);
        }
    }
}