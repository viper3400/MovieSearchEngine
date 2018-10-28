using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbReferenceResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            var split = SourceString.Split('/');
            split = split[1].Split(',');
            return split[0];
        }

        public T Resolve<T>(List<string> SourceList)
        {
            throw new NotImplementedException();
        }
    }
}
