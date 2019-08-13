using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Binder;
using System.Text;
using TheMovieDbApi;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using MovieMetaEngine;
using Xunit.Abstractions;
using Microsoft.Extensions.Logging;

namespace MovieSearchEngineXUnitTests
{
    public class TheMovieDbApiShould
    {
        private readonly ITestOutputHelper _output;
        private readonly TheMovieDbApiOptions _apiOptions;
        public TheMovieDbApiShould(ITestOutputHelper output)
        {
            _output = output;

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
            var client =  new TheMovieDbApiHttpClient(_apiOptions, new LoggerFactory().CreateLogger<TheMovieDbApiHttpClient>());
            var result = client.SearchMovieByTitle("Drachenzähmen leicht gemacht");
            var actual = result.FirstOrDefault(m => m.Reference == "166428");

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Drachenzähmen leicht gemacht 3: Die geheime Welt", actual.Title);
            Assert.Contains("Abenteuer", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Familie", actual.Genres);
            Assert.Equal(3, actual.Genres.Count());
        }

        [Fact]
        public void SearchMovieByTitleWithSpecialChar()
        {
            var client = new TheMovieDbApiHttpClient(_apiOptions, new LoggerFactory().CreateLogger<TheMovieDbApiHttpClient>());
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
            var client = new TheMovieDbApiHttpClient(_apiOptions, new LoggerFactory().CreateLogger<TheMovieDbApiHttpClient>());
            var actual = client.SearchMovieByEngineId("166428").FirstOrDefault();            

            Assert.IsType<MovieMetaEngine.MovieMetaMovieModel>(actual);
            Assert.Equal("Drachenzähmen leicht gemacht 3: Die geheime Welt", actual.Title);

            // Check genres
            Assert.Contains("Abenteuer", actual.Genres);
            Assert.Contains("Animation", actual.Genres);
            Assert.Contains("Familie", actual.Genres);
            Assert.Equal(3, actual.Genres.Count());

            // Check actors
            Assert.Equal(20, actual.Actors.Count());
            Assert.Equal("Jay Baruchel", actual.Actors.FirstOrDefault(a => a.Reference == "5c6d150b0e0a262c999fbcb3").ActorName);
        }

        [Fact]
        public void SearchMovieByTitleMultiThreads()
        {
            var tasks = new List<Task<List<MovieMetaMovieModel>>>();
            Func<object, List<MovieMetaMovieModel>> action = (object obj) =>
            {
                var api = new TheMovieDbApiHttpClient(_apiOptions, new LoggerFactory().CreateLogger<TheMovieDbApiHttpClient>());
                var result = api.SearchMovieByTitle("Drachenzähmen leicht gemacht");
                _output.WriteLine(result.FirstOrDefault().BackgroundImgUrl);
                return result;
            };

            // Construct started tasks
            for (int i = 0; i < 10; i++)
            {
                int index = i;
                tasks.Add(Task<List<MovieMetaMovieModel>>.Factory.StartNew(action, index));
            }

            try
            {
                // Wait for all the tasks to finish.
                Task.WaitAll(tasks.ToArray());

                // We should never get to this point
                _output.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    _output.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }

        }

        [Fact]
        public void SearchUnknowMovie()
        {
            var client = new TheMovieDbApiHttpClient(_apiOptions, new LoggerFactory().CreateLogger<TheMovieDbApiHttpClient>());
            var actual = client.SearchMovieByTitle("Caché (DVD - 2006)");

            Assert.IsType<List<MovieMetaMovieModel>>(actual);
            Assert.Empty(actual);
            
        }
    }
}
