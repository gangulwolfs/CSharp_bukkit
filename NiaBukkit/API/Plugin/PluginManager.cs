using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NiaBukkit.API
{
    public class PluginManager
    {
        private readonly List<Plugin> plugins = new List<Plugin>();
		
		/// <summary>플러그인 목록을 가져옵니다.</summary>
        public Plugin[] Plugins => plugins.ToArray();
    
		
		/// <summary>플러그인을 불러옵니다.</summary>
        internal void LoadPlugins()
        {
            string directory = Path.Join(Bukkit.ServerPath, "plugins");

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            foreach (string path in Directory.GetFiles(directory, "*.dll", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    Assembly plugin = Assembly.LoadFile(path);
                    GetPluginDescription(plugin);
                }
                catch(Exception)
                {
                    Console.Error.WriteLine("Could not load '" + Path.GetFileName(path) +"' in folder 'plugins'");
                    throw;
                }
            }
        }

        internal void DisablePlugins()
        {
            // TODO: OnDisable
        }

        private void GetPluginDescription(Assembly plugin)
        {
            Console.WriteLine(plugin.GetManifestResourceInfo("plugin.yml"));
        }
    }
}