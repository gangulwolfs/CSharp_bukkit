using System.Collections.Generic;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks
{
    public class BlockData
    {
        internal static readonly Dictionary<int, BlockData> LegacyMaterials = new ();
        internal static readonly Dictionary<string, BlockData> Materials = new ();

        public Material Type { get; private set; }

        internal BlockData(Material type)
        {
            Type = type;
        }
        
        public static BlockData GetMaterialById(int id)
        {
            LegacyMaterials.TryGetValue(id, out var block);
            return block ?? BlockFactory.Air;
        }

        public static BlockData GetBlockByName(string name)
        {
            Materials.TryGetValue(name, out var block);
            return block ?? BlockFactory.Air;
        }
    }
}