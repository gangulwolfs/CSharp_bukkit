using System;
using System.Threading;
using NiaBukkit.API.Module;

namespace NiaBukkit.API
{
    public class ConsoleSender
    {
        internal static void PrintInfo()
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.Write("[");
            Console.Write(DateTime.Now.ToString("HH:mm:ss"));
            Console.Write("] [");
            if(Thread.CurrentThread.Name != null)
                Console.Write(Thread.CurrentThread.Name);
            else
                Console.Write("Other Thread");
        }

        public static void SendMessage(object message)
        {
            SendMessage(message.ToString());
        }
        public static void SendMessage(string message)
        {
            PrintInfo();
            Console.Write("/INFO]: ");
            
            string[] text = message.Split("§");
            Console.Write(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i].Length <= 0)
                {
                    Console.Write("§");
                    continue;
                }
                
                ChatColor color = ChatColor.GetColor(text[i][0]);
                if (color != null && color.IsColor())
                {
                    ChatColor chatColor = ChatColor.GetColor(text[i][0]);
                    if (chatColor == ChatColor.Reset) Console.ResetColor();
                    Console.ForegroundColor = chatColor.getConsoleColor();
                }else Console.Write("§" + text[i][0]);
                
                Console.Write(text[i].Substring(1));
            }
            
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write(">");
        }

        public static void SendWarnMessage(object message)
        {
            SendWarnMessage(message.ToString());
        }
        public static void SendWarnMessage(string message)
        {
            PrintInfo();
            Console.Write("/WARN]: ");
            
            string[] text = message.Split("§");
            Console.Write(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i].Length <= 0)
                {
                    Console.Write("§");
                    continue;
                }
                
                ChatColor color = ChatColor.GetColor(text[i][0]);
                if (color != null && color.IsColor())
                {
                    ChatColor chatColor = ChatColor.GetColor(text[i][0]);
                    if (chatColor == ChatColor.Reset) Console.ResetColor();
                    Console.ForegroundColor = chatColor.getConsoleColor();
                }else Console.Write("§" + text[i][0]);
                
                Console.Write(text[i].Substring(1));
            }
            
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write(">");
        }
    }
}