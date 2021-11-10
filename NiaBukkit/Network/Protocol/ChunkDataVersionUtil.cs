using System;
using NiaBukkit.API.World.Chunks;

namespace NiaBukkit.Network.Protocol
{
    public class ChunkDataVersionUtil
    {
        internal static long[] ChunkCompactArray(int bitsPerBlock, Func<int, int> func)
        {
            long maxEntryValue = (1L << bitsPerBlock) - 1;
            long[] data = new long[ChunkSection.Size * bitsPerBlock / 64];

            for (var i = 0; i < ChunkSection.Size; i++)
            {
                int value = func.Invoke(i);
                int bitIndex = i * bitsPerBlock;
                int start = bitIndex / 64;
                int end = ((i + 1) * bitsPerBlock - 1) / 64;
                int startBitSub = bitIndex % 64;
                data[start] = data[start] & ~(maxEntryValue << startBitSub) | (value & maxEntryValue) << startBitSub;
                // data[startIndex] = data[startIndex] & (maxEntryValue << startBitSubIndex ^ 0xFFFFFFFFFFFFFFF) |
                //                    (value & maxEntryValue) << startBitSubIndex;
                if (start != end)
                {
                    int endBitSub = 64 - startBitSub;
                    int c = bitsPerBlock - endBitSub;
                    // data[endIndex] =
                    //     (long) ((ulong) data[endIndex] >> c) << c |
                    //     (value & maxEntryValue) >> endBitSubIndex;
                    data[end] =
                        data[end] >> endBitSub << endBitSub |
                        (value & maxEntryValue) >> endBitSub;
                }
            }

            return data;
        }
    }
}