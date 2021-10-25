using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace NiaBukkit.API.Util
{
	public class Uuid
	{
		private readonly string uid;
		
		internal Uuid(Guid id)
		{
			uid = id.ToString();
		}
		
		internal Uuid(string id)
		{
			uid = id;
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
			return uid;
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
	}
}