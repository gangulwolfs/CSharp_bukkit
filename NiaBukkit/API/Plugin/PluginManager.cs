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
        public Plugin[] Plugins => plugins.ToArray();
    
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
                catch(Exception e)
                {
                    Console.Error.WriteLine("Could not load '" + Path.GetFileName(path) +"' in folder 'plugins'");
                    Console.Error.WriteLine(e);
                }
            }
        }

        private void GetPluginDescription(Assembly plugin)
        {
            Console.WriteLine(plugin.GetManifestResourceInfo("plugin.yml").FileName);
        }
    }
}