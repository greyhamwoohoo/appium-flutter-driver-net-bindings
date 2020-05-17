using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Appium.Flutter
{
    public abstract class FlutterBy
    {
        protected abstract string ToJson();

        public virtual string ToBase64()
        {
            var asJson = ToJson();

            byte[] asBytes = Encoding.UTF8.GetBytes(asJson);
            var asBase64InAppiumFlutterDriverNodeJs = Convert.ToBase64String(asBytes)
                .Replace("=", "")
                .Replace("+", "-")
                .Replace("/", "_");

            return asBase64InAppiumFlutterDriverNodeJs;
        }

        public static FlutterBy ValueKey(string valueKey)
        {
            return new FlutterByValueKey(valueKey);
        }

        public static FlutterBy ValueKey(int valueKey)
        {
            return new FlutterByValueKey(valueKey);
        }
    }

    public class FlutterByValueKey : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("keyValueString")]
        public object KeyValueString { get; private set; }
        [JsonPropertyName("keyValueType")]
        public string KeyValueType { get; private set; }

        public FlutterByValueKey(string key)
        {
            KeyValueType = "String";
            KeyValueString = key;
            FinderType = "ByValueKey";
        }

        public FlutterByValueKey(int key)
        {
            KeyValueType = "int";
            KeyValueString = key;
            FinderType = "ByValueKey";
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
