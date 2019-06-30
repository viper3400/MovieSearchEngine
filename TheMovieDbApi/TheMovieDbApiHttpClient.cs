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

namespace TheMovieDbApi
{
    public class TheMovieDbApiHttpClient : IMovieMetaSearch 
    {
        private readonly TheMovieDbApiOptions _apiOptions;
        private readonly HttpClient _httpClient;

        public TheMovieDbApiHttpClient(TheMovieDbApiOptions apiOptions)
        {
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
           return SearchApiByTitle(Title).Result;
        }

        internal async Task<List<MovieMetaMovieModel>> SearchApiByTitle(string Title)
        {
            var requestResult = await _httpClient.GetAsync($"/3/search/movie?api_key={_apiOptions.ApiKey}&language=de-DE&query={Title}");
            var requestContent = await requestResult.Content.ReadAsStringAsync();
            var pagedResult = JsonConvert.DeserializeObject<PagedSearchResultModel>(requestContent);

            var resultList = new List<MovieMetaMovieModel>();
            foreach (var entry in pagedResult.results)
            {
                resultList.Add(ConvertModel(entry));
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
            return new MovieMetaMovieModel()
            {
                ImgUrl = JoinImagePath(inputModel.PosterPath),
                Plot = inputModel.Overview,
                MetaEngine = "theMovieDb",
                Title = inputModel.Title,
                OriginalTitle = inputModel.OrginalTitle,
                Reference = inputModel.Id.ToString(),
                Rating = inputModel.VoteAverage.ToString()
            };
        }

        internal MovieMetaMovieModel ConvertModel(SearchResultModel inputModel)
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
