using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;
using Seeker.lib.Mappers;
namespace Seeker.lib
{
    public class WikiApiClient
    {
        

        public async Task<string> SearchWikipediaArticlesAsync(string searchTerm)
        {
            string encodedSearch = HttpUtility.UrlEncode(searchTerm);

            // Search for pages
            string searchUrl = $"https://en.wikipedia.org/w/api.php?action=query&list=search&srsearch={encodedSearch}&format=json&origin=*";


            try
            {
                string result = "[]";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(searchUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            result = await content.ReadAsStringAsync();
                        }
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                return $"{{ \"error\": \"{ex.Message}\" }}";
            }
        }
        public async Task<string> SearchWikipediaMediaAsync(string searchTerm)
        {
            string encodedSearch = HttpUtility.UrlEncode(searchTerm);


            // Search for media (images)
            string mediaUrl = $"https://en.wikipedia.org/w/api.php?action=query&generator=search&gsrsearch={encodedSearch}&prop=images&format=json";

            try
            {
                HttpClient client = new HttpClient();
                var mediaResponse = await client.GetStringAsync(mediaUrl);


                return JsonSerializer.Serialize(mediaResponse, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                return $"{{ \"error\": \"{ex.Message}\" }}";
            }
        }
        public async Task<WikipediaSearchResult> SearchForArticleAsync(string searchTerm)
        {
            string jsonObj= await SearchWikipediaArticlesAsync(searchTerm);
            var mapper = new WikiMapper();
            WikipediaSearchResult result =  mapper.MapSearchJsonToObject(jsonObj);
            return result;
        }
        public async Task<string> SearchOpenArticlesAsync(string searchTerm,string entriesLimit="10")
        {
            string encodedSearch = HttpUtility.UrlEncode(searchTerm);

            // Search for pages
            string searchUrl = $"https://en.wikipedia.org/w/api.php?action=opensearch&search={encodedSearch}&limit={entriesLimit}&format=json&origin=*";


            try
            {
                string result = "[]";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(searchUrl))
                    {
                        using (HttpContent content = response.Content)
                        {
                            result = content.ReadAsStringAsync().Result;
                        }
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                return $"{{ \"error\": \"{ex.Message}\" }}";
            }
        }
        public async Task<OpenSearchResult> SearchArticlesAsync(string searchTerm, string entriesLimit = "10")
        {
            string encodedSearch = HttpUtility.UrlEncode(searchTerm);
            string jsonObj = await SearchOpenArticlesAsync(searchTerm, entriesLimit);

            var mapper = new OpenSearchMapper();
            OpenSearchResult result = mapper.MapOpenSearchJson(jsonObj);
            return result;
        }
        public async Task<string> ParseArticlesAsync(string Title)
        {
            string encodedSearch = HttpUtility.UrlEncode(Title);

            // Search for pages
            string searchUrl = $"https://en.wikipedia.org/w/api.php?action=parse&page={encodedSearch}&format=json&origin=*";

            try
            {
                string result = "[]";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(searchUrl).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            result = content.ReadAsStringAsync().Result;
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return $"{{ \"error\": \"{ex.Message}\" }}";
            }
        }
        public async Task<WikiParseResult> GetParsedArticlesAsync(string Title)
        {
            string encodedSearch = HttpUtility.UrlEncode(Title);
            string jsonObj = await ParseArticlesAsync(Title);

            var mapper = new WikiParseMapper();
            WikiParseResult result = mapper.MapParseJson(jsonObj);
            result.Parse.Text.HtmlContent = result.Parse.Text.HtmlContent.Replace("href=\"/wiki/", "href=\"https://en.wikipedia.org/wiki/").Replace("src=\"//upload.wikimedia.org/", "src=\"https://upload.wikimedia.org/");
            return result;
        }
    }
}
