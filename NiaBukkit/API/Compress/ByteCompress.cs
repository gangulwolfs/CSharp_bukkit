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
            using var ms = new MemoryStream();
            using var zipStream = new ZLibStream(ms, CompressionLevel.Optimal);
            zipStream.Write(origin, 0, origin.Length);
            zipStream.Flush();
            
            return ms.ToArray();
        }
        
        public static byte[] ZLipDecompress(byte[] origin)
        {
            using var ms = new MemoryStream(origin);
            //ZLib head : 2 bytes
            ms.Position = 2;
            
            using var zip = new System.IO.Compression.DeflateStream(ms, CompressionMode.Decompress);
            //zipStream.Write(origin, 2, origin.Length - 2);
            //zipStream.Close();
            using var rs = new MemoryStream();
            zip.CopyTo(rs);

            return rs.ToArray();
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
            using var ms = new MemoryStream(origin);
            
            using var zipStream = new GZipStream(ms, CompressionMode.Decompress);
            
            return ms.ToArray();
        }
    }
}