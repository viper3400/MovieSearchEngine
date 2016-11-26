using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    /// <summary>
    /// An IResultResolver which simply passes the input through without manipulation.
    /// </summary>
    public class OfdbPassThroughResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            return SourceString;
        }


        public T Resolve<T>(List<string> SourceList)
        {
            return (T) Convert.ChangeType(SourceList, typeof(T));
        }
    }
}
