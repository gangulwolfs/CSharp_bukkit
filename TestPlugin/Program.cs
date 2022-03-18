using System;
using System.IO;
using System.Security.Cryptography;

namespace TestPlugin
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static byte[] Write(ICryptoTransform transform, byte[] data)
        {
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(data);
            // cs.FlushFinalBlock();
            cs.Close();
            //
            return ms.ToArray();
            // return cipher.Update(data);
        }

        private static byte[] Write2(ICryptoTransform transform, byte[] data)
        {
            using var ms = new MemoryStream();

            var length = data.Length;
            var remain = length % transform.InputBlockSize;
            var blockSize = length - remain;

            if (blockSize > 0)
            {
                var result = new byte[length];
                transform.TransformBlock(data, 0, blockSize, result, 0);
                ms.Write(result);
            }

            var c = new byte[transform.InputBlockSize];
            var padding = new byte[transform.InputBlockSize];
            Array.Copy(data, blockSize, c, 0, remain);
            transform.TransformBlock(c, 0, transform.InputBlockSize, padding, 0);
            ms.Write(padding, 0, remain);
            
            return ms.ToArray();
        }

        public static Aes Generate(byte[] key)
        {
            // using var aes = Aes.Create();
            // aes.Mode = CipherMode.CFB;
            // aes.Padding = PaddingMode.None;
            // aes.FeedbackSize = 8;
            // aes.IV = key;
            // aes.Key = key;
            
            // return aes;
            
            using var provider = new AesCryptoServiceProvider();
            provider.Key = key;
            provider.IV = key;
            provider.Mode = CipherMode.CFB;
            provider.Padding = PaddingMode.None;
            provider.FeedbackSize = 8;

            return provider;
        }
    }
}