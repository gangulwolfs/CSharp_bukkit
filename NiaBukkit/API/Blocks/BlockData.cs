using System;
using System.Collections.Generic;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Sounds;
using NiaBukkit.API.Util;

namespace NiaBukkit.API.Blocks
{
    public class BlockData
    {
        internal static readonly Dictionary<int, BlockData> LegacyMaterials = new ();
        internal static readonly Dictionary<string, BlockData> Materials = new ();

        public Material Type { get; private set; }
        public float Speed { get; private set; }
        public float Durability { get; private set; }

        public SoundEffectType SoundEffectType { get; private set; }

        internal BlockData(Material type)
        {
            Type = type;
        }

        public static BlockData GetBlockDataById(int id, byte subId = 0)
        {
            LegacyMaterials.TryGetValue(id << 4 | subId, out var block);
            return block ?? BlockFactory.Air;
        }

        public static BlockData GetBlockDataByName(string name)
        {
            if (!name.StartsWith("minecraft:"))
                name = $"minecraft:{name}";
            Materials.TryGetValue(name, out var block);
            return block ?? BlockFactory.Air;
        }

        internal BlockData SetBlockData(float speed, float durability)
        {
            Speed = speed;
            Durability = Math.Max(0, durability);

            return this;
        }

        internal BlockData SetDurability(float durability)
        {
            return SetBlockData(durability, durability);
        }

        internal BlockData SetSound(SoundEffectType soundEffectType)
        {
            SoundEffectType = soundEffectType;
            return this;
        }

        internal virtual void Update(BlockPosition position)
        {
        }

        internal virtual BlockData GetBlockData(NBTTagCompound properties)
        {
            return new BlockData(Type).SetBlockData(Speed, Durability).SetSound(SoundEffectType);
        }

        internal BlockData GetBlockData(BlockData blockData)
        {
            return blockData.SetBlockData(Speed, Durability).SetSound(SoundEffectType);
        }
    }
}