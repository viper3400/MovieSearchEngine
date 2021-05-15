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

        [JsonProperty("production_countries")]
        public IEnumerable<ProductionCountryModel> ProductionCountries { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }
    }
}
