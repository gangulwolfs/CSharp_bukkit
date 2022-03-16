using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NiaBukkit.API.Util
{
	public class SelfCryptography
	{
		private static readonly byte[] Algorithm =
		{
			0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00
		};
		
		private RSACryptoServiceProvider _provider;
		private RSAParameters _privateKey;
		private RSAParameters _publicKey;
		
		public byte[] PublicKey { get; private set; }

		public SelfCryptography()
		{
			_provider = new RSACryptoServiceProvider(1024);
			_privateKey = _provider.ExportParameters(true);
			_publicKey = _provider.ExportParameters(false);
			
			// _provider.Public

			// var store = new X509Store(StoreLocation.CurrentUser);
			// store.Open(OpenFlags.ReadOnly);
			// Bukkit.ConsoleSender.SendMessage(store.Certificates);
			
			// var x509 = new X509Certificate2(_provider.ExportSubjectPublicKeyInfo());
			// Bukkit.ConsoleSender.SendMessage(x509.GetRSAPublicKey());

			PublicKey = _provider.ExportSubjectPublicKeyInfo();
			// Bukkit.ConsoleSender.SendMessage(_provider.ToXmlString(false));
		}
		
		public static string JavaHexDigest(byte[] data)
		{
			var sha1 = SHA1.Create();
			var hash = sha1.ComputeHash(data);
			var negative = (hash[0] & 0x80) == 0x80;
			if (negative) // check for negative hashes
				hash = TwosCompliment(hash);
			// Create the string and trim away the zeroes
			var digest = GetHexString(hash).Trim('0');
			if (negative)
				digest = "-" + digest;
			return digest;
		}

		private static string GetHexString(IEnumerable<byte> p)
		{
			return p.Aggregate(string.Empty, (current, t) => current + t.ToString("x2"));
		}

		private static byte[] TwosCompliment(byte[] p) // little endian
		{
			int i;
			var carry = true;
			for (i = p.Length - 1; i >= 0; i--)
			{
				p[i] = (byte) ~p[i];
				if (!carry) continue;
				carry = p[i] == 0xFF;
				p[i]++;
			}
			return p;
		}
		
		public byte[] Decrypt(byte[] data)
		{
			return _provider.Decrypt(data, false);
		}
		
		public byte[] Encrypt(byte[] data)
		{
			return _provider.Encrypt(data, false);
		}

		public static Aes GenerateAes(byte[] key)
		{
			var aes = Aes.Create();
			aes.Mode = CipherMode.CFB;
			aes.Padding = PaddingMode.None;
			aes.FeedbackSize = 8;
			aes.IV = key;
			aes.Key = key;

			return aes;
		}
		
		public static byte[] GetRandomToken()
		{
			var token = new byte[4];
			var random = new Random(Environment.TickCount);
			random.NextBytes(token);
			
			return token;
		}
		
		private static byte[] PublicKeyToAsn1(RSAParameters parameters)
		{
			var mod = CreateIntegerPos(parameters.Modulus);
			var exp = CreateIntegerPos(parameters.Exponent);
			
			var sequenceLength = mod.Length + exp.Length;
			var sequenceLengthArray = LengthToByteArray(sequenceLength);
			
			var keyLength = sequenceLengthArray.Length + sequenceLength + 2;
			var keyLengthArray = LengthToByteArray(keyLength);
			
			var publicKeyLength = keyLengthArray.Length + keyLength + Algorithm.Length + 1;
			var publicKeyLengthArray = LengthToByteArray(publicKeyLength);
			
			var messageLength = publicKeyLengthArray.Length + publicKeyLength + 1;
			
			var message = new byte[messageLength];
			var index = 0;
			
			message[index++] = 0x30;
			
			Buffer.BlockCopy(publicKeyLengthArray, 0, message, index, publicKeyLengthArray.Length);
			index += publicKeyLengthArray.Length;
			
			Buffer.BlockCopy(Algorithm, 0, message, index, Algorithm.Length);
			index += Algorithm.Length;
			
			message[index++] = 0x03;
			
			Buffer.BlockCopy(keyLengthArray, 0, message, index, keyLengthArray.Length);
			index += keyLengthArray.Length;
			
			message[index++] = 0x00;
			message[index++] = 0x30;
			
			Buffer.BlockCopy(sequenceLengthArray, 0, message, index, sequenceLengthArray.Length);
			index += sequenceLengthArray.Length;
			
			Buffer.BlockCopy(mod, 0, message, index, mod.Length);
			index += mod.Length;
			Buffer.BlockCopy(exp, 0, message, index, exp.Length);
			
			return message;
		}
		
		private static byte[] LengthToByteArray(int length)
		{
			return length switch
			{
				< 0x80 => new[] {(byte) length},
				<= 0xFF => new byte[] {0x81, (byte) (length & 0xFF)},
				<= 0xFFFF => new byte[] {0x82, (byte) ((length & 0xFF00) >> 8), (byte) (length & 0xFF)},
				<= 0xFFFFFF => new byte[]
				{
					0x83, (byte) ((length & 0xFF0000) >> 16), (byte) ((length & 0xFF00) >> 8), (byte) (length & 0xFF)
				},
				_ => new byte[]
				{
					0x84, (byte) ((length & 0xFF000000) >> 24), (byte) ((length & 0xFF0000) >> 16),
					(byte) ((length & 0xFF00) >> 8), (byte) (length & 0xFF)
				}
			};
		}
		
		private static byte[] CreateIntegerPos(byte[] data)
		{
			byte[] newInt, length;
			var index = 1;
			
			if (data[0] > 0x7F)
			{
				length = LengthToByteArray(data.Length + 1);
				
				newInt = new byte[data.Length + 2 + length.Length];
				newInt[0] = 0x02;
				
				foreach (var t in length)
					newInt[index++] = t;
				
				newInt[index++] = 0x00;
				Buffer.BlockCopy(data, 0, newInt, index, data.Length);
				
				return newInt;
			}
			
			length = LengthToByteArray(data.Length);
			
			newInt = new byte[data.Length + 1 + length.Length];
			newInt[0] = 0x02;
			
			for(; index <= length.Length; index++)
				newInt[index] = length[index-1];
			
			Buffer.BlockCopy(data, 0, newInt, index, data.Length);
			
			return newInt;
		}
	}
}