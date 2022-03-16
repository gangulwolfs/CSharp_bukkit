using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TestPlugin
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = new byte[] {14, 192, 55, 152, 105, 236, 239, 144, 117, 39, 221, 9, 36, 202, 192, 243};

            var data = new byte[] {6, 3, 255, 255, 255, 255, 15};

            var encryptor = Generate(key).CreateEncryptor(key, key);
            Console.WriteLine("{" + string.Join(", ", Encrypt(encryptor, data)) +"};");
            Console.WriteLine("{" + string.Join(", ", Encrypt(encryptor, data)) +"};");
        }

        public static byte[] Encrypt(ICryptoTransform transform, byte[] data)
        {
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write);
            cs.Write(data);
            // cs.FlushFinalBlock();
            cs.Close();

            return ms.ToArray();
        }

        public static Aes Generate(byte[] key)
        {
            using var aes = Aes.Create();
            aes.Mode = CipherMode.CFB;
            aes.Padding = PaddingMode.None;
            aes.FeedbackSize = 8;
            aes.IV = key;
            aes.Key = key;
            
            return aes;
        }
    }
}