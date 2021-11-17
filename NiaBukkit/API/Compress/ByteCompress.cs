using System.IO;
using CompressionLevel = System.IO.Compression.CompressionLevel;
using CompressionMode = System.IO.Compression.CompressionMode;
using GZipStream = System.IO.Compression.GZipStream;

namespace NiaBukkit.API.Compress
{
    public static class ByteCompress
    {
        public static byte[] ZLipCompress(byte[] origin)
        {
            using var stream = new MemoryStream();
            using var zipStream = new ZLibStream(stream, CompressionLevel.Optimal);
            zipStream.Write(origin, 0, origin.Length);
            zipStream.Flush();
            
            return stream.ToArray();
        }
        
        public static byte[] ZLipDecompress(byte[] origin)
        {
            using var stream = new MemoryStream(origin);
            stream.Position = 2;
            
            using var zipStream = new System.IO.Compression.DeflateStream(stream, CompressionMode.Decompress);
            // using var zipStream = new Ionic.Zlib.ZlibStream(stream, Ionic.Zlib.CompressionMode.Decompress);
            using var resultStream = new MemoryStream();
            zipStream.CopyTo(resultStream);

            return resultStream.ToArray();
        }
        
        public static byte[] GZipCompress(byte[] origin)
        {
            using var stream = new MemoryStream();
            using var zipStream = new GZipStream(stream, CompressionMode.Compress);
            zipStream.Write(origin, 0, origin.Length);
            zipStream.Flush();

            return stream.ToArray();
        }
        
        public static byte[] GZipDecompress(byte[] origin)
        {
            using var stream = new MemoryStream(origin);
            
            using var zipStream = new GZipStream(stream, CompressionMode.Decompress);
            using var resultStream = new MemoryStream();
            zipStream.CopyTo(resultStream);
            
            return resultStream.ToArray();
        }
    }
}