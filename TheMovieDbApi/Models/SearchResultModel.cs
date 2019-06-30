using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi.Models
{
    public class SearchResultModel : BasicResultModel
    {
        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }
    }
}
