using System;
using System.Collections.Generic;

namespace NiaBukkit.API.Module
{
    public class ChatColor
    {
        public static ChatColor Black;
        public static ChatColor DarkBlue;
        public static ChatColor DarkGreen;
        public static ChatColor DarkAqua;
        public static ChatColor DarkRed;
        public static ChatColor DarkPurple;
        public static ChatColor Gold;
        public static ChatColor Gray;
        public static ChatColor DarkGray;
        public static ChatColor Blue;
        public static ChatColor Green;
        public static ChatColor Aqua;
        public static ChatColor Red;
        public static ChatColor LightPurple;
        public static ChatColor Yellow;
        public static ChatColor White;
        public static ChatColor Magic;
        public static ChatColor Bold;
        public static ChatColor Strikethrough;
        public static ChatColor Underline;
        public static ChatColor Italic;
        public static ChatColor Reset;

        private static Dictionary<char, ChatColor> Colors = new Dictionary<char, ChatColor>();

        public const char ColorChar = '§';
        private readonly char code;
        private readonly string name;

        internal static void InitColors()
        {
            Black = new ChatColor('0');
            DarkBlue = new ChatColor('1');
            DarkGreen = new ChatColor('2');
            DarkAqua = new ChatColor('3');
            DarkRed = new ChatColor('4');
            DarkPurple = new ChatColor('5');
            Gold = new ChatColor('6');
            Gray = new ChatColor('7');
            DarkGray = new ChatColor('8');
            Blue = new ChatColor('9');
            Green = new ChatColor('a');
            Aqua = new ChatColor('b');
            Red = new ChatColor('c');
            LightPurple = new ChatColor('d');
            Yellow = new ChatColor('e');
            White = new ChatColor('f');
            Magic = new ChatColor('k');
            Bold = new ChatColor('l');
            Strikethrough = new ChatColor('m');
            Underline = new ChatColor('n');
            Italic = new ChatColor('o');
            Reset = new ChatColor('r');
        }

        private ChatColor(char code)
        {
            this.code = code;
            name = new string(new [] { ColorChar, code });
            Colors.Add(code, this);
        }

        public override string ToString()
        {
            return name;
        }

        internal static ChatColor GetColor(char code)
        {
            if (!Colors.ContainsKey(code)) return null;
            return Colors[code];
        }

        internal ConsoleColor getConsoleColor()
        {
            if (this == Black) return ConsoleColor.Black;
            if (this == DarkBlue) return ConsoleColor.DarkBlue;
            if (this == DarkGreen) return ConsoleColor.DarkGreen;
            if (this == DarkAqua) return ConsoleColor.DarkCyan;
            if (this == DarkRed) return ConsoleColor.DarkRed;
            if (this == DarkPurple) return ConsoleColor.DarkMagenta;
            if (this == Gold) return ConsoleColor.DarkYellow;
            if (this == Gray) return ConsoleColor.Gray;
            if (this == DarkGray) return ConsoleColor.DarkGray;
            if (this == Blue) return ConsoleColor.Blue;
            if (this == Green) return ConsoleColor.Green;
            if (this == Aqua) return ConsoleColor.Cyan;
            if (this == Red) return ConsoleColor.Red;
            if (this == LightPurple) return ConsoleColor.Magenta;
            if (this == Yellow) return ConsoleColor.Yellow;
            if (this == White) return ConsoleColor.White;

            return ConsoleColor.White;
        }

        public bool IsColor()
        {
            return this != Magic && this != Bold && this != Strikethrough && this != Underline && this != Italic;
        }

        public static bool operator ==(ChatColor c1, ChatColor c2)
        {
            if (c1 is null || c2 is null) return c1 is null && c2 is null;
            return c1.code == c2.code;
        }

        public static bool operator !=(ChatColor c1, ChatColor c2) => !(c1 == c2);

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is ChatColor)) return false;
            return (ChatColor) obj == this;
        }
    }
}