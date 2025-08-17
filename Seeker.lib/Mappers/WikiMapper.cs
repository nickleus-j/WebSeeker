using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Seeker.lib.Mappers
{
    public class WikiMapper
    {
        public WikipediaSearchResult MapSearchJsonToObject(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<WikipediaSearchResult>(json, options);
        }
    }
    public class WikiFeaturedMapper
    {
        public FeaturedContent MapFeaturedJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<FeaturedContent>(json, options);
        }
    }
}
