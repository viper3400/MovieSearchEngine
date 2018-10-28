using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbEditionRuntimeResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {            
            // Parse runtime string to get the dedicated runtime format
            return Runtime.Parse(SourceString);
        }

        public T Resolve<T>(List<string> SourceList)
        {
            var resultList = new List<string>();
            resultList.Add(Resolve(SourceList.FirstOrDefault()));
            return (T)Convert.ChangeType(resultList, typeof(T));            
        }
    }
}
