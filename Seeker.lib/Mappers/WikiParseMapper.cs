using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Seeker.lib.Mappers
{
    public class WikiParseMapper
    {
        public WikiParseResult MapParseJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<WikiParseResult>(json, options);
        }
    }
}
