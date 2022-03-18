using System.IO;
using System.Net.Sockets;

namespace NiaBukkit.API.Cryptography
{
    public class AesStream : Stream
    {
        private Stream _baseStream;
        private AesCipher _decryptor;
        private AesCipher _encryptor;
        
        public AesStream(AesCipher decryptor, AesCipher encryptor, Stream baseStream)
        {
            _decryptor = decryptor;
            _encryptor = encryptor;
            _baseStream = baseStream;
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var result = new byte[count];
            count = _baseStream.Read(result, offset, count);
            
            return _decryptor.DecryptBlock(result, 0, buffer, offset, count);
        }

        public override int ReadByte()
        {
            return _decryptor.DecryptByte(_baseStream.ReadByte());
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
            lock (_encryptor)
            {
                _baseStream.Write(_encryptor.EncryptBlock(buffer), offset, count);
            }
        }

        public override bool CanRead => _baseStream.CanRead;
        public override bool CanSeek => _baseStream.CanSeek;
        public override bool CanWrite => _baseStream.CanWrite;
        public override long Length => _baseStream.Length;
        public override long Position { get => _baseStream.Position; set => _baseStream.Position = value; }
    }
}