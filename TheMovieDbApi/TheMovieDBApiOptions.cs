using System;
using System.Collections.Generic;
using System.Text;

namespace TheMovieDbApi
{
    public class TheMovieDbApiOptions
    {
        public bool UseApi { get; set; }
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string ApiImageBaseUrl { get; set; }
        public string ApiReferenceKey { get; set; }
        public string ApiLanguageCode { get; set; }
    }
}
