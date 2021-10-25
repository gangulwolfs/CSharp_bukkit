using NiaBukkit.API.Util;

namespace NiaBukkit.API.Util
{
	public class GameProfile
	{
		public Uuid Uuid { get; private set; }
		public string Name { get; private set; }
		
		public GameProfile(Uuid id, string name)
		{
			Uuid = id;
			Name = name;
		}
	}
}