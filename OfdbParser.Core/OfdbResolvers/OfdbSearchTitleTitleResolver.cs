using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbSearchTitleTitleResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            var regex = new Regex("<a.+?>(.+?)<.+");
            var match = regex.Match(SourceString);
            var result = match.Success ? match.Groups[1].Value : "";
            return result;
        }

        public T Resolve<T>(List<string> SourceList)
        {
            throw new NotImplementedException();
        }
    }
}
