﻿using System.IO;

namespace NiaBukkit.API.Cryptography
{
    public class AesStream : Stream
    {
        private Stream _baseStream;
        private AesCipher _encryptor;
        
        public AesStream(AesCipher encryptor, Stream baseStream)
        {
            _encryptor = encryptor;
            _baseStream = baseStream;
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _baseStream.Read(buffer, offset, count);
        }

        public override int ReadByte()
        {
            return _baseStream.ReadByte();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _baseStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _baseStream.Write(_encryptor.EncryptBlock(buffer), offset, count);
        }

        public override bool CanRead => _baseStream.CanRead;
        public override bool CanSeek => _baseStream.CanSeek;
        public override bool CanWrite => _baseStream.CanWrite;
        public override long Length => _baseStream.Length;
        public override long Position { get => _baseStream.Position; set => _baseStream.Position = value; }
    }
}