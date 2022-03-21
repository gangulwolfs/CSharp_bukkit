using System;
using System.IO;
using System.IO.Compression;

namespace NiaBukkit.API.Compress
{
    public class ZLibStream : DeflateStream
    {

        public ZLibStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen = false) : base(stream, compressionLevel, leaveOpen)
        {
            stream.Write(compressionLevel switch
            {
                CompressionLevel.Fastest => new byte[] { 120, 1 },
                CompressionLevel.Optimal => new byte[] { 120, 218 },
                _ => Array.Empty<byte>()
            });
        }

        public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen = false) : base(stream, mode, leaveOpen)
        {
            if (mode == CompressionMode.Decompress)
            {
                stream.Position += 2;
                return;
            }

            stream.Write(new byte[] { 120, 218 });
        }
    }
}