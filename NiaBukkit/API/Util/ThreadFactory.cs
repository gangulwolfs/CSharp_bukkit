using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NiaBukkit.API.Util
{
    public class ThreadFactory
    {
        private static readonly List<Thread> Threads = new List<Thread>();

        public static Thread LaunchThread(Thread thread, bool setName = true)
        {
            thread.Start();
            
            if (Threads == null) return thread;
            
            if(setName)
                thread.Name = "Thread-" + (Threads.Count() - 1);
            
            Threads.Add(thread);

            return thread;
        }

        public static void KillAll()
        {
            if (Threads == null) return;
            
            foreach (var thread in Threads.Where(thread => thread.IsAlive))
            {
                thread.Abort();
            }
        }
    }
}