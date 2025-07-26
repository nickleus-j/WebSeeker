using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Seeker.lib
{
    public class OpenSearchResult
    {
        public string SearchTerm { get; set; }
        public List<OpenSearchItem> Results { get; set; } = new();
    }

    public class OpenSearchItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
