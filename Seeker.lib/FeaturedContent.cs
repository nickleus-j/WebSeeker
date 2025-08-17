using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Seeker.lib
{
    public class FeaturedContent
    {
        [JsonPropertyName("tfa")]
        public WikiArticle TFA { get; set; }

        [JsonPropertyName("mostread")]
        public MostRead MostRead { get; set; }

        [JsonPropertyName("image")]
        public FeaturedImage Image { get; set; }

        [JsonPropertyName("news")]
        public List<NewsItem> News { get; set; }

        [JsonPropertyName("onthisday")]
        public List<OnThisDayItem> OnThisDay { get; set; }
    }

    public class WikiArticle
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("displaytitle")]
        public string DisplayTitle { get; set; }

        [JsonPropertyName("pageid")]
        public int PageId { get; set; }

        [JsonPropertyName("extract")]
        public string Extract { get; set; }

        [JsonPropertyName("thumbnail")]
        public WikiThumbnail Thumbnail { get; set; }

        [JsonPropertyName("content_urls")]
        public ContentUrls ContentUrls { get; set; }
    }

    public class WikiThumbnail
    {
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
    }

    public class ContentUrls
    {
        [JsonPropertyName("desktop")]
        public ContentUrl Desktop { get; set; }

        [JsonPropertyName("mobile")]
        public ContentUrl Mobile { get; set; }
    }

    public class ContentUrl
    {
        [JsonPropertyName("page")]
        public string Page { get; set; }
    }

    public class MostRead
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("articles")]
        public List<WikiArticle> Articles { get; set; }
    }

    public class FeaturedImage
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("thumbnail")]
        public WikiThumbnail Thumbnail { get; set; }

        [JsonPropertyName("description")]
        public WikiDescription Description { get; set; }
    }

    public class WikiDescription
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }
    }

    public class NewsItem
    {
        [JsonPropertyName("links")]
        public List<WikiArticle> Links { get; set; }
    }

    public class OnThisDayItem
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("pages")]
        public List<WikiArticle> Pages { get; set; }
    }

}
