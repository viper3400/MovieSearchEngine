using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Web;

namespace OfdbParser
{
    public class XPathAgilityPackSelector
    {
        private HtmlDocument htmlDocument;
        private HtmlNode baseNode;


        public XPathAgilityPackSelector(string WebUrl)
        {
            htmlDocument = new HtmlDocument();
            var hw = new HtmlAgilityPack.HtmlWeb();
            htmlDocument.OptionOutputAsXml = true;
            htmlDocument.OptionOutputOptimizeAttributeValues = false;
            htmlDocument = hw.Load(String.Format("{0}", WebUrl));
            baseNode = htmlDocument.DocumentNode;
        }

        public List<string> GetXPathValues(string XPath)
        {
            IEnumerable<HtmlAgilityPack.HtmlNode> nodes = Enumerable.Empty<HtmlAgilityPack.HtmlNode>();
            var htmlBuilder = new List<string>();

            nodes = baseNode.SelectNodes(XPath);
            
            if (nodes != null)
            {
                foreach (var n in nodes)
                {
                    htmlBuilder.Add(XPathHelper.EscapeJavaScript(n.OuterHtml));
                } 
            }
            return htmlBuilder;
        }
    }
}
