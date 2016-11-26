# MovieSearchEngine

Please read and accept this terms:

* This is intended for PERSONAL USE ONLY
* You should RESPECT the conditions for using ofdb.de (http://www.ofdb.de/view.php?page=faq#a32)
* You should AVOID extensive usage of this code (Catch data only if it's neccessary to avoid high loads on ofdb servers.)
* Visit http://www.ofdb.de once in a while and honour the great work of the OFDB team.
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

If you search a movie by its title, be aware that you probably need the complete title and the correct spelling and synthax.
When using OFDB the movie "The Avengers" is stored as "Avengers, The" for example. 
You probably have to search this way round for getting a match.

You could also init a search using the "OFDB Gateway XML / JSON Interface" (http://www.ofdbgw.org/). 
This is what I've first integrated but I found that the gateway was not reliable for me. 
So this is not maintained any longer.

```csharp
// Init a new instance
MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
```

The UIs within the solution are for testing purpose only and not intended for production by no means.

This piece of work makes usage of the Html Agility Pack: https://htmlagilitypack.codeplex.com/
