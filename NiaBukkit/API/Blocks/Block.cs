using System.Collections.Generic;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks
{
    public class Block
    {
        private static Dictionary<int, Material> _materials = new ();
        public static Material GetMaterialById()
        {
            return Material.Air;
        }
    }
}