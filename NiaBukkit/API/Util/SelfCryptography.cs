using System;
using System.Security.Cryptography;

namespace NiaBukkit.API.Util
{
	public class SelfCryptography
	{
		private static readonly byte[] Algorithm =
		{
			0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00
		};
		
		public static byte[] VertifyToken { get; private set; }
		
		private static RSACryptoServiceProvider _provider;
		
		public static RSAParameters GenerateKeyPair()
		{
			if(_provider == null)
				_provider = new RSACryptoServiceProvider(1024);
			
			return _provider.ExportParameters(true);
		}
		
		public static byte[] Decrypt(byte[] data)
		{
			return _provider.Decrypt(data, false);
		}
		
		public static byte[] Encrypt(byte[] data)
		{
			return _provider.Encrypt(data, false);
		}

		public static RijndaelManaged GenerateAes(byte[] key)
		{
			RijndaelManaged cipher = new RijndaelManaged();
			cipher.Mode = CipherMode.CFB;
			cipher.Padding = PaddingMode.None;
			cipher.KeySize = 128;
			cipher.FeedbackSize = 8;
			
			cipher.Key = key;
			cipher.IV = key;
			// cipher.IV = (byte[]) key.Clone();

			return cipher;
		}
		
		public static byte[] GetRandomToken()
		{
			byte[] token = new byte[4];
			RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
			provider.GetBytes(token);
			VertifyToken = token;
			
			return token;
		}
		
		public static byte[] PublicKeyToAsn1(RSAParameters parameters)
		{
			byte[] mod = CreateIntergerPos(parameters.Modulus);
			byte[] exp = CreateIntergerPos(parameters.Exponent);
			
			int sequenceLength = mod.Length + exp.Length;
			byte[] sequenceLengthArray = LengthToByteArray(sequenceLength);
			
			int keyLength = sequenceLengthArray.Length + sequenceLength + 2;
			byte[] keyLengthArray = LengthToByteArray(keyLength);
			
			int publicKeyLength = keyLengthArray.Length + keyLength + Algorithm.Length + 1;
			byte[] publicKeyLengthArray = LengthToByteArray(publicKeyLength);
			
			int messageLength = publicKeyLengthArray.Length + publicKeyLength + 1;
			
			byte[] message = new byte[messageLength];
			int index = 0;
			
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
			
			if (length < 0x80)
				return new [] { (byte) length };
			
			if (length <= 0xFF)
				return new byte[] { 0x81, (byte) (length & 0xFF) };
			
			if (length <= 0xFFFF)
				return new byte[] { 0x82, (byte) (length & 0xFF00 >> 8), (byte) (length & 0xFF) };
			
			if (length <= 0xFFFFFF)
				return new byte[] { 0x83, (byte) (length & 0xFF0000 >> 16), (byte) (length & 0xFF00 >> 8), (byte) (length & 0xFF) };
			
			return new byte[]
			{
				0x84,
				(byte) (length & 0xFF000000 >> 24),
				(byte) (length & 0xFF0000 >> 16),
				(byte) (length & 0xFF00 >> 8),
				(byte) (length & 0xFF)
			};
		}
		
		private static byte[] CreateIntergerPos(byte[] data)
		{
			byte[] newInt, length;
			int index = 1;
			
			if (data[0] > 0x7F)
			{
				length = LengthToByteArray(data.Length + 1);
				
				newInt = new byte[data.Length + 2 + length.Length];
				newInt[0] = 0x02;
				
				for(; index <= length.Length; index++)
					newInt[index] = length[index-1];
				
				// newInt[index++] = 0x00;
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