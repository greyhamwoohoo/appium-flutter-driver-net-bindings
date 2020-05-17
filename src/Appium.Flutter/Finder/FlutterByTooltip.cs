using System.Text.Json.Serialization;

namespace Appium.Flutter.Finder
{
    public class FlutterByTooltip : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("text")]
        public new string Text { get; private set; }
        public FlutterByTooltip(string tooltip)
        {
            FinderType = "ByTooltipMessage";
            Text = tooltip;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
