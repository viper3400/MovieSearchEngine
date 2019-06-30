using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi.Models
{
    public class IdSearchResultModel : BasicResultModel
    {
        [JsonProperty("genres")]
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}
