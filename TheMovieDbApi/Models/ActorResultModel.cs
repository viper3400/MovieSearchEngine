using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi.Models
{
    public class ActorResultModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public IEnumerable<ActorModel> Cast { get; set; }
    }
}
