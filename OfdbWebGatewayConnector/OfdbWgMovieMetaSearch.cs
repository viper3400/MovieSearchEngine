using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Ean = OfdbWgDataModel.Ean;
using Movie = OfdbWgDataModel.Movie;
using Search = OfdbWgDataModel.Search;
using Edition = OfdbWgDataModel.Fassung;

namespace OfdbWebGatewayConnector
{
    public class OfdbWgMovieMetaSearch : MovieMetaEngine.IMovieMetaSearch
    {
        private string urlBase;

        /// <summary>
        /// Konstruktor der Klasse. Es kann eine Url zur OfdbEnginge übergeben werden, Standardwert
        /// ist "http://ofdbgw.org/" wenn nichts übergeben wird.
        /// </summary>
        /// <param name="UrlBase"></param>
        public OfdbWgMovieMetaSearch(string UrlBase = "http://ofdbgw.org/")
        {
            urlBase = UrlBase;
        }
        
        public List<MovieMetaEngine.MovieMetaMovieModel> SearchMovieByBarcode(string Barcode)
        {
            Ean.ofdbgw result = GenericSearch<Ean.ofdbgw>(urlBase + "searchean/" + Barcode);
            

            // In der Regel sollte bei der Suche nach der EAN ein einziges Ergebnis zurückkommen
            // Wir können somit die Suche gleich nach einer vollen Edition fortsetzen
            // und diese Ergebnis direkt zurückgeben:
            return SearchMovieByEngineId(result.resultat.eintrag.fassungid);

        }


        public List<MovieMetaEngine.MovieMetaMovieModel> SearchMovieByTitle(string Title)
        {
            Search.ofdbgw result = GenericSearch<Search.ofdbgw>(urlBase + "search/" + Title);
            List<MovieMetaEngine.MovieMetaMovieModel> resultList = new List<MovieMetaEngine.MovieMetaMovieModel>();

            foreach (var a in result.resultat)
            {
                    MovieMetaEngine.MovieMetaMovieModel m = new MovieMetaEngine.MovieMetaMovieModel();
                    m = OfdbModelToMovieMetaModelMapper.MapEintragToMovieMetaMovieModel(a);
                    resultList.Add(m);
            }

            return resultList;

        }


        /// <summary>
        /// Gibt die Detailinformationen zu einem Film auf Basis der Ofdb Id zurück.
        /// </summary>
        /// <param name="EngineId">Enhtält der Suchstring ein Semikolon, so kommt die OFDB spezifische Such nach Fassungen zum Tragen.</param>
        /// <returns></returns>
        public List<MovieMetaEngine.MovieMetaMovieModel> SearchMovieByEngineId(string EngineId)
        {
            // Variable für die OFDB Id
            string ofdbId = null;
            // Objekt für ein eventuelle Fassungsresultat erstellen
            Edition.ofdbgw editionResult = null;

            // Wir ermitteln ob nur eine OFDB Id oder eine Kombination aus OFDB Id und Fassungs ID übergeben wurde
            if (EngineId.Contains(';'))
            {
                // Wir splitten die Id am Delimiter auf, Ofdb Id ist der erste Teil
                ofdbId = EngineId.Split(';')[0];

                // Die Daten für die Fassung füllen wir per Anfrage mit dem komplette String ab
                editionResult = GenericSearch<Edition.ofdbgw>(urlBase + "fassung/" + EngineId);
            }
            else ofdbId = EngineId;

            // Wir holen uns nun den Movie-Teil unseres Films anhand der ofdbId ...
            Movie.ofdbgw movieResult = GenericSearch<Movie.ofdbgw>(urlBase + "movie/" + ofdbId);
            
            // ... und mappen das Ergbnis auf unser MetaModel
            MovieMetaEngine.MovieMetaMovieModel m = new MovieMetaEngine.MovieMetaMovieModel();
            m = OfdbModelToMovieMetaModelMapper.MapToMovieMetaMovieModel(movieResult);           
            
            // ToDo: Edition dem Movie hinzufügen. Geht es hier nur um die Länge?
            m.Length = editionResult != null 
                ? Runtime.Parse(editionResult.resultat.laufzeit) : "0";

            // Im Ergebnis scheint die eigentliche OFDB ID dann gar nicht mehr enthalten zu sein
            // Wir setzen sie daher hier nochmals explizit ein.
            m.Reference = EngineId;

            // Wir erstellen die Ergebnisliste
            List<MovieMetaEngine.MovieMetaMovieModel> resultList = new List<MovieMetaEngine.MovieMetaMovieModel>();                  
            resultList.Add(m);
            
            return resultList;            
        }

        /// <summary>
        /// Generates a generic Ofdbgw Websearch with
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl"></param>
        /// <param name="tryCount">Zähler für den aktuellen Durchlauf, Standard 1</param>
        /// <param name="maxTries">Maximale Anzahl der Versuche die unternommen wird</param>
        /// <returns></returns>
        private static T GenericSearch<T>(string requestUrl, int tryCount = 1, int maxTries = 5)
        {
            try
            {
                GenericWebRequest request = new GenericWebRequest();
                T result;

                var rootAttribute = new XmlRootAttribute();
                rootAttribute.ElementName = "ofdbgw";
                rootAttribute.IsNullable = true;

                string resultString = request.GetResponse(requestUrl);
                var statusSerializer = new XmlSerializer(typeof(OfdbWgDataModel.Status.ofdbgw), rootAttribute);
                OfdbWgDataModel.Status.ofdbgw status = (OfdbWgDataModel.Status.ofdbgw)statusSerializer.Deserialize(new System.IO.StringReader(resultString));
                if (status.status.rcode != "0") throw new System.Net.WebException(status.status.rcodedesc.ToString());


                var xmlSerializer = new XmlSerializer(typeof(T), rootAttribute);
                result = (T)xmlSerializer.Deserialize(new System.IO.StringReader(resultString));
                return result;
            }
            catch (Exception e)
            {
                if (tryCount < maxTries)
                {
                    tryCount++;
                    System.Threading.Thread.Sleep(2000);
                    return GenericSearch<T>(requestUrl, tryCount, maxTries);
                }
                else throw e;
            }


        }
    }
}
