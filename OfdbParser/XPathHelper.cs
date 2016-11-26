using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace OfdbParser
{
    public static class XPathHelper
    {
        public static List<string> GetXPathValue(XmlDocument xmlDocument, string xPath)
        {
            XPathNavigator nav = xmlDocument.CreateNavigator();

            // Compile a standard XPath expression
            XPathExpression expr;
            expr = nav.Compile(xPath);
            XPathNodeIterator iterator = nav.Select(expr);

            var result = new List<string>();

            while (iterator.MoveNext())
            {
                result.Add(iterator.Current.OuterXml);

            }

            return result;
        }

        public static XmlDocument GenerateXmlDocument (string SourceString)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(SourceString);
            return xDoc;
        }

        public static string EscapeJavaScript(string SourceString)
        {

            var regex = new Regex("(.+)(onmouseover=\"Tip\\(.+?\\)\")(.+)");
            var match = regex.Match(SourceString);
            if (match.Success)
            {
                var decodedString = match.Groups[2].Value.Replace("<", "&lt;").Replace(">", "&gt;");
                //var decodedString = HtmlAgilityPack.HtmlDocument.GetXmlName(match.Groups[2].Value);
                SourceString = match.Groups[1].Value + decodedString + match.Groups[3].Value;

            }
            

            return SourceString;
            
        }
    }
}
