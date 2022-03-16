using NiaBukkit.API.Util;

namespace NiaBukkit.API.Util
{
	public class GameProfile
	{
		public Uuid Uuid { get; internal set; }
		public string Name { get; internal set; }
		
		public GameProfile(Uuid id, string name)
		{
			Uuid = id;
			Name = name;
		}

		public override string ToString()
		{
			return $"{{UUID={Uuid}, Name={Name}}}";
		}
	}
}