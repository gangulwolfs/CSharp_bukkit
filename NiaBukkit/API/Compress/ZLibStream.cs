using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace NiaBukkit.API.Compress
{
    public class ZLibStream : DeflateStream
    {
        private readonly Stream _stream;
        private readonly CompressionLevel _level;
        private int _adler32A = 1, _adler32B;

        private const int FootModulus = 65521;

        private byte[] Footer {
            get {
                byte[] data = BitConverter.GetBytes(_adler32B * 65536 + _adler32A);
                (data[0], data[3]) = (data[3], data[0]);
                (data[1], data[2]) = (data[2], data[1]);

                return data;
            }
        }


        private void Update(IList<byte> data, int offset, int length) {
            for(var i = 0; i < length; i++) {
                _adler32A = (_adler32A + data[offset + i]) % FootModulus;
                _adler32B = (_adler32B + _adler32A) % FootModulus;
            }
        }

        public override void Write(byte[] array, int offset, int count) {
            Update(array, offset, count);
            base.Write( array, offset, count );
        }

        public override void Flush()
        {
            _stream.Write(_level switch
            {
                CompressionLevel.Fastest => new byte[]{ 120, 1 },
                CompressionLevel.Optimal => new byte[]{ 120, 218 },
                _ => Array.Empty<byte>()
            });
            base.Flush();
            _stream.Write(Footer);
        }

        public ZLibStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen = false) : base(stream, compressionLevel, leaveOpen)
        {
            _level = compressionLevel;
            _stream = stream;
        }

        public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen = false) : base(stream, mode, leaveOpen)
        {
            _level = CompressionLevel.Optimal;
            _stream = stream;
        }
    }
}