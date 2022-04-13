using System;
using NiaBukkit.API.Util;

namespace NiaBukkit.Network
{
    public class NetworkBuf
    {
        private byte[] _buf = new byte[1024 * 2];
        private int _offset;

        private void Clear()
        {
            _buf = null;
        }

        public byte[] ReadPacket()
        {
            if (_offset <= 0) return null;
            var offset = ByteBuf.ReadVarInt(_buf, out var length);
            
            if (_offset < offset + length) return null;
            
            var result = new byte[length];
            Array.Copy(_buf, offset, result, 0, length);
            
            var block = offset + length;
            _offset -= block;
            Array.Copy(_buf, block, _buf, 0, _offset);

            return result;
        }

        public virtual void Read(byte[] input, int size)
        {
            Array.Copy(input, 0, _buf, _offset, size);
            _offset += size;
        }
    }
}