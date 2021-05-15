using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using TheMovieDbApi;
using Xunit;
using System.Linq;

namespace MovieSearchEngineXUnitTests
{
    public class TheMovieDbApiShould
    {
        private readonly TheMovieDbApiOptions _apiOptions;

        public TheMovieDbApiShould()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("testsettings.json")
               .Build();

            _apiOptions = new TheMovieDbApiOptions
            {
                UseApi = configuration.GetValue<bool>("TheMovieDBApi:UseApi"),
                ApiKey = configuration.GetValue<string>("TheMovieDBApi:ApiKey"),
                ApiUrl = configuration.GetValue<string>("TheMovieDBApi:ApiUrl"),
                ApiImageBaseUrl = configuration.GetValue<string>("TheMovieDBApi:ApiImageBaseUrl"),
                ApiReferenceKey = configuration.GetValue<string>("TheMovieDBApi:ApiReferenceKey")
            };
            
        }

        [Fact]
        public void SearchMovieByTitle()
        {           
            var client =  new TheMovieDbApiHttpClient(_apiOptions);
            var result = client.SearchMovieByTitle("Drachenzähmen leicht gemacht");
            var actual = result.FirstOrDefault(m => m.Reference == "TheMovieDb:166428");

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Drachenzähmen leicht gemacht 3: Die geheime Welt", actual.Title);

            // Check genres
            Assert.Contains("Abenteuer", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Familie", actual.Genres);
            Assert.Equal("TheMovieDb", actual.MetaEngine);
            Assert.Contains("America Ferrera", actual.Actors.Select(a => a.ActorName));
            Assert.Equal("How to Train Your Dragon: The Hidden World", actual.OriginalTitle);
            Assert.Equal("104", actual.Length);
            Assert.Equal("7.8", actual.Rating);
            Assert.Equal("TheMovieDb:166428", actual.Reference);
            Assert.Equal(3, actual.Genres.Count());
            Assert.Equal("Japan, United States of America", actual.ProductionCountry);
            Assert.NotEmpty(actual.Plot);

            // Check actors
            Assert.Equal(20, actual.Actors.Count());
            Assert.Equal("Jay Baruchel", actual.Actors.FirstOrDefault(a => a.Reference == "5c6d150b0e0a262c999fbcb3").ActorName);
            Assert.Equal("2019", actual.Year);
        }

        [Fact]
        public void SearchMovieByTitleWithSpecialChar()
        {
            var client = new TheMovieDbApiHttpClient(_apiOptions);
            var result = client.SearchMovieByTitle("#9");
            var actual = result.FirstOrDefault(m => m.Title == "#9");

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Contains("Abenteuer", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Science Fiction", actual.Genres);
            Assert.Equal(5, actual.Genres.Count());
        }

        [Fact]
        public void SearchMovieById()
        {
            //https://api.themoviedb.org/3//movie/166428?api_key=xxxc&language=de-DE
            var client = new TheMovieDbApiHttpClient(_apiOptions);
            var actual = client.SearchMovieByEngineId("166428").FirstOrDefault();

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Drachenzähmen leicht gemacht 3: Die geheime Welt", actual.Title);

            // Check genres
            Assert.Contains("Abenteuer", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Familie", actual.Genres);
            Assert.Equal("TheMovieDb", actual.MetaEngine);
            Assert.Contains("America Ferrera", actual.Actors.Select(a => a.ActorName));
            Assert.Equal("How to Train Your Dragon: The Hidden World", actual.OriginalTitle);
            Assert.Equal("104", actual.Length);
            Assert.Equal("7.8", actual.Rating);
            Assert.Equal("TheMovieDb:166428", actual.Reference);
            Assert.Equal(3, actual.Genres.Count());
            Assert.Equal("Japan, United States of America", actual.ProductionCountry);
            Assert.NotEmpty(actual.Plot);

            // Check actors
            Assert.Equal(20, actual.Actors.Count());
            Assert.Equal("Jay Baruchel", actual.Actors.FirstOrDefault(a => a.Reference == "5c6d150b0e0a262c999fbcb3").ActorName);
            Assert.Equal("2019", actual.Year);
        }

        [Fact]
        public void SearchMovieByIdinEnLanguage()
        {
            //https://api.themoviedb.org/3//movie/166428?api_key=xxxc&language=en
            _apiOptions.ApiLanguageCode = "en";
            var client = new TheMovieDbApiHttpClient(_apiOptions);
            var actual = client.SearchMovieByEngineId("166428").FirstOrDefault();

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("How to Train Your Dragon: The Hidden World", actual.Title);

            // Check genres
            Assert.Contains("Adventure", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Family", actual.Genres);
            Assert.Equal("TheMovieDb", actual.MetaEngine);
            Assert.Contains("America Ferrera", actual.Actors.Select(a => a.ActorName));
            Assert.Equal("How to Train Your Dragon: The Hidden World", actual.OriginalTitle);
            Assert.Equal("104", actual.Length);
            Assert.Equal("7.8", actual.Rating);
            Assert.Equal("TheMovieDb:166428", actual.Reference);
            Assert.Equal(3, actual.Genres.Count());
            Assert.Equal("Japan, United States of America", actual.ProductionCountry);
            Assert.NotEmpty(actual.Plot);

            // Check actors
            Assert.Equal(20, actual.Actors.Count());
            Assert.Equal("Jay Baruchel", actual.Actors.FirstOrDefault(a => a.Reference == "5c6d150b0e0a262c999fbcb3").ActorName);

            Assert.Equal("2019", actual.Year);
        }

        [Fact]
        public void SearchMovieByTitleExpectMultipleResults()
        {
            var client = new TheMovieDbApiHttpClient(_apiOptions);
            var actual = client.SearchMovieByTitle("Batman");
           

            Assert.IsType<List<MovieMetaEngine.MovieMetaMovieModel>>(actual);
            Assert.Equal(20, actual.Count());
            Assert.All(actual, s => Assert.Contains("Batman", s.Title));
        }

        [Fact]
        public void SearchMovieByIdWithoutRuntime()
        {
            var client = new TheMovieDbApiHttpClient(_apiOptions);
            var actual = client.SearchMovieByEngineId("461049").FirstOrDefault();
            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Im Kreis der Iris", actual.Title);
            Assert.Equal("", actual.Length);

        }
    }
}
