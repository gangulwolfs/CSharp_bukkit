using System;
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

        public override void WriteLine(object? value)
        {
            WriteLine(value.ToString());
        }

        public override void WriteLine(string? value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleSender.PrintInfo();
            originalConsoleStream.Write("/ERROR]: ");
            
            originalConsoleStream.WriteLine(value);
            Console.ResetColor();
            Console.Write(">");
        }

        public override Encoding Encoding => Encoding.UTF8;
    }
}