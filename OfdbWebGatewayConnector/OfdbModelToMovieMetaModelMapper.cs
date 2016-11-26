using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieMetaEngine;
using Ean = OfdbWgDataModel.Ean;
using Movie = OfdbWgDataModel.Movie;
using Search = OfdbWgDataModel.Search;
using Edition = OfdbWgDataModel.Fassung;

namespace OfdbWebGatewayConnector
{
    public static class OfdbModelToMovieMetaModelMapper
    {
        private const string metaEngineIdentifier = "ofdb";

        /// <summary>
        /// Methode zur Umwandlung eines OfdbgwApiSearchByMovieId Ergebnis Objektes in das normalisiert MovieMetaEngine Format
        /// </summary>
        /// <param name="ofdbObject"></param>
        /// <returns></returns>
        public static MovieMetaEngine.MovieMetaMovieModel MapToMovieMetaMovieModel(Movie.ofdbgw ofdbObject)
        {
            Mapper.CreateMap<Movie.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>()
                .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<Movie.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>()
                .ForMember(dest => dest.Title, m => m.MapFrom(s => s.resultat.titel))
                .ForMember(dest => dest.Year, m => m.MapFrom(s => s.resultat.jahr))
                .ForMember(dest => dest.ImgUrl, m => m.MapFrom(s => s.resultat.bild))
                .ForMember(dest => dest.MetaEngine, m => m.UseValue(metaEngineIdentifier))
                .ForMember(dest => dest.Reference, m => m.Ignore()) // die eigentliche ofdb id scheint in diesem Erebnis nicht mehr enthalten zu sein.
                .ForMember(dest => dest.Actors, m => m.ResolveUsing<ActorResolver>().FromMember(s => s.resultat.besetzung))
                //.ForMember(dest => dest.Plot, m => m.MapFrom(s => s.resultat.beschreibung))
                .ForMember(dest => dest.Plot, 
                        m => m.MapFrom(s => String.IsNullOrWhiteSpace(s.resultat.beschreibung) 
                        ? s.resultat.kurzbeschreibung : s.resultat.beschreibung))
                .ForMember(dest => dest.Editions, m => m.ResolveUsing<EditionsResolver>().FromMember(s => s.resultat.fassungen))
                .ForMember(dest => dest.Genres, m => m.MapFrom(s => s.resultat.genre))
                .ForMember(dest => dest.ProductionCountry, m => m.MapFrom(s => s.resultat.produktionsland.name));

            return Mapper.Map<Movie.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>(ofdbObject);
        }

        /// <summary>
        /// Methode zur Umwandlung eines Fassungs Ergebnis Objektes in das normalisiert MovieMetaEngine Format
        /// </summary>
        /// <param name="ofdbObject"></param>
        /// <returns></returns>
        public static MovieMetaEngine.MovieMetaMovieModel MapToMovieMetaMovieModel(Edition.ofdbgw ofdbObject)
        {
            Mapper.CreateMap<Edition.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>()
                .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<Edition.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>()
                .ForMember(dest => dest.Title, m => m.MapFrom(s => s.resultat.titel))
                .ForMember(dest => dest.ImgUrl, m => m.MapFrom(s => s.resultat.bilder[0]))
                .ForMember(dest => dest.MetaEngine, m => m.UseValue(metaEngineIdentifier))
                .ForMember(dest => dest.Length, m => m.MapFrom(s => s.resultat.laufzeit));
                //.ForMember(dest => dest.Reference, m => m.Ignore()); // die eigentliche ofdb id scheint in diesem Erebnis nicht mehr enthalten zu sein.                

            return Mapper.Map<Edition.ofdbgw, MovieMetaEngine.MovieMetaMovieModel>(ofdbObject);
        }




        /// <summary>
        /// Methode zur Umwandlung eine OFDB Suchergebnissen nach Name in ein MovieMetaMovieModel
        /// </summary>
        /// <param name="ofdbObject"></param>
        /// <returns></returns>
        public static MovieMetaEngine.MovieMetaMovieModel MapEintragToMovieMetaMovieModel(Search.ofdbgwEintrag ofdbObject)
        {
            // Ignore all unmapped fields
            Mapper.CreateMap<Search.ofdbgwEintrag, MovieMetaEngine.MovieMetaMovieModel>()
                .ForAllMembers(opt => opt.Ignore());

            // Map the all wanted fields
            Mapper.CreateMap<Search.ofdbgwEintrag, MovieMetaEngine.MovieMetaMovieModel>()
               .ForMember(dest => dest.Title, m => m.MapFrom(s => s.titel))
               .ForMember(dest => dest.OriginalTitle, m => m.MapFrom(s => s.titel_orig))
               .ForMember(dest => dest.Year, m => m.MapFrom(s => s.jahr))
               .ForMember(dest => dest.Reference, m => m.MapFrom(s => s.id))
               .ForMember(dest => dest.ImgUrl, m => m.MapFrom(s => s.bild))
               .ForMember(dest => dest.MetaEngine, m => m.UseValue(metaEngineIdentifier));

            return Mapper.Map<Search.ofdbgwEintrag, MovieMetaEngine.MovieMetaMovieModel>(ofdbObject);
        }
        
        /// <summary>
        /// Methode zur Umwandlung der in OfdbWebGatewayConnectorIdSearch.ofdbgwResultatPerson1 Besetzung ins MovieMetaEngine Actor Format
        /// </summary>
        /// <param name="ofdbPerson1"></param>
        /// <returns></returns>
        public static MovieMetaEngine.MovieMetaActorModel MapToMovieMetaActorModel(Movie.ofdbgwResultatPerson1 ofdbPerson1)
        {
            Mapper.CreateMap<Movie.ofdbgwResultatPerson1, MovieMetaEngine.MovieMetaActorModel>()
                .ForMember(dest => dest.ActorName, m => m.MapFrom(s => s.name))
                .ForMember(dest => dest.Reference, m => m.MapFrom(s => s.id))
                .ForMember(dest => dest.MetaEngine, m => m.UseValue(metaEngineIdentifier));
            
            //Mapper.AssertConfigurationIsValid();
            return Mapper.Map<Movie.ofdbgwResultatPerson1, MovieMetaEngine.MovieMetaActorModel>(ofdbPerson1);
        }

        /// <summary>
        /// Methode zur Umwandlung von einer OFDB Fassung ins normalisiere MovieSearchEngine Format
        /// </summary>
        /// <param name="ofdbEdition"></param>
        /// <returns></returns>
        public static MovieMetaEngine.MovieMetaEditionModel MapToMovieMetaEditionModel(Movie.ofdbgwResultatTitel ofdbEdition)
        {
            // Ignore all unmapped fields
            Mapper.CreateMap<Movie.ofdbgwResultatTitel, MovieMetaEngine.MovieMetaMovieModel>()
                .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<Movie.ofdbgwResultatTitel, MovieMetaEngine.MovieMetaEditionModel>()
                .ForMember(dest => dest.MetaEngine, m => m.UseValue(metaEngineIdentifier))
                .ForMember(dest => dest.Reference, m => m.MapFrom(s => s.id))
                .ForMember(dest => dest.Name, m => m.MapFrom(s => s.name))
                .ForMember(dest => dest.Country, m => m.MapFrom(s => s.land))
                .ForMember(dest => dest.Length, m => m.Ignore());

            return Mapper.Map<Movie.ofdbgwResultatTitel, MovieMetaEngine.MovieMetaEditionModel>(ofdbEdition);
        }

        public static MovieMetaMovieModel MapEanToMovieMetaMovieModel(Ean.ofdbgwResultat ofdbObject)
        {
            Mapper.CreateMap<Ean.ofdbgwResultatEintrag, MovieMetaMovieModel>()
                .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<Ean.ofdbgwResultatEintrag, MovieMetaMovieModel>()
                .ForMember(d => d.MetaEngine, m => m.UseValue(metaEngineIdentifier))
                .ForMember(d => d.Title, m => m.MapFrom(s => s.titel))
                .ForMember(d => d.Reference, m => m.MapFrom(s => s.filmid))                
                .ForMember(d => d.OriginalTitle, m => m.MapFrom(s => s.titel_orig))
                .ForMember(d => d.Year, m => m.MapFrom(s => s.jahr));
                            
            return Mapper.Map<Ean.ofdbgwResultatEintrag,MovieMetaMovieModel>(ofdbObject.eintrag);
            
        }

       
        #region ValueResolvers
       
        /// <summary>
        /// Diese Methode dient zum Auflösen des OFDB Besetzungsarrays, gibt eine normalisierte Liste von List<MovieMetaEngine.MovieMetaActorModel> aus
        /// </summary>
        public class ActorResolver : ValueResolver<Movie.ofdbgwResultatPerson1[], List<MovieMetaEngine.MovieMetaActorModel>>
        {
            protected override List<MovieMetaEngine.MovieMetaActorModel> ResolveCore(Movie.ofdbgwResultatPerson1[] source)
            {
                List<MovieMetaEngine.MovieMetaActorModel> resultList = new List<MovieMetaEngine.MovieMetaActorModel>();
                foreach (var p in source)
                {
                   resultList.Add(MapToMovieMetaActorModel(p));
                }
                return resultList;
            }
        }

        /// <summary>
        /// Diese Methode dient zum Auflösen des OFDB Fassungen Arrays
        /// </summary>
        public class EditionsResolver : ValueResolver<Movie.ofdbgwResultatTitel[], List<MovieMetaEngine.MovieMetaEditionModel>>
        {
            protected override List<MovieMetaEngine.MovieMetaEditionModel> ResolveCore(Movie.ofdbgwResultatTitel[] source)
            {
                List<MovieMetaEngine.MovieMetaEditionModel> resultList = new List<MovieMetaEngine.MovieMetaEditionModel>();
                foreach (var e in source)
                {
                    resultList.Add(MapToMovieMetaEditionModel(e));
                }
                return resultList;
            }
        }
        
       
        #endregion ValueResolvers


    }
}
