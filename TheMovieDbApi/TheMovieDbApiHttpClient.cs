using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using MovieMetaEngine;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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
            var pagedResult = JsonConvert.DeserializeObject<TheMovieDbApiPagedSearchResultModel>(requestContent);

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
            var result = JsonConvert.DeserializeObject<TheMovieDbApiSearchResultModel>(requestContent);
            return ConvertModel(result);
        }
        internal MovieMetaMovieModel ConvertModel (TheMovieDbApiSearchResultModel inputModel)
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

        internal string JoinImagePath(string imageFileName)
        {
            return new Uri(_apiOptions.ApiImageBaseUrl + imageFileName).ToString();
        }
    }
}
