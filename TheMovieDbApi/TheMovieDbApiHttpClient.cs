using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using MovieMetaEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TheMovieDbApi.Models;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;

namespace TheMovieDbApi
{
    public class TheMovieDbApiHttpClient : IMovieMetaSearch 
    {
        private readonly TheMovieDbApiOptions _apiOptions;
        private readonly HttpClient _httpClient;
        private readonly ILogger<TheMovieDbApiHttpClient> _logger;

        public TheMovieDbApiHttpClient(TheMovieDbApiOptions apiOptions, ILogger<TheMovieDbApiHttpClient> logger)
        {
            _logger = logger;
            _logger.LogTrace("Created new instance.");

            _apiOptions = apiOptions;
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new System.Uri(_apiOptions.ApiUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<MovieMetaMovieModel> SearchMovieByBarcode(string Barcode)
        {
            throw new NotSupportedException("Searching by EAN / Barcode is not supported by TheMovieDb");
        }

        public List<MovieMetaMovieModel> SearchMovieByEngineId(string EngineId)
        {
            return new List<MovieMetaMovieModel> { SearchApiById(EngineId).Result };
        }

        public List<MovieMetaMovieModel> SearchMovieByTitle(string Title)
        {
            try
            {
                return SearchApiByTitle(Title).Result ?? new List<MovieMetaMovieModel>();
            }
            catch (Exception e)
            {
                _logger.LogError("SearchMovieByTitle (direct): {0}", e.Message);
                throw;
            }
        }

        internal async Task<List<MovieMetaMovieModel>> SearchApiByTitle(string Title)
        {
            _logger.LogTrace("Perfoming new search for title: {0} [{1}] [{2}]", Title, _apiOptions.ApiUrl, _httpClient.GetType().Name);
            var resultList = new List<MovieMetaMovieModel>();

            try
            {
                var requestResult = await _httpClient.GetAsync($"/3/search/movie?api_key={_apiOptions.ApiKey}&language=de-DE&query={HttpUtility.UrlEncode(Title)}").ConfigureAwait(false);
                var requestContent = await requestResult.Content.ReadAsStringAsync();
                var pagedResult = JsonConvert.DeserializeObject<PagedSearchResultModel>(requestContent);


                foreach (var entry in pagedResult.results)
                {
                    resultList.Add(ConvertModel(entry));
                }
            }
            catch (Exception e)
            {
                _logger.LogError("SearchApiByTitle: {0}", e.Message);
            }

            return resultList;
        }

        internal async Task<MovieMetaMovieModel> SearchApiById(string id)
        {
            var requestResult = await _httpClient.GetAsync($"/3/movie/{id}?api_key={_apiOptions.ApiKey}&language=de-DE");
            var requestContent = await requestResult.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IdSearchResultModel>(requestContent);

            // get actos if any
            var metaModel = ConvertModel(result);
            metaModel.Actors = await GetActorsForMovie(id);

            return metaModel;
        }
        internal MovieMetaMovieModel ConvertModel (BasicResultModel inputModel)
        {
            try
            {
                return new MovieMetaMovieModel()
                {
                    ImgUrl = JoinImagePath(inputModel.PosterPath),
                    BackgroundImgUrl = JoinImagePath(inputModel.BackdropPath),
                    Plot = inputModel.Overview,
                    MetaEngine = _apiOptions.ApiReferenceKey,
                    Title = inputModel.Title,
                    OriginalTitle = inputModel.OrginalTitle,
                    Reference = inputModel.Id.ToString(),
                    Rating = inputModel.VoteAverage.ToString()
                };
            }
            catch (Exception e)
            {
                _logger.LogError("ConvertModel BasicResultModel: {0}", e.Message);
                throw;
            }
        }

        internal MovieMetaMovieModel ConvertModel(SearchResultModel inputModel)
        {
            try
            {
                var genresFromFileString = File.ReadAllText("TheMovieDbGenres.json");
                var genresFromFile = JsonConvert.DeserializeObject<List<GenreModel>>(genresFromFileString);

                var metaModel = ConvertModel((BasicResultModel)inputModel);

                if (inputModel.GenreIds.Count() > 0) metaModel.Genres = new List<string>();
                foreach (var genre in inputModel.GenreIds)
                {
                    metaModel.Genres.Add(genresFromFile.FirstOrDefault(g => g.Id == genre).Name);
                }

                return metaModel;
            }
            catch (Exception e)
            {
                _logger.LogError("ConvertModel SearchResultModel: {0}", e.Message);
                throw;
            }    
        }

        internal MovieMetaMovieModel ConvertModel(IdSearchResultModel inputModel)
        {
            // Convert the basic model
            var metaModel = ConvertModel((BasicResultModel)inputModel);

            // add genres if any
            if (inputModel.Genres.Count() > 0) metaModel.Genres = new List<string>();
            foreach (var genre in inputModel.Genres)
            {
                metaModel.Genres.Add(genre.Name);
            }
            
            return metaModel;
        }

        internal async Task<List<MovieMetaActorModel>> GetActorsForMovie(string id)
        {
            var requestResult = await _httpClient.GetAsync($"/3/movie/{id}/credits?api_key={_apiOptions.ApiKey}&language=de-DE");
            var requestContent = await requestResult.Content.ReadAsStringAsync();
            var pagedResult = JsonConvert.DeserializeObject<ActorResultModel>(requestContent);

            var metaActor = new List<MovieMetaActorModel>();

            foreach (var actor in pagedResult.Cast )
            {
                metaActor.Add(new MovieMetaActorModel
                {
                    ActorName = actor.Name,
                    MetaEngine = _apiOptions.ApiReferenceKey,
                    Reference = actor.CreditId
                });
            }

            return metaActor;
        }
        internal string JoinImagePath(string imageFileName)
        {
            return new Uri(_apiOptions.ApiImageBaseUrl + imageFileName).ToString();
        }
    }
}
