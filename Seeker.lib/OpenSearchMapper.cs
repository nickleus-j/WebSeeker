using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Seeker.lib
{
    public class OpenSearchMapper
    {
        public OpenSearchResult MapOpenSearchJson(string json)
        {
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            var result = new OpenSearchResult
            {
                SearchTerm = root[0].GetString()
            };

            JsonElement titles = root[1];
            JsonElement descriptions = root[2];
            JsonElement urls = root[3];

            for (int i = 0; i < titles.GetArrayLength(); i++)
            {
                result.Results.Add(new OpenSearchItem
                {
                    Title = titles[i].GetString(),
                    Description = descriptions[i].GetString(),
                    Url = urls[i].GetString()
                });
            }

            return result;
        }
    }
}
