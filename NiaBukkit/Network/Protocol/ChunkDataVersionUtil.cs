﻿//ViaVersion CompactArrayUtil

using System;
using System.Collections;
using NiaBukkit.API;
using NiaBukkit.API.Util;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.Network.Protocol
{
    public static class ChunkDataVersionUtil
    {
        private static readonly int[] Magic =
        {
            -1, -1, 0, int.MinValue, 0, 0, 1431655765, 1431655765, 0, int.MinValue,
            0, 1, 858993459, 858993459, 0, 715827882, 715827882, 0, 613566756, 613566756,
            0, int.MinValue, 0, 2, 477218588, 477218588, 0, 429496729, 429496729, 0,
            390451572, 390451572, 0, 357913941, 357913941, 0, 330382099, 330382099, 0, 306783378,
            306783378, 0, 286331153, 286331153, 0, int.MinValue, 0, 3, 252645135, 252645135,
            0, 238609294, 238609294, 0, 226050910, 226050910, 0, 214748364, 214748364, 0,
            204522252, 204522252, 0, 195225786, 195225786, 0, 186737708, 186737708, 0, 178956970,
            178956970, 0, 171798691, 171798691, 0, 165191049, 165191049, 0, 159072862, 159072862,
            0, 153391689, 153391689, 0, 148102320, 148102320, 0, 143165576, 143165576, 0,
            138547332, 138547332, 0, int.MinValue, 0, 4, 130150524, 130150524, 0, 126322567,
            126322567, 0, 122713351, 122713351, 0, 119304647, 119304647, 0, 116080197, 116080197,
            0, 113025455, 113025455, 0, 110127366, 110127366, 0, 107374182, 107374182, 0,
            104755299, 104755299, 0, 102261126, 102261126, 0, 99882960, 99882960, 0, 97612893,
            97612893, 0, 95443717, 95443717, 0, 93368854, 93368854, 0, 91382282, 91382282,
            0, 89478485, 89478485, 0, 87652393, 87652393, 0, 85899345, 85899345, 0,
            84215045, 84215045, 0, 82595524, 82595524, 0, 81037118, 81037118, 0, 79536431,
            79536431, 0, 78090314, 78090314, 0, 76695844, 76695844, 0, 75350303, 75350303,
            0, 74051160, 74051160, 0, 72796055, 72796055, 0, 71582788, 71582788, 0,
            70409299, 70409299, 0, 69273666, 69273666, 0, 68174084, 68174084, 0, int.MinValue,
            70409299, 70409299, 0, 69273666, 69273666, 0, 68174084, 68174084, 0, int.MinValue,
            0, 5
        };

        internal static long[] CreateCompactArray(int bitsPerBlock, Func<int, int> func)
        {
            var maxEntryValue = (1L << bitsPerBlock) - 1;
            var data = new long[ChunkSection.Size * bitsPerBlock / 64];

            for (var i = 0; i < ChunkSection.Size; i++)
            {
                var value = func.Invoke(i);
                var bitIndex = i * bitsPerBlock;
                var start = bitIndex / 64;
                var end = (bitIndex + bitsPerBlock - 1) / 64;
                var startBitSub = bitIndex % 64;
                data[start] = data[start] & ~(maxEntryValue << startBitSub) | (value & maxEntryValue) << startBitSub;
                if (start == end) continue;
                var endBitSub = 64 - startBitSub;
                data[end] =
                    data[end] >> endBitSub << endBitSub |
                    (value & maxEntryValue) >> endBitSub;
            }

            return data;
        }

        internal static void CreateCompactArray(ByteBuf buf, int bitsPerBlock, Func<int, int> func)
        {
            ulong buffer = 0;
            var bitIndex = 0;
            buf.WriteVarInt(ChunkSection.Size * bitsPerBlock / 64);

            for (var i = 0; i < ChunkSection.Size; i++)
            {
                var value = func.Invoke(i);
                buffer |= (ulong) (uint) value << bitIndex;
                var remaining = bitsPerBlock - (64 - bitIndex);
                if (remaining >= 0)
                {
                    buf.WriteULong(buffer);
                    buffer = (ulong) (value >> (bitsPerBlock - remaining));
                    bitIndex = remaining;
                }
                else
                    bitIndex += bitsPerBlock;
            }
            
            if(bitIndex > 0)
                buf.WriteULong(buffer);
        }

        internal static void IterateCompactArray(int bitsPerBlock, long[] data, Action<int, int> action)
        {
            var maxEntryValue = (1L << bitsPerBlock) - 1;
            for (var i = 0; i < ChunkSection.Size; i++) {
                var bitIndex = i * bitsPerBlock;
                var start = bitIndex / 64;
                var end = (bitIndex + bitsPerBlock - 1) / 64;
                var startBitSub = bitIndex % 64;
                int value;
                if (start == end) {
                    value = (int) ((data[start] >> startBitSub) & maxEntryValue);
                } else {
                    var endBitSubIndex = 64 - startBitSub;
                    value = (int) (((data[start] >> startBitSub) | (data[end] << endBitSubIndex)) & maxEntryValue);
                }
                action.Invoke(i, value);
            }
        }

        internal static void IterateCompactArrayWithPadding(int bitsPerEntry, long[] data, Action<int, int> action)
        {
            var maxEntryValue = (1L << bitsPerEntry) - 1;
            var valuesPerLong = (char) (64 / bitsPerEntry);
            
            var magicIndex = 3 * (valuesPerLong - 1);
            
            long divideMul = (uint) Magic[magicIndex]; // msb
            long divideAdd = (uint) Magic[magicIndex + 1];
            var divideShift = Magic[magicIndex + 2];

            for (var i = 0; i < ChunkSection.Size; i++)
            {
                var cellIndex = (int) (i * divideMul + divideAdd >> 32 >> divideShift);
                
                var bitIndex = (i - cellIndex * valuesPerLong) * bitsPerEntry;
                var value = (int) (data[cellIndex] >> bitIndex & maxEntryValue);
                
                action.Invoke(i, value);
            }
        }

        public static byte GetBitsPerBlock(int paletteSize, byte max)
        {
            byte bitsPerBlock = 4;
            while (paletteSize > 1 << bitsPerBlock)
                bitsPerBlock++;

            if (bitsPerBlock > 8)
                bitsPerBlock = max;

            return bitsPerBlock;
        }
    }
}