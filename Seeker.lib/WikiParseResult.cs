using System.Text.Json.Serialization;

namespace Seeker.lib
{
    public class WikiParseResult
    {
        [JsonPropertyName("parse")]
        public ParseData Parse { get; set; }
    }

    public class ParseData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("text")]
        public ParseText Text { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; }

        [JsonPropertyName("sections")]
        public List<ParseSection> Sections { get; set; }
    }

    public class ParseText
    {
        [JsonPropertyName("*")]
        public string HtmlContent { get; set; }
    }

    public class ParseSection
    {
        [JsonPropertyName("toclevel")]
        public int TocLevel { get; set; }

        [JsonPropertyName("level")]
        public string Level { get; set; }

        [JsonPropertyName("line")]
        public string Line { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("anchor")]
        public string Anchor { get; set; }
    }
}
