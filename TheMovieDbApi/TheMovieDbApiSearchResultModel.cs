using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi
{
    public class TheMovieDbApiSearchResultModel
    {
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("adul")]
        public bool? Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("releas_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("genrre_ids")]
        
        public IEnumerable<int> GenreIds { get; set; }
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("original_title")]
        public string OrginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("popularity")]
        public float? Popularity { get; set; }


        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }

        [JsonProperty("video")]
        public bool? Video { get; set; }

        [JsonProperty("vote_average")]
        public float? VoteAverage { get; set; }

    }
}
