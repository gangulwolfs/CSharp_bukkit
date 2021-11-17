using System.IO;
using NiaBukkit.API.Compress;
using NiaBukkit.Network;

namespace NiaBukkit.API.World.Chunks
{
    public static class RegionFile
    {
        public static ByteBuf Load(string path, int x, int z)
        {
            if (!File.Exists(path)) return null;
            
            var buf = new ByteBuf(File.ReadAllBytes(path));
            
            var byteInfo = new int[1024];
            for (var i = 0; i < 1024; i++)
                byteInfo[i] = buf.ReadInt();

            x &= 0x1F;
            z &= 0x1F;

            var id = byteInfo[x + z * 32];
            if (id == 0)
                return null;

            var chunkPos = id >> 8;
            
            buf.Position = chunkPos * 4096;
            var size = buf.ReadInt();
            
            if (size <= 0 || size > 4096 * (id & 0xFF))
                return null;

            var originData = (ChunkCompressType) buf.ReadByte() switch
            {
                ChunkCompressType.GZip => ByteCompress.GZipDecompress(buf.Read(size - 1)),
                ChunkCompressType.ZLip => ByteCompress.ZLipDecompress(buf.Read(size - 1)),
                ChunkCompressType.UnCompress => buf.Read(size - 1),
                _ => null
            };

            return originData == null ? null : new ByteBuf(originData);
        }
    }
}