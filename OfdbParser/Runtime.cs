using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using libjfunx.logging;

namespace OfdbParser
{
    public static class Runtime
    {
        /// <summary>
        /// Parsed den übergebenen String um die Laufzeit in Minuten zu ermitteln.
        /// </summary>
        /// <param name="Runtime"></param>
        /// <returns>Laufzeit in Minuten</returns>
        public static string Parse(string Runtime)
        {
            // Einige bekannte Formate lassen sich am ersten Doppelpunkt spalten, 
            // dies sind dann die Minuten.
            // Um eventuelle weitere Formate ermitteln zu können, loggen wir den ursprünglichen Zeitstring mit.

            Logger.Log(LogEintragTyp.Debug, "Parsing string: " + Runtime);
            string runtimeMinutes = Runtime.Split(':').FirstOrDefault();
            Int32 temp;
            if (!Int32.TryParse(runtimeMinutes, out temp))
            {
                // Nach dem "Spalten" sollte sich die Zeit in Minuten in einen Intergerwert umwandeln lassen
                // Wenn nicht, so müssen wir weitere Formate berücksichtigen:
                // Wir versuchen dann, aus eine String alle Zahlen zu ermitteln
                runtimeMinutes = Regex.Replace(Runtime, "[^0-9]+", string.Empty);
            }

            Logger.Log(LogEintragTyp.Debug, "Parsed to time string: " + runtimeMinutes);
            return runtimeMinutes;
        }

    }
}
