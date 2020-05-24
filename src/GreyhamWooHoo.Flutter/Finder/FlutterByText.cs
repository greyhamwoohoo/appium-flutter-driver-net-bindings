using System.Text.Json.Serialization;

namespace GreyhamWooHoo.Flutter.Finder
{
    public class FlutterByText : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("text")]
        public new string Text { get; private set; }
        public FlutterByText(string text)
        {
            FinderType = "ByText";
            Text = text;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
