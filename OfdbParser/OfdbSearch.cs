using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieMetaEngine;
using Dapplo.Log;

namespace OfdbParser
{
    public class OfdbSearch
    {
        private static readonly LogSource Log = new LogSource();

        public List<OfdbSearchTitleResult> SearchByTitle(string Title)
        {
            Log.Debug().Write($"Title: {Title}");
            var searchNames = new XPathSelectionName[]
            {
                 XPathSelectionName.SearchTitleResultTitle,
                 XPathSelectionName.SearchTitleResultEngineId,
                 XPathSelectionName.SearchTitleResultYear,
                 XPathSelectionName.SearchTitleResultCoverImage
            };
            var searchSelections = from s in OfdbXPathSelections.GetSelections()
                                   where searchNames.Contains(s.Name)
                                   select s;

            var url = SubstitutePlaceHolder(searchSelections.FirstOrDefault().Url, Title);
            var request = new XPathAgilityPackSelector(url);
            var searchResults = request.GetXPathValues(searchSelections.FirstOrDefault().XPath);

            List<OfdbSearchTitleResult> result = new List<OfdbSearchTitleResult>();

            Log.Debug().Write($"Found {searchResults.Count()} entries.");

            foreach (var searchResult in searchResults)
            {                
                OfdbSearchTitleResult titleResult = new OfdbSearchTitleResult();

                var titleGetter = searchSelections.Where(s => s.Name == XPathSelectionName.SearchTitleResultTitle).FirstOrDefault();
                titleResult.Title = titleGetter.Resolver.Resolve(searchResult);

                var yearGetter = searchSelections.Where(s => s.Name == XPathSelectionName.SearchTitleResultYear).FirstOrDefault();
                titleResult.Year = yearGetter.Resolver.Resolve(searchResult);

                var engineIdGetter = searchSelections.Where(s => s.Name == XPathSelectionName.SearchTitleResultEngineId).FirstOrDefault();
                titleResult.EngineId = engineIdGetter.Resolver.Resolve(searchResult);

                var coverGetter = searchSelections.Where(s => s.Name == XPathSelectionName.SearchTitleResultCoverImage).FirstOrDefault();
                titleResult.CoverImage = coverGetter.Resolver.Resolve(searchResult);


                result.Add(titleResult);
            }

            return result;


        }


        public List<MovieMetaMovieModel> SearchMovieByEngineId(string EngineId)
        {
            Log.Debug().Write($"EngineId: {EngineId}");
            string movieReference = "";
            string editionReference = "";

            if (EngineId.Contains(";"))
            {
                var references = EngineId.Split(';');
                movieReference = references[0];
                editionReference = references[1];
                Log.Debug().Write($"MovieReference: {movieReference}, EditionReference: {editionReference}");
            }
            else movieReference = EngineId;

            var resultList = GetDataForMovieReference(movieReference);
            if (!String.IsNullOrWhiteSpace(editionReference) && resultList.FirstOrDefault().Editions != null)
            {
                resultList = GetDataForEditionReference(movieReference, editionReference, resultList);
            }
            else Log.Debug().Write($"No edition reference provided or no editions found.");

            return resultList;
        }

        /// <summary>
        /// Gets all possible data for a given movie reference (Filmreferenz)
        /// </summary>
        /// <param name="EngineId"></param>
        /// <returns></returns>
        private List<MovieMetaMovieModel> GetDataForMovieReference(string EngineId)
        {
            // prepare the result             
            var result = new MovieMetaMovieModel();
            result.MetaEngine = "ofdb";
            result.Reference = EngineId;

            // Get all desired search objects
            var searchObjects = new XPathSelectionName[]
            {
                 XPathSelectionName.DetailsMovieTitle,
                 XPathSelectionName.DetailsProductionCounty,
                 XPathSelectionName.DetailsYear,
                 XPathSelectionName.DetailsGenres,
                 XPathSelectionName.DetailsPlot,
                 XPathSelectionName.DetailsActors,
                 XPathSelectionName.DetailsCoverImage,
                 XPathSelectionName.DetailsEditions,
                 XPathSelectionName.DetatilsRating
            };

            // Get the url and resolver data for the desired object
            var searchSelections = from s in OfdbXPathSelections.GetSelections()
                                   where searchObjects.Contains(s.Name)
                                   select s;

            // group by url to prevent multiple web requests to one and the same web page
            var urlGroups = from s in searchSelections
                            group s by s.Url into g
                            select g;

            // iterate through the url groups
            foreach (var urlGroup in urlGroups)
            {
                // Get the url and replace its placeholder
                string url = urlGroup.Key;
                url = SubstitutePlaceHolder(url, EngineId);
                // Create a web request with the url
                var request = new XPathAgilityPackSelector(url);

                foreach (var xObject in urlGroup)
                {
                    try
                    {
                        // get the value for the xObjects XPaht
                        var value = request.GetXPathValues(xObject.XPath);

                        // switch the object name to assign the result value to the corresondig field within the classes return object
                        switch (xObject.Name)
                        {
                            case XPathSelectionName.DetailsMovieTitle:
                                result.Title = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.DetailsProductionCounty:
                                result.ProductionCountry = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.DetailsYear:
                                result.Year = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.DetailsGenres:
                                result.Genres = xObject.Resolver.Resolve<List<string>>(value);
                                break;
                            case XPathSelectionName.DetailsPlot:
                                result.Plot = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.DetailsActors:
                                var actors = xObject.Resolver.Resolve<List<MovieMetaActorModel>>(value);
                                result.Actors = actors;
                                break;
                            case XPathSelectionName.DetailsCoverImage:
                                result.ImgUrl = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.DetailsEditions:
                                result.Editions = xObject.Resolver.Resolve<List<MovieMetaEditionModel>>(value);
                                break;
                            case XPathSelectionName.DetatilsRating:
                                result.Rating = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentNullException || ex is NullReferenceException)
                        {
                            // mainly occurs if xpath returns no values 
                            Log.Error().Write($"Error while parsing result for {xObject.Name} mainly because of emtpy data");
                        }
                        else throw ex;                        
                    }
                }
            }

            return new List<MovieMetaMovieModel>() { result };
        }

        private List<MovieMetaMovieModel> GetDataForEditionReference(string movieReference, string editionReference, List<MovieMetaMovieModel> movieResultList)
        {
            // Get desired edition from list
            var desiredEditions = movieResultList.FirstOrDefault().Editions.Where(e => e.Reference.Contains(editionReference));

            // Check if there are editions in order to prevent an argument null exception in further processing
            if (desiredEditions.Count() > 0)
            {
                var desiredEdition = desiredEditions.FirstOrDefault();


                // Get all desired search objects
                var searchObjects = new XPathSelectionName[]
                {
                 XPathSelectionName.EditionRuntime
                };

                // Get the url and resolver data for the desired object
                var searchSelections = from s in OfdbXPathSelections.GetSelections()
                                       where searchObjects.Contains(s.Name)
                                       select s;

                // group by url to prevent multiple web requests to one and the same web page
                var urlGroups = from s in searchSelections
                                group s by s.Url into g
                                select g;

                // iterate through the url groups
                foreach (var urlGroup in urlGroups)
                {
                    // Get the url and replace its placeholder
                    string url = urlGroup.Key;
                    url = SubstitutePlaceHolder(url, String.Format("&fid={0}&vid={1}", movieReference, editionReference));
                    // Create a web request with the url
                    var request = new XPathAgilityPackSelector(url);

                    foreach (var xObject in urlGroup)
                    {
                        try
                        {
                            // get the value for the xObjects XPaht
                            var value = request.GetXPathValues(xObject.XPath);

                            // switch the object name to assign the result value to the corresondig field within the classes return object
                            switch (xObject.Name)
                            {
                                case XPathSelectionName.EditionRuntime:
                                    desiredEdition.Length = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                    break;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            // mainly occurs if xpath returns no values
                        }
                    }

                }

                movieResultList.FirstOrDefault().Reference = String.Format("{0};{1}", movieReference, editionReference);
                movieResultList.FirstOrDefault().Length = desiredEdition.Length;
            }
            else Log.Debug().Write($"No edition found for {editionReference}");

            return movieResultList;
        }

        public List<MovieMetaMovieModel> SearchMovieByBarcode(string Barcode)
        {
            Log.Debug().Write($"Barcode: {Barcode}");
            // prepare the result             
            var result = new MovieMetaMovieModel();
            result.MetaEngine = "ofdb";



            // Get all desired search objects
            var searchObjects = new XPathSelectionName[]
            {
                 XPathSelectionName.SearchBarcodeResultTitle,
                 XPathSelectionName.SearchBarcodeResultEngineId,
                 XPathSelectionName.SearchBarcodeResultYear,
                 XPathSelectionName.SearchBarodeResultCoverImage
            };

            // Get the url and resolver data for the desired object
            var searchSelections = from s in OfdbXPathSelections.GetSelections()
                                   where searchObjects.Contains(s.Name)
                                   select s;

            // group by url to prevent multiple web requests to one and the same web page
            var urlGroups = from s in searchSelections
                            group s by s.Url into g
                            select g;

            // iterate through the url groups
            foreach (var urlGroup in urlGroups)
            {
                // Get the url and replace its placeholder
                string url = urlGroup.Key;
                url = SubstitutePlaceHolder(url, Barcode);
                // Create a web request with the url
                var request = new XPathAgilityPackSelector(url);

                foreach (var xObject in urlGroup)
                {
                    try
                    {
                        // get the value for the xObjects XPaht
                        var value = request.GetXPathValues(xObject.XPath);

                        // switch the object name to assign the result value to the corresondig field within the classes return object
                        switch (xObject.Name)
                        {
                            case XPathSelectionName.SearchBarcodeResultTitle:
                                result.Title = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.SearchBarcodeResultEngineId:
                                result.Reference = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.SearchBarcodeResultYear:
                                result.Year = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                            case XPathSelectionName.SearchBarodeResultCoverImage:
                                result.ImgUrl = xObject.Resolver.Resolve<List<string>>(value).FirstOrDefault();
                                break;
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        // mainly occurs if xpath returns no values
                        Log.Error().Write($"Error while fetching barcode {Barcode}");
                        Log.Debug().Write(ex.StackTrace);
                    }
                }

            }

            return SearchMovieByEngineId(result.Reference);
            //return new List<MovieMetaMovieModel>() { result };
        }


        /// <summary>
        /// Substitute the string {placeholder} in a given string with the given replacement
        /// </summary>
        /// <param name="StringWithPlaceHolder"></param>
        /// <param name="ReplaceString"></param>
        /// <returns></returns>
        public static string SubstitutePlaceHolder(string StringWithPlaceHolder, string ReplaceString)
        {
            var placeholder = "{placeholder}";
            return StringWithPlaceHolder.Replace(placeholder, ReplaceString);
        }


    }
}
