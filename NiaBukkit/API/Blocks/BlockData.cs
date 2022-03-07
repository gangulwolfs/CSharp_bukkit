using System;
using System.Collections.Generic;
using NiaBukkit.API.NBT;
using NiaBukkit.API.Sounds;
using NiaBukkit.API.Util;
using NiaBukkit.Network;

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
        
        public int BlockLight { get; private set; }

        internal BlockData(Material type)
        {
            Type = type;
        }

        internal void SetBlockData(BlockData data)
        {
            Speed = data.Speed;
            Durability = data.Durability;
            SoundEffectType = data.SoundEffectType;
        }

        public static BlockData GetBlockDataById(int id, byte subId = 0)
        {
            LegacyMaterials.TryGetValue(id << 4 | subId, out var block);
            return block ?? BlockFactory.Air;
        }

        public static BlockData GetBlockDataByName(string name)
        {
            if (!name.StartsWith(MinecraftServer.MinecraftKey))
                name = $"{MinecraftServer.MinecraftKey}{name}";
            Materials.TryGetValue(name, out var block);
            return block ?? BlockFactory.Air;
        }

        internal BlockData SetBreakData(float speed, float durability)
        {
            Speed = speed;
            Durability = Math.Max(0, durability);

            return this;
        }

        internal BlockData SetDurability(float durability)
        {
            return SetBreakData(durability, durability);
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
            return GetBlockData(new BlockData(Type), properties);
        }

        internal virtual BlockData GetBlockData(BlockData block, NBTTagCompound properties)
        {
            return block.SetBreakData(Speed, Durability).SetSound(SoundEffectType);
        }

        internal BlockData GetBlockData(BlockData blockData)
        {
            return blockData.SetBreakData(Speed, Durability).SetSound(SoundEffectType);
        }

        internal BlockData SetLight(int blockLight)
        {
            BlockLight = blockLight;
            return this;
        }

        public static bool operator ==(BlockData o1, BlockData o2)
        {
            if (o1 is null || o2 is null) return o1 is null && o2 is null;
            return o1.Type == o2.Type;
        }

        public static bool operator !=(BlockData o1, BlockData o2) => !(o1 == o2);

        public virtual NBTTagCompound ToNBT()
        {
            var tag = new NBTTagCompound();
            tag.Set("Name", new NBTTagString($"{MinecraftServer.MinecraftKey}{Type.GetName()}"));
            
            return tag;
        }

        public override string ToString()
        {
            return ToNBT().ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is not BlockData data) return false;

            return data == this;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) Type, Speed, Durability, SoundEffectType, BlockLight);
        }
    }
}