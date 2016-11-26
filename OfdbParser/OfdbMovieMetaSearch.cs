using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMetaEngine;

namespace OfdbParser
{
    public class OfdbMovieMetaSearch : IMovieMetaSearch
    {
        public List<MovieMetaMovieModel> SearchMovieByBarcode(string Barcode)
        {
            var search = new OfdbSearch();
            return search.SearchMovieByBarcode(Barcode);
        }

        public List<MovieMetaMovieModel> SearchMovieByTitle(string Title)
        {
            var search = new OfdbSearch().SearchByTitle(Title);

            var result = new List<MovieMetaMovieModel>();

            foreach(var s in search)
            {
                result.Add(new MovieMetaMovieModel()
                    {
                        MetaEngine = "ofdb",
                        Title = s.Title,
                        Reference = s.EngineId,
                        Year = s.Year,
                        ImgUrl = "http://www.ofdb.de/" + s.CoverImage
                    });
            }

            return result;
        }

        public List<MovieMetaMovieModel> SearchMovieByEngineId(string EngineId)
        {
            var search = new OfdbSearch();
            return search.SearchMovieByEngineId(EngineId);
        }
    }
}
