# MovieSearchEngine

## Release Notes

See GitHub Milestones and associated issues.

## Update July 2023

Update July 2023: 

PLEASE USE THE TMDB INTERFACE OF THIS LIB!


Due to a redesign of OFDB it's not longer working with this library!

Me for myself, I meanwhile just use TMDB.

I always knew, the OFDB support was very brittle.

I decided to retire the OFDB support.

For now, I just disabled the unit tests.
Depending on some personal projects I'm currently thinking about removing the code 
with a next major version.

Thanks for understanding.

## Data Model

![Model](https://github.com/viper3400/MovieSearchEngine/blob/master/ClassDiagram.png "Model")

## The Movie Db
MovieSearchEngine supports The Movie Db (https://www.themoviedb.org/). To use this you need to register for an The Movie Db API key: https://developers.themoviedb.org/3/getting-started/introduction. Currently there is only German language support.

```csharp
// Configure for TheMovieDbApi
 var apiOptions = new TheMovieDbApiOptions
  {
      UseApi = true,
      ApiKey = "yoursecretkey",
      ApiUrl = "https://api.themoviedb.org",
      ApiImageBaseUrl = "https://image.tmdb.org/t/p/original",
      ApiReferenceKey = "TheMovieDb",
      ApiLanguageCode = "en"
  };
            
// Init a new instance
MovieMetaEngine.IMovieMetaSearch search = new TheMovieDbApiHttpClient(apiOptions);

// Search a movie by barcode (not supported, throws Exception !)
// List<MovieMetaEngine.MovieMetaMovieModel> barcodeResult = search.SearchMovieByBarcode("EANBarcode");

// Search a movie by title
List<MovieMetaEngine.MovieMetaMovieModel> titleResult = search.SearchMovieByTitle("MovieTitle");

// Search a movie by engine id
List<MovieMetaEngine.MovieMetaMovieModel> titleResult = search.SearchMovieByEngineId("EngineId");
```

ApiLanguageCode (Optional): For language configuration see https://developers.themoviedb.org/3/getting-started/languages.

Be aware, that The Movie Db has no edition concept as Ofdb.

## Legacy Branch

In versions 1.x one could also init a search using the "OFDB Gateway XML / JSON Interface" (http://www.ofdbgw.org/). 
This is what I've first integrated but I found that the gateway was not reliable for me.

**So this isn't maintained any longer and also not part of version >= 2.x**

```csharp
// Init a new instance
MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
```

Nevertheless, I've create a legacy branch: https://github.com/viper3400/MovieSearchEngine/tree/legacy and the version is still available at nuget.org.

To install the legacy version from Package Manager Console run 

```
PM> Install-Package Jaxx.MovieMetaEngine -Version 1.2.0.10
```

The UIs within the solution are for testing purpose only and by no means intended for production.

## Credits

This piece of work makes usage of:
* Html Agility Pack: https://github.com/zzzprojects/html-agility-pack
* AutoMapper: https://github.com/AutoMapper/AutoMapper
* Dapplo.Log: https://github.com/dapplo/Dapplo.Log

Licenses may differ.

## Ofdb (retired, unsupported)

Please read and accept this terms:

* This is intended for PERSONAL USE ONLY
* You should RESPECT the conditions for using ofdb.de (https://ofdb.de/view.php?page=faq#a32)
* You should AVOID extensive usage of this code (Catch data only if it's neccessary to avoid high loads on ofdb servers.)
* Visit https://www.ofdb.de once in a while and honour the great work of the OFDB team.
* This is a personal experiment, not an API to OFDB, neither an unofficial nor an official. It may break at any time.

Usage:

```csharp
// Init a new instance
MovieMetaEngine.IMovieMetaSearch search = new OfdbParser.OfdbMovieMetaSearch();

// Search a movie by barcode
List<MovieMetaEngine.MovieMetaMovieModel> barcodeResult = search.SearchMovieByBarcode("EANBarcode");

// Search a movie by title
List<MovieMetaEngine.MovieMetaMovieModel> titleResult = search.SearchMovieByTitle("MovieTitle");

// Search a movie by engine id
List<MovieMetaEngine.MovieMetaMovieModel> titleResult = search.SearchMovieByEngineId("EngineId");
```
### Search By Title

If you search a movie by its title, be aware that you probably need the complete title and the correct spelling and synthax.
When using OFDB the movie "The Avengers" is stored as "Avengers, The" for example. 
You probably have to search this way round for getting a match.

If there is no result at all you will get an empty list.

