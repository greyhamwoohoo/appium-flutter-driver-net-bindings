using System.Text.Json.Serialization;

namespace Appium.Flutter.Finder
{
    public class FlutterByType : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("type")]
        public string TypeValue { get; private set; }
        public FlutterByType(string type)
        {
            FinderType = "ByType";
            TypeValue = type;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
