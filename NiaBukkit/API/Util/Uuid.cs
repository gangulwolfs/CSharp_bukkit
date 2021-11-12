using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace NiaBukkit.API.Util
{
	public class Uuid
	{
		private readonly Guid _guid;
		
		internal Uuid(Guid id)
		{
			_guid = id;
		}
		
		internal Uuid(string id)
		{
			_guid = Guid.Parse(id);
		}

		internal Uuid(long most, long least)
		{
			byte[] result = new byte[16];
			Buffer.BlockCopy(BitConverter.GetBytes((int) (most >> 32)), 0, result, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes((int) most), 0, result, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes((int) (least >> 32)), 0, result, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes((int) least), 0, result, 12, 4);
			
			// uuid bytes to guid bytes
			(result[4], result[6]) = (result[6], result[4]); // swap 4 <> 6
			(result[5], result[7]) = (result[7], result[5]); // swap 5 <> 7

			(result[8], result[11]) = (result[11], result[8]); // swap 8 <> 11
			(result[9], result[10]) = (result[10], result[9]); // swap 9 <> 10

			(result[12], result[15]) = (result[15], result[12]); // swap 12 <> 15
			(result[13], result[14]) = (result[14], result[13]); // swap 13 <> 14
			
			_guid = new Guid(result);
		}
		
		public static Uuid RandomUuid()
		{
			return new Uuid(Guid.NewGuid());
		}
		
		public static Uuid FromUserName(string name)
		{
			try
			{
				WebClient wc = new WebClient();
				string[] result = wc.DownloadString("https://api.mojang.com/users/profiles/minecraft/" + name).Split('"');

				for(int i = 1; i < result.Length; i+=4) {
					if(result[i].Equals("id")) {
						return new Uuid(Guid.Parse(result[i + 2]));
					}
				}
			}
			catch {}
			
			return NameUuidFromBytes(Encoding.UTF8.GetBytes(name));
		}
		
		public override string ToString()
		{
			return _guid.ToString();
		}

		public byte[] ToByteArray()
		{
			return _guid.ToByteArray();
		}

		public long GetMostSignificantBits()
		{
			byte[] bytes = ToByteArray();

			// guid bytes to uuid packet
			(bytes[4], bytes[6]) = (bytes[6], bytes[4]); // swap 4 <> 6
			(bytes[5], bytes[7]) = (bytes[7], bytes[5]); // swap 5 <> 7

			return (long) BitConverter.ToInt32(bytes, 0) << 32 | BitConverter.ToInt32(bytes, 4) & 0xFFFFFFFFL;
		}

		public long GetLeastSignificantBits()
		{
			byte[] bytes = ToByteArray();

			// guid bytes to uuid packet
			(bytes[8], bytes[11]) = (bytes[11], bytes[8]); // swap 8 <> 11
			(bytes[9], bytes[10]) = (bytes[10], bytes[9]); // swap 9 <> 10

			(bytes[12], bytes[15]) = (bytes[15], bytes[12]); // swap 12 <> 15
			(bytes[13], bytes[14]) = (bytes[14], bytes[13]); // swap 13 <> 14

			return (long) BitConverter.ToInt32(bytes, 8) << 32 | BitConverter.ToInt32(bytes, 12) & 0xFFFFFFFFL;
		}

		public Guid ToGuid()
		{
			return _guid;
		}
		
		private static Uuid NameUuidFromBytes(byte[] name)
		{
			MD5 md = MD5.Create();
			byte[] hash = md.ComputeHash(name);
			hash[6] &= 0x0f;
			hash[6] |= 0x30;
			hash[8] &= 0x3f;
			hash[8] |= 0x80;
			
			return new Uuid(new Guid(hash));
		}
        
		public static bool operator ==(Uuid c1, Uuid c2)
		{
                
			if (c1 is null || c2 is null) return c1 is null && c2 is null;

			return c1.ToString().Equals(c2.ToString());
		}

		public static bool operator !=(Uuid c1, Uuid c2) => !(c1 == c2);
		
		

		#nullable enable
		public override bool Equals(object? obj)
		{
			if (obj is not Uuid uuid) return false;
			return uuid == this;
		}

		public override int GetHashCode()
		{
			return _guid.GetHashCode();
		}
	}
}