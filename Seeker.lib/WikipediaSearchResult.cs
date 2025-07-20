using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Seeker.lib
{
    public class WikipediaSearchResult
    {
        [JsonPropertyName("batchcomplete")]
        public string BatchComplete { get; set; }

        [JsonPropertyName("query")]
        public QueryData Query { get; set; }
    }

    public class QueryData
    {
        [JsonPropertyName("searchinfo")]
        public SearchInfo SearchInfo { get; set; }

        [JsonPropertyName("search")]
        public List<SearchItem> Search { get; set; }
    }

    public class SearchInfo
    {
        [JsonPropertyName("totalhits")]
        public int TotalHits { get; set; }
    }

    public class SearchItem
    {
        [JsonPropertyName("ns")]
        public int Namespace { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("wordcount")]
        public int WordCount { get; set; }

        [JsonPropertyName("snippet")]
        public string Snippet { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}