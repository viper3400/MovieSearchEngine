﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OfdbParser.OfdbResolvers
{
    public class OfdbDetailsCoverImageResolver : IResultResolver
    {
        public string Resolve(string SourceString)
        {
            var regex = new Regex("src=\"(.+?)\"");
            var match = regex.Match(SourceString);
            var result = match.Success ? "https://ofdb.de/" + match.Groups[1].Value : "";
            return result;
        }

        public T Resolve<T>(List<string> SourceList)
        {
            var resultList = new List<string>();
            resultList.Add(Resolve(SourceList.FirstOrDefault()));
            return (T)Convert.ChangeType(resultList, typeof(T));
        }
    }
}
