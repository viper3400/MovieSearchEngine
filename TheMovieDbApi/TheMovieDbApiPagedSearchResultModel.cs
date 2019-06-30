using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi
{
    public class TheMovieDbApiPagedSearchResultModel
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        public IEnumerable<TheMovieDbApiSearchResultModel> results { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
