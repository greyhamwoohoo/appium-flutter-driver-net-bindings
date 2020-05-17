using System.Text.Json.Serialization;

namespace Appium.Flutter.Finder
{
    public class FlutterByType : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("type")]
        public new string Type { get; private set; }
        public FlutterByType(string type)
        {
            FinderType = "ByType";
            Type = type;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
