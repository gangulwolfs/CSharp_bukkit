using System.IO;
using System.IO.Compression;

namespace NiaBukkit.API.Util
{
    public class ByteCompress
    {
        public static byte[] Compress(byte[] origin)
        {
            MemoryStream stream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(stream, CompressionMode.Compress);
            zipStream.Write(origin, 0, origin.Length);
            zipStream.Close();
            zipStream.DisposeAsync();

            byte[] result = stream.ToArray();
            stream.DisposeAsync();

            return result;
        }
        
        public static byte[] Decompress(byte[] origin)
        {
            MemoryStream stream = new MemoryStream(origin);
            DeflateStream zipStream = new DeflateStream(stream, CompressionMode.Decompress);
            MemoryStream resultStream = new MemoryStream();
            zipStream.CopyTo(resultStream);
            zipStream.Close();
            zipStream.DisposeAsync();
            stream.DisposeAsync();

            byte[] result = resultStream.ToArray();
            resultStream.DisposeAsync();
            return result;
        }
    }
}