using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfdbParser;
using OfdbParser.OfdbResolvers;
using System.Linq;

namespace MovieSearchEngineUnitTests
{
    [TestClass]
    public class OfdbParserTest
    {

        const string CAT_OFFLINE = "OfdbParserTest_OFFLINE";
        const string CAT_ONLINE = "OfdbParserTest_ONLINE";

        private string searchResultString = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('<img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;>',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
        private string searchResultString2 = "<a href=\"film/161764,Fast-&-Furious---Neues-Modell-Originalteile\" onmouseover=\"Tip('&lt;img src=&quot;images/film/161/161764.jpg&quot; width=&quot;120&quot; height=&quot;170&quot;&gt;',SHADOW,true)\">Fast & Furious - Neues Modell. Originalteile.<font size=\"1\"> / Fast & Furious</font> (2009)</a>";
        

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbReferenceResolverTest()
        {
            var input = "href=\"film/258652,Der-Kreis\"";
            var expected = "258652";
            var SUT = new OfdbReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleTitleResolverTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "Kreis, Der";
            var SUT = new OfdbSearchTitleTitleResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleTitleResolverTest_2()
        {
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "Fast & Furious - Neues Modell. Originalteile.";            
            var SUT = new OfdbSearchTitleTitleResolver();
            var actual = SUT.Resolve(searchResultString2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceResolverTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "257582";
            var SUT = new OfdbSearchTitleReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceResolverTest_2()
        {            
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "161764";
            var SUT = new OfdbSearchTitleReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceYearTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "1964";
            var SUT = new OfdbSearchTitleYearResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceYearTest_2()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "2009";
            var SUT = new OfdbSearchTitleYearResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbDetailsPlotLinkResolverTest()
        {
            var input = "<a href=\"plot/258134,619306,Die-Bestimmung---Divergent\"><b>[mehr]</b></a>";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "http://www.ofdb.de/plot/258134,619306,Die-Bestimmung---Divergent";
            var SUT = new OfdbParser.OfdbResolvers.OfdbDetailsPlotLinkResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbDetailsCoverImageResolverTest()
        {
            var input = "<img src=\"images/film/258/258134.jpg\" alt=\"Bestimmung - Divergent, Die Poster\" border=\"0\" width=\"120\" height=\"170\" itemprop=\"image\">";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "https://ssl.ofdb.de/images/film/258/258134.jpg";
            var SUT = new OfdbParser.OfdbResolvers.OfdbDetailsCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbBarcodeSearchTitleResolverTest()
        {
            var input = "Interstellar (2014)";
            var expected = "Interstellar";
            var SUT = new OfdbParser.OfdbResolvers.OfdbBarcodeSearchTitleResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbBarcodeSearchYearResolverTest()
        {
            var input = "Interstellar (2014)";
            var expected = "2014";
            var SUT = new OfdbParser.OfdbResolvers.OfdbBarcodeSearchYearResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

          [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbBarcodeSearchReferenceResolverTest()
        {
            var input = "<a href=\"view.php?page=fassung&fid=268777&vid=396788\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/396/396788_f.jpg&quot; width=&quot;220&quot; height=&quot;255&quot;&gt;',SHADOW,true)\">Blu-ray Disc: Warner Home (Deutschland), FSK 12</a>";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "268777;396788";
            var SUT = new OfdbBarcodeSearchReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }




        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleCoverImageTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "images/film/na.gif";
            var SUT = new OfdbSearchTitleCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void OfdbSearchTitleCoverImageTest_2()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "images/film/161/161764.jpg";
            var SUT = new OfdbSearchTitleCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void EscapeJavaScriptTest()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('<img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;>',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = searchResultString;
            var expected = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var actual = XPathHelper.EscapeJavaScript(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [TestCategory(CAT_OFFLINE)]
        public void SubstitutePlaceHolderTest()
        {
            var inputUrl = "http://www.ofdb.de/film/{placeholder},";
            var inputReplace = "12345";
            var expected = "http://www.ofdb.de/film/12345,";
            var actual = OfdbSearch.SubstitutePlaceHolder(inputUrl, inputReplace);
            Assert.AreEqual(expected, actual);
        }



        [TestMethod()]
        [TestCategory(CAT_ONLINE)]
        public void OfdbSearch_SearchByTitleTest()
        {
            var input = "Kreis, Der";
            var SUT = new OfdbSearch();
            var result = SUT.SearchByTitle(input);

         
        }

        [TestMethod()]
        [TestCategory(CAT_ONLINE)]
        public void SearchMovieByEngineIdTest()
        {
            //var input = "258134";
            var input = "258134;386665";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);
            Assert.Inconclusive();
        }

        [TestMethod()]
        [TestCategory(CAT_ONLINE)]
        public void SearchMovieByBarcodeTest()
        {
            var input = "5051890288042";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByBarcode(input);

            Assert.AreEqual("ofdb", actual.FirstOrDefault().MetaEngine);
            Assert.AreEqual("Interstellar", actual.FirstOrDefault().Title);
            Assert.AreEqual("2014", actual.FirstOrDefault().Year);
            Assert.AreEqual("https://ssl.ofdb.de/images/film/268/268777.jpg", actual.FirstOrDefault().ImgUrl);
            Assert.AreEqual("268777;396788", actual.FirstOrDefault().Reference);
            Assert.AreEqual("7.67", actual.FirstOrDefault().Rating);

        }
    }
}
