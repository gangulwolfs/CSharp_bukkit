using System;
using System.Threading;
using NiaBukkit.API.Command;
using NiaBukkit.API.Util;

namespace NiaBukkit.API
{
    public class ConsoleSender : CommandSender
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

        public void SendMessage(object message)
        {
            if (message == null)
                message = "null";
            
            SendMessage(message.ToString());
        }
		
        public void SendMessage(string message)
        {
            if (message == null)
                message = "null";

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

        public void SendWarnMessage(object message)
        {
            if (message == null)
                message = "null";
            
            SendWarnMessage(message.ToString());
        }
		
        public void SendWarnMessage(string message)
        {
            if (message == null)
                message = "null";

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