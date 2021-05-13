using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi.Models
{
    public class ProductionCountryModel
    {
        [JsonProperty("iso_3166_1")]
        public string Iso_3166_1 { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
