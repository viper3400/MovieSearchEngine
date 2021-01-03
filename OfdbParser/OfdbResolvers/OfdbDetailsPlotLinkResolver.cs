using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbDetailsPlotLinkResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            var regex = new Regex("(plot/.+?)\"");
            var match = regex.Match(SourceString);
            var result = match.Success ? "https://ssl.ofdb.de/" + match.Groups[1].Value : "";
            return result;
        }

        public T Resolve<T>(List<string> SourceList)
        {
            throw new NotImplementedException();
        }
    }
}
