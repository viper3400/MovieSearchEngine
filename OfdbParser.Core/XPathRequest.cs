using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Xml;
//using System.Xml.XPath;

namespace OfdbParser
{
    public class XPathRequest
    {      
        XmlDocument xDoc;

        public List<string> GetXPathValues(string XPath)
        {
            var result = XPathHelper.GetXPathValue(xDoc, XPath);

            return result;
        }

        public XPathRequest(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, null);
            htmlWeb.LoadHtmlAsXml(url, xmlTextWriter);

            // rewind the memory stream
            memoryStream.Position = 0;

            // create, fill, and return the xml document
            XmlDocument xmlDoc = new XmlDocument();
            string xmlDocContent = (new StreamReader(memoryStream)).ReadToEnd();
            xmlDoc.LoadXml(xmlDocContent);

            xDoc = xmlDoc;      
        }
    }
}
