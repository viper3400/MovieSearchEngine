using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMetaEngine
{
    public interface IMovieMetaSearch
    {
        List<MovieMetaMovieModel> SearchMovieByBarcode(string Barcode);
        List<MovieMetaMovieModel> SearchMovieByTitle(string Title);
        List<MovieMetaMovieModel> SearchMovieByEngineId(string EngineId);
    }
}
