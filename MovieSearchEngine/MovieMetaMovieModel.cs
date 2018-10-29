using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMetaEngine
{
    public class MovieMetaMovieModel
    {
        public string MetaEngine { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string OriginalTitle { get; set; }
        public string Year { get; set; }
        public string ProductionCountry { get; set; }
        public string ImgUrl { get; set; }
        public string Length { get; set; }
        public List<MovieMetaActorModel> Actors { get; set;}
        public string Plot { get; set; }     
        public string Rating { get; set; }   
        public List<MovieMetaEditionModel> Editions {get; set; }
        public List<string> Genres { get; set; }
    }
}
