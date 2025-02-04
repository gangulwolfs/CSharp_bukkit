﻿using System;
using System.IO;
using System.Text;

namespace NiaBukkit.API
{
    public class ConsoleSenderError : TextWriter
    {
        private TextWriter originalConsoleStream;

        public ConsoleSenderError(TextWriter origin)
        {
            originalConsoleStream = origin;
        }
        
        public override void WriteLine()
        {
            Console.WriteLine();
        }

        public override void WriteLine(int value)
        {
            WriteLine(value.ToString());
        }

        #nullable enable
        public override void WriteLine(object? value)
        {
            WriteLine(value == null ? "null" : value.ToString());
        }

        public override void WriteLine(StringBuilder? value)
        {
            if(value == null)
                WriteLine("null");
            else
                WriteLine(value.ToString());
        }

        public override void WriteLine(string? value)
        {
            lock (Bukkit.ConsoleSender.ConsoleLockObject)
            {
                value ??= "null";
            
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}/ERROR]: ", ConsoleSender.GetInfo());
            
                originalConsoleStream.WriteLine(value);
                Console.ResetColor();
                Console.Write(">");
            }
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}