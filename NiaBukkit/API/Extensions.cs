using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using NiaBukkit.Network;

namespace NiaBukkit.API
{
    public static class Extensions
    {
        public static void Remove<T>(this ConcurrentBag<T> data, T target)
        {
            Queue<T> removeQueue = new Queue<T>();
            while(!data.IsEmpty)
            {
                T item;
                if (data.TryTake(out item) && item.Equals(target))
                    break;
                
                removeQueue.Enqueue(item);
            }
            
            foreach (var item in removeQueue)
            {
                data.Add(item);
            }
        }

        public static string Minecraft2Name(this string data)
        {
            if (data.Length == 0) return null;
            var builder = new StringBuilder();
            builder.Append(char.ToUpper(data[0]));
            for (var i = 1; i < data.Length; i++)
            {
                if(data[i] == '_') continue;
                builder.Append(data[i - 1] == '_' ? char.ToUpper(data[i]) : data[i]);
            }

            return builder.ToString();
        }

        public static string Name2Minecraft(this string data)
        {
            var builder = new StringBuilder();
            builder.Append(data[0]);
            for (var i = 1; i < data.Length; i++)
            {
                if (char.IsUpper(data[i]))
                    builder.Append('_');
                builder.Append(data[i]);
            }

            return builder.ToString().ToLower();
        }

        public static int ToInt(this bool data) => data ? 1 : 0;
    }
}