using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GreyhamWooHoo.Flutter.Finder
{
    public abstract class FlutterByRelative : FlutterBy
    {
        [JsonPropertyName("finderType")]
        public string FinderType { get; private set; }
        [JsonPropertyName("matchRoot")]
        public bool MatchRoot { get; private set; }
        [JsonIgnore]
        public FlutterBy Of { get; private set; }
        [JsonIgnore]
        public FlutterBy Matching { get; private set; }

        public FlutterByRelative(string finderType, FlutterBy of, FlutterBy matching, bool matchRoot)
        {
            FinderType = finderType ?? throw new System.ArgumentNullException(nameof(finderType));
            Of = of;
            Matching = matching;
            MatchRoot = matchRoot;
        }

        protected internal override string ToJson()
        {
            // Reference: https://stackoverflow.com/questions/15819720/dynamically-add-c-sharp-properties-at-runtime
            var candidate = new ExpandoObject() as IDictionary<string, Object>;

            candidate["finderType"] = FinderType;
            candidate["matchRoot"] = MatchRoot;

            Enrich(candidate, prefix: "of_", by: Of);
            Enrich(candidate, prefix: "matching_", by: Matching);

            var asJson = System.Text.Json.JsonSerializer.Serialize(candidate);
            return asJson;
        }

        protected void Enrich(IDictionary<string, Object> result, string prefix, FlutterBy by)
        {
            if (null == by) return;
            if (null == result) return;

            var originalJsonAsString = by.ToJson();

            using (JsonDocument doc = JsonDocument.Parse(originalJsonAsString))
            {
                foreach(var o in doc.RootElement.EnumerateObject())
                {
                    result[$"{prefix}{o.Name}"] = o.Value.Clone();
                }
            }
        }
    }
}
