using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbDetailsEdtionsResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(List<string> SourceList)
        {
            var resultList = new List<MovieMetaEngine.MovieMetaEditionModel>();

            
            string lastEditionCountry = "";
            foreach (var line in SourceList)
            {
                var edition = new MovieMetaEngine.MovieMetaEditionModel();
                edition.MetaEngine = "ofdb";

                // Retrieve editions county information
                var editionCountry = GetEditionCountry(line);

                // if it's not empty, it's the first edition in line and contains country informations
                // if it's emtpy, it's another edition belonging to the last country (line or lines above)
                //  > in this case we hold use the lastEditionCounty where the last known country is hold
                if (!String.IsNullOrWhiteSpace(editionCountry))
                {
                    edition.Country = editionCountry;
                    lastEditionCountry = editionCountry;
                }
                else edition.Country= lastEditionCountry;

                // Retrieve edition name
                edition.Name = GetEditionName(line);

                // Retrieve edition reference
                edition.Reference = GetEditionReference(line);

                resultList.Add(edition);
            }

            return (T) Convert.ChangeType(resultList, typeof(T));
        }

        private string GetEditionCountry(string expression)
        {
            var regex = new Regex("<tr valign=\"top\"><td nowrap=\"\"><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Normal\">(.+?):.+?<.+");
            var match = regex.Match(expression);
            var result = match.Success ? match.Groups[1].Value : "";
            return result;            
        }

        private string GetEditionName(string expression)
        {
            //             <a href=\"view.php?page=fassung&fid=258134&vid=396134\">
            var regex = new Regex(".+<a href.+?>(.+?)<.+");
            var match = regex.Match(expression);
            var result = match.Success ? match.Groups[1].Value : "";
            return result;     
        }

        private string GetEditionReference(string expression)
        {
            var regex = new Regex(".+<a href.+fassung&fid=(\\d.+?)&vid=(\\d.+?)\".+");
             var match = regex.Match(expression);
             var result = match.Success ? match.Groups[1].Value + ";" + match.Groups[2].Value : "";
            return result;  

        }
    }
}
