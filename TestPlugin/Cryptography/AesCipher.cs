using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace NiaBukkit.API.Cryptography
{
    //https://stackoverflow.com/questions/34420086/aes-decryption-encryption-implementation-in-c-sharp-not-using-libraries
    public class AesCipher
    {
        public byte[] Key { get; }

        public byte[] IV { get; }

        private byte[] _cV;
        public int FeedbackSize => 8;
        public int InputBlockSize => 16;
        public static int RoundCount => 10;

        public uint[,] RoundKey { get; } = new uint[RoundCount + 1, 4];

        private int _blockSize; 

        public AesCipher([NotNull] byte[] key, [NotNull] byte[] iv)
        {
            Key = ByteArrayClone(key);
            IV = ByteArrayClone(iv);

            _blockSize = FeedbackSize / 8;

            AesModule.GenerateRoundKey(RoundKey, Key);
            Reset();
        }

        public void Reset()
        {
            _cV = ByteArrayClone(IV);
        }

        private static byte[] ByteArrayClone(byte[] array)
        {
            var result = new byte[array.Length];
            array.CopyTo(result, 0);
            return result;
        }

        #region Encrypt
        public byte[] EncryptBlock(byte[] input)
        {
            var length = input.Length;
            var outBytes = new byte[length];
            EncryptBlock(input, 0, outBytes, 0, length);
            
            return outBytes;
        }

        public int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff, int length)
        {
            lock (_cV)
            {
                var count = 0;
                while (count < length)
                {
                    count += EncryptBlock(input, inOff + count, outBytes, outOff + count);
                }
            }

            return length;
        }

        private int EncryptBlock(IReadOnlyList<byte> input, int inOff, byte[] outBytes, int outOff)
        {
            //_blockSize == 1
            var v = AesEncryptBlock(_cV);
            
            outBytes[outOff] = (byte) (v[0] ^ input[inOff]);

            var length = _cV.Length - _blockSize;
            Array.Copy(_cV, 1, _cV, 0, length);
            Array.Copy(outBytes, outOff, _cV, length, 1);

            return 1;
        }

        public byte[] AesEncryptBlock(byte[] origin)
        {
            var C0 = AesModule.ColumnToUInt(origin, 0) ^ RoundKey[0, 0];
            var C1 = AesModule.ColumnToUInt(origin, 1) ^ RoundKey[0, 1];
            var C2 = AesModule.ColumnToUInt(origin, 2) ^ RoundKey[0, 2];
            var C3 = AesModule.ColumnToUInt(origin, 3) ^ RoundKey[0, 3];

            var round = 1;
            while (round < RoundCount - 1)
            {
                var a = AesModule.SubMixColumnHelper(C0, C1 >> 8, C2 >> 16, C3 >> 24) ^ RoundKey[round, 0];

                var b = AesModule.SubMixColumnHelper(C1, C2 >> 8, C3 >> 16, C0 >> 24) ^ RoundKey[round, 1];

                var c = AesModule.SubMixColumnHelper(C2, C3 >> 8, C0 >> 16, C1 >> 24) ^ RoundKey[round, 2];

                var d = AesModule.SubMixColumnHelper(C3, C0 >> 8, C1 >> 16, C2 >> 24) ^ RoundKey[round, 3];

                round++;
                C0 = AesModule.SubMixColumnHelper(a, b >> 8, c >> 16, d >> 24) ^ RoundKey[round, 0];

                C1 = AesModule.SubMixColumnHelper(b, c >> 8, d >> 16, a >> 24) ^ RoundKey[round, 1];

                C2 = AesModule.SubMixColumnHelper(c, d >> 8, a >> 16, b >> 24) ^ RoundKey[round, 2];

                C3 = AesModule.SubMixColumnHelper(d, a >> 8, b >> 16, c >> 24) ^ RoundKey[round, 3];
                round++;
            }

            var R0 = AesModule.SubMixColumnHelper(C0, C1 >> 8, C2 >> 16, C3 >> 24) ^ RoundKey[round, 0];
            var R1 = AesModule.SubMixColumnHelper(C1, C2 >> 8, C3 >> 16, C0 >> 24) ^ RoundKey[round, 1];
            var R2 = AesModule.SubMixColumnHelper(C2, C3 >> 8, C1 >> 16, C2 >> 24) ^ RoundKey[round, 2];
            var R3 = AesModule.SubMixColumnHelper(C3, C0 >> 8, C1 >> 16, C2 >> 24) ^ RoundKey[round, 3];

            C0 = AesModule.SubAndShift(R0, R1, R2, R3) ^ RoundKey[round + 1, 0];
            C1 = AesModule.SubAndShift(R1, R2, R3, R0) ^ RoundKey[round + 1, 1];
            C2 = AesModule.SubAndShift(R2, R3, R0, R1) ^ RoundKey[round + 1, 2];
            C3 = AesModule.SubAndShift(R3, R0, R1, R2) ^ RoundKey[round + 1, 3];

            return AesModule.ColumnsToBytes(C0, C1, C2, C3);
        }
        #endregion

        #region Decrypt
        public int DecryptByte(int input)
        {
            var outBytes = new byte[1];
            DecryptBlock(new [] {(byte) input}, 0, outBytes, 0, 1);
            
            return outBytes[0];
        }
        
        public byte[] DecryptBlock(byte[] input)
        {
            var length = input.Length;
            var outBytes = new byte[length];
            DecryptBlock(input, 0, outBytes, 0, length);
            
            return outBytes;
        }
        
        public byte[] DecryptBlock(byte[] input, int inOff, int length)
        {
            var outBytes = new byte[length];
            DecryptBlock(input, inOff, outBytes, 0, length);
            
            return outBytes;
        }
        
        public int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff, int length)
        {
            var count = 0;
            while (count < length)
            {
                count += DecryptBlock(input, inOff + count, outBytes, outOff + count);
            }

            return count;
        }

        private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
        {
            var v = AesEncryptBlock(_cV);
            var length = _cV.Length - _blockSize;
            Array.Copy(_cV, _blockSize, _cV, 0, length);
            Array.Copy(input, inOff, _cV, length, _blockSize);
            
            for(var i = 0; i < _blockSize; i++)
                outBytes[outOff + i] = (byte) (v[i] ^ input[inOff + i]);

            return _blockSize;
        }
        #endregion
    }
}