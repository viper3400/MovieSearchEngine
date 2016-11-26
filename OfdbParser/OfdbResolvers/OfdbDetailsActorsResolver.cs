using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbDetailsActorsResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(List<string> SourceList)
        {
            var actors = new List<MovieMetaEngine.MovieMetaActorModel>();
            foreach (var s in SourceList)
            {
                actors.Add(new MovieMetaEngine.MovieMetaActorModel() { MetaEngine = "ofdb", ActorName = s });
            }

            return (T)Convert.ChangeType(actors, typeof(T));
        }
    }
}
