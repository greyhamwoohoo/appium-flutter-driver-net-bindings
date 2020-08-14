using System.Text.Json.Serialization;

namespace GreyhamWooHoo.Flutter.Finder
{
    public class FlutterByPageBack : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        public FlutterByPageBack()
        {
            FinderType = "PageBack";
        }

        protected internal override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
