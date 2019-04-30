# MovieSearchEngine

Please read and accept this terms:

* This is intended for PERSONAL USE ONLY
* You should RESPECT the conditions for using ofdb.de (https://ssl.ofdb.de/view.php?page=faq#a32)
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
## Search By Title

If you search a movie by its title, be aware that you probably need the complete title and the correct spelling and synthax.
When using OFDB the movie "The Avengers" is stored as "Avengers, The" for example. 
You probably have to search this way round for getting a match.

If there is no result at all you will get an empty list.

## Data Model

![Model](https://github.com/viper3400/MovieSearchEngine/blob/master/ClassDiagram.png "Model")

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
