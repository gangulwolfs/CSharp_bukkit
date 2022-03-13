using System;
using System.Collections.Generic;
using System.Text;

namespace NiaBukkit.API.Util
{
    public class JsonBuilder
    {
        private readonly Dictionary<string, object> _items = new();
        
        public JsonBuilder Add(string key, object value) {
            if (_items.ContainsKey(key)) return this;
            _items.Add(key, value);
            return this;
        }

        public T Get<T>(string key)
        {
            return _items.TryGetValue(key, out var value)
                ? (T) value
                : default;
        }

        public JsonBuilder Replace<T>(string key, T value) {
            if(_items.ContainsKey(key)) _items.Remove(key);
            _items.Add(key, value);

            return this;
        }

        public JsonBuilder Remove(string key) {
            if (_items.ContainsKey(key)) _items.Remove(key);
            return this;
        }
        
        public override string ToString() {
            var builder = new StringBuilder();
            builder.Append('{');
            var isFirst = true;
            foreach (var (key, value) in _items) {
                if (!isFirst) builder.Append(',');
                
                builder.Append(ToStringValue(key));
                builder.Append(':');
                builder.Append(value is string ? ToStringValue(value.ToString()) : value);

                isFirst = false;
            }
            builder.Append('}');
            
            return builder.ToString();
        }

        private static string ToStringValue(string data)
        {
            var builder = new StringBuilder();
            return builder.Append('"')
                .Append(data.Replace("\"", "\\\"").Replace("\'", "\\'"))
                .Append('"').ToString();
        }

        public static JsonBuilder Parse(string json)
        {
            if (!json.StartsWith('{')) return null;

            var index = 0;
            return Parse(json, ref index);
        }

        private static JsonBuilder Parse(string json, ref int index)
        {
            var builder = new JsonBuilder();
            var info = new ParseInfo();
            var length = json.Length;

            for (index += 1; index < length; index++)
            {
                var current = json[index];
                switch (current)
                {
                    case '\n': case '\t': case '\r': case ' ':
                        if(!info.IsStringPart)
                            continue;
                        break;
                    case '{':
                        if (!info.IsStringPart)
                        {
                            if (!info.HasKey)
                                throw new Exception($"JSON Parse Error. Index: {index}");
                            
                            builder.Add(info.GetKey(), Parse(json, ref index));
                            continue;
                        }
                        break;
                    case '}':
                        if (!info.IsStringPart)
                        {
                            if(info.HasKey)
                                builder.Add(info.GetKey(), info.GetValue());
                            return builder;
                        }

                        break;
                    case ',':
                        if (!info.IsStringPart)
                        {
                            builder.Add(info.GetKey(), info.GetValue());
                            info.Clear();
                            continue;
                        }

                        break;
                    case '\\':
                        if (!info.EscapeSequence)
                        {
                            info.EscapeSequence = true;
                            continue;
                        }

                        info.EscapeSequence = false;
                        break;
                    case '\'': case '"':
                        if (!info.EscapeSequence)
                        {
                            if(info.IsStringPart && info.StringPartChar != current) break;
                            info.IsStringPart = !info.IsStringPart;

                            info.StringPartChar = current;
                            if (!info.IsStringPart && info.HasKey)
                            {
                                info.ValueType = info.StringPartChar == '\''
                                    ? DataType.Char
                                    : DataType.String;
                            }
                            
                            continue;
                        }

                        break;
                    case ':':
                        if (!info.IsStringPart)
                        {
                            info.HasKey = true;
                            continue;
                        }
                        break;
                }
                
                info.Input(current);
            }

            return builder;
        }

        private class ParseInfo
        {
            public bool IsStringPart;
            public char StringPartChar;
            public bool HasKey;
            public bool EscapeSequence;
            public DataType ValueType;

            private StringBuilder _keyBuilder = new();
            private StringBuilder _valueBuilder = new();

            public void Input(char data)
            {
                (HasKey ? _valueBuilder : _keyBuilder).Append(EscapeSequence ? ToEscapeSequence(data) : data);
                
                if (HasKey && ValueType == DataType.Number && !char.IsDigit(data) && data != '.')
                    ValueType = DataType.String;
            }

            public string GetKey() => _keyBuilder.ToString();

            public object GetValue()
            {
                var value = _valueBuilder.ToString();
                
                switch(ValueType)
                {
                    case DataType.String:
                        return value;
                    case DataType.Char:
                        if (value.Length == 1)
                            return value[0];
                        else return value;
                    case DataType.Number:
                        return value.Contains('.')
                            ? double.Parse(value)
                            : value.Length > 9
                                ? long.Parse(value)
                                : int.Parse(value);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public void Clear()
            {
                IsStringPart = false;
                HasKey = false;
                EscapeSequence = false;
                ValueType = DataType.Number;

                _keyBuilder.Clear();
                _valueBuilder.Clear();
            }

            private static char ToEscapeSequence(char data)
            {
                return data switch
                {
                    'a' => '\a',
                    'b' => '\b',
                    'f' => '\f',
                    'n' => '\n',
                    'r' => '\r',
                    't' => '\t',
                    'v' => '\v',
                    _ => data
                };
            }
        }

        private enum DataType
        {
            Number,
            String,
            Char
        }
    }
}