using System.Collections.Generic;
using System.Text;

namespace NiaBukkit.API.Util
{
    public class JsonBuilder
    {
        private Dictionary<string, object> items = new Dictionary<string, object>();
        
        public JsonBuilder Add(string key, object value) {
            if (items.ContainsKey(key)) return this;
            items.Add(key, value);
            return this;
        }
        
        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append("{");
            int index = 0;
            foreach (KeyValuePair<string, object> item in items) {
                if (index > 0) builder.Append(",");
                builder.Append("\"");
                builder.Append(item.Key.Replace("\"", "\\\"").Replace("\'", "\\'"));
                builder.Append("\":");
                bool isString = item.Value is string;
                if (isString)
                {
                    if (isString) builder.Append("\"");
                    builder.Append(item.Value.ToString().Replace("\"", "\\\"").Replace("\'", "\\'"));
                    if (isString) builder.Append("\"");
                }else
                    builder.Append(item.Value);
                
                index++;
            }
            builder.Append("}");
            
            return builder.ToString();
        }

        public string Get(string key) {
            object value;
            if (items.TryGetValue(key, out value)) {
                return value.ToString();
            }
            return null;
        }

        public JsonBuilder Replace(string key, object value) {
            if(items.ContainsKey(key)) items.Remove(key);
            items.Add(key, value);

            return this;
        }

        public JsonBuilder Remove(string key) {
            if (items.ContainsKey(key)) items.Remove(key);
            return this;
        }
    }
}