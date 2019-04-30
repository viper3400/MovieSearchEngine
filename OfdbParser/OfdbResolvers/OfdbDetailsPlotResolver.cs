using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbDetailsPlotResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            var link = new OfdbDetailsPlotLinkResolver().Resolve(SourceString);
            var request = new XPathAgilityPackSelector(link);
            var searchResults = request.GetXPathValues("/html//p[@class=\"Blocksatz\"]/font/b[contains(text(),\"Eine Inhaltsangabe\")]/following-sibling::text()");
            searchResults = searchResults.Select(r => r.TrimEnd()).ToList();
            var result = string.Join("", searchResults);
            return result;
        }

        public T Resolve<T>(List<string> SourceList)
        {
            var resultList = new List<string>();
            resultList.Add(Resolve(SourceList.FirstOrDefault()));
            return (T)Convert.ChangeType(resultList, typeof(T));
            //return  new List<string>() { Resolve(SourceList.FirstOrDefault()) };
        }
    }
}
