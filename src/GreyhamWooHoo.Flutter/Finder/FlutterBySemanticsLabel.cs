using System.Text.Json.Serialization;

namespace GreyhamWooHoo.Flutter.Finder
{
    public class FlutterBySemanticsLabel : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("isRegExp")]
        public bool IsRegExp { get; private set; }
        [JsonPropertyName("label")]
        public string Label { get; private set; }
        public FlutterBySemanticsLabel(string label)
        {
            FinderType = "BySemanticsLabel";
            Label = label;
            IsRegExp = false;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
