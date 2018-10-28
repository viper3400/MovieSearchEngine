using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser
{
    public enum XPathSelectionName
    {
        SearchTitleResultTitle,
        SearchTitleResultEngineId,
        SearchTitleResultYear,
        SearchTitleResultCoverImage,
        SearchBarcodeResultTitle,
        SearchBarcodeResultEngineId,
        SearchBarcodeResultYear,
        SearchBarodeResultCoverImage,
        DetailsMovieTitle,
        DetailsProductionCounty,
        DetailsYear,
        DetailsGenres,
        DetailsPlot,
        DetailsActors,
        DetailsCoverImage,
        DetailsEditions,
        DetatilsRating,
        EditionRuntime

    }
    public class XPathSelection
    {
        public XPathSelectionName Name { get; set; }
        public string Url { get; set; }
        public string XPath { get; set; }
        public IResultResolver Resolver { get; set; }
    }
}
