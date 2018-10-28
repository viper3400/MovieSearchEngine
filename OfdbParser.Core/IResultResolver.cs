using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser
{
    public interface IResultResolver
    {
        string Resolve(string SourceString);
        T Resolve<T>(List<string> SourceList);
    }
}
