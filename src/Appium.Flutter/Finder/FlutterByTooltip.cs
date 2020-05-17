using System.Text.Json.Serialization;

namespace Appium.Flutter.Finder
{
    public class FlutterByTooltip : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("text")]
        public string TextValue { get; private set; }
        public FlutterByTooltip(string tooltip)
        {
            FinderType = "ByTooltipMessage";
            TextValue = tooltip;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
