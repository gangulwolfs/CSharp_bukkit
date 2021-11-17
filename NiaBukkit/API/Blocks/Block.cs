using System.Collections.Generic;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks
{
    public class Block
    {
        private static readonly Dictionary<int, Block> LegacyMaterials = new ();
        private static readonly Dictionary<string, Block> Materials = new ();

        public Material Type { get; private set; }

        internal Block(Material type)
        {
            Type = type;
        }
        
        public static Block GetMaterialById(int id)
        {
            LegacyMaterials.TryGetValue(id, out var block);
            return block ?? Blocks.Air;
        }

        public static Block GetBlockByName(string name)
        {
            Materials.TryGetValue(name, out var block);
            return block ?? Blocks.Air;
        }
    }
}