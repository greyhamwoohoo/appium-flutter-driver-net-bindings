using System.Text.Json.Serialization;

namespace GreyhamWooHoo.Flutter.Finder
{
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

        protected internal override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
