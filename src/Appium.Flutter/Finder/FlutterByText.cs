﻿using System.Text.Json.Serialization;

namespace Appium.Flutter.Finder
{
    public class FlutterByText : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("text")]
        public string TextValue { get; private set; }
        public FlutterByText(string text)
        {
            FinderType = "ByText";
            TextValue = text;
        }

        protected override string ToJson()
        {
            var asJson = System.Text.Json.JsonSerializer.Serialize(this);
            return asJson;
        }
    }
}
