using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using System.Text;
using TheMovieDbApi;
using Xunit;
using System.Linq;

namespace MovieSearchEngineXUnitTests
{
    public class TheMovieDbApiShould
    {

        [Fact]
        public void SearchMovieByTitle()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json")
                .Build();

            var apiOptions = new TheMovieDbApiOptions
            {
                UseApi = configuration.GetValue<bool>("TheMovieDBApi:UseApi"),
                ApiKey = configuration.GetValue<string>("TheMovieDBApi:ApiKey"),
                ApiUrl = configuration.GetValue<string>("TheMovieDBApi:ApiUrl"),
                ApiImageBaseUrl = configuration.GetValue<string>("TheMovieDBApi:ApiImageBaseUrl")
            };

            var api = new TheMovieDbApiHttpClient(apiOptions);
            var result = api.SearchMovieByTitle("Drachenzähmen leicht gemacht");
            var actual = result.FirstOrDefault(m => m.Reference == "166428");

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Drachenzähmen leicht gemacht 3: Die geheime Welt", actual.Title);
        }
    }
}
