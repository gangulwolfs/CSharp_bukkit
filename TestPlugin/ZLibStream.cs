using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace NiaBukkit.API.Compress
{
    public class ZLibStream : Stream
    {
        private readonly Stream _stream;
        private readonly MemoryStream _ms = new();
        private readonly DeflateStream _deflateSream;
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

        public override bool CanRead => _deflateSream.CanRead;

        public override bool CanSeek => _deflateSream.CanSeek;

        public override bool CanWrite => _deflateSream.CanWrite;

        public override long Length => _deflateSream.Length;

        public override long Position { get => _deflateSream.Position; set => _deflateSream.Position = value; }

        private void Update(IList<byte> data, int offset, int length) {
            for(var i = 0; i < length; i++) {
                _adler32A = (_adler32A + data[offset + i]) % FootModulus;
                _adler32B = (_adler32B + _adler32A) % FootModulus;
            }
        }

        public override void Write(byte[] array, int offset, int count) {
            Update(array, offset, count);
            _deflateSream.Write(array, offset, count);
        }

        public override void Flush()
        {
            _deflateSream.Flush();

            _stream.Write(_level switch
            {
                CompressionLevel.Fastest => new byte[]{ 120, 1 },
                CompressionLevel.Optimal => new byte[]{ 120, 218 },
                _ => Array.Empty<byte>()
            });
            var array = _ms.ToArray();
            _stream.WriteByte((byte) (array[0] + 1));
            _stream.Write(array, 1, array.Length - 5);
            if (Footer[0] != 0)
                _stream.Position--;

            _stream.Write(Footer);

            _ms.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _deflateSream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _deflateSream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _deflateSream.SetLength(value);
        }

        public ZLibStream(Stream stream, CompressionLevel compressionLevel, bool leaveOpen = false)
        {
            _deflateSream = new DeflateStream(_ms, compressionLevel, leaveOpen);

            _level = compressionLevel;
            _stream = stream;
        }

        public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen = false)
        {
            _deflateSream = new DeflateStream(_ms, mode, leaveOpen);

            _level = CompressionLevel.Optimal;
            _stream = stream;
        }
    }
}