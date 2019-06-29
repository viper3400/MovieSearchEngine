using System;
using Xunit;
using OfdbParser;
using OfdbParser.OfdbResolvers;
using System.Linq;
using System.Text;

namespace MovieSearchEngineXUnitTests
{
    public class OfdbParserTests
    {

        const string CAT_OFFLINE = "OfdbParserTest_OFFLINE";
        const string CAT_ONLINE = "OfdbParserTest_ONLINE";

        private string searchResultString = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('<img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;>',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
        private string searchResultString2 = "<a href=\"film/161764,Fast-&-Furious---Neues-Modell-Originalteile\" onmouseover=\"Tip('&lt;img src=&quot;images/film/161/161764.jpg&quot; width=&quot;120&quot; height=&quot;170&quot;&gt;',SHADOW,true)\">Fast & Furious - Neues Modell. Originalteile.<font size=\"1\"> / Fast & Furious</font> (2009)</a>";


        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbReferenceResolverTest()
        {
            var input = "href=\"film/258652,Der-Kreis\"";
            var expected = "258652";
            var SUT = new OfdbReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleTitleResolverTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "Kreis, Der";
            var SUT = new OfdbSearchTitleTitleResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleTitleResolverTest_2()
        {
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "Fast & Furious - Neues Modell. Originalteile.";
            var SUT = new OfdbSearchTitleTitleResolver();
            var actual = SUT.Resolve(searchResultString2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceResolverTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "257582";
            var SUT = new OfdbSearchTitleReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceResolverTest_2()
        {
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "161764";
            var SUT = new OfdbSearchTitleReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceYearTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "1964";
            var SUT = new OfdbSearchTitleYearResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleReferenceYearTest_2()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "2009";
            var SUT = new OfdbSearchTitleYearResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbDetailsPlotLinkResolverTest()
        {
            var input = "<a href=\"plot/258134,619306,Die-Bestimmung---Divergent\"><b>[mehr]</b></a>";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "http://www.ofdb.de/plot/258134,619306,Die-Bestimmung---Divergent";
            var SUT = new OfdbParser.OfdbResolvers.OfdbDetailsPlotLinkResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbDetailsCoverImageResolverTest()
        {
            var input = "<img src=\"images/film/258/258134.jpg\" alt=\"Bestimmung - Divergent, Die Poster\" border=\"0\" width=\"120\" height=\"170\" itemprop=\"image\">";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "https://ssl.ofdb.de/images/film/258/258134.jpg";
            var SUT = new OfdbParser.OfdbResolvers.OfdbDetailsCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbBarcodeSearchTitleResolverTest()
        {
            var input = "Interstellar (2014)";
            var expected = "Interstellar";
            var SUT = new OfdbParser.OfdbResolvers.OfdbBarcodeSearchTitleResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbBarcodeSearchYearResolverTest()
        {
            var input = "Interstellar (2014)";
            var expected = "2014";
            var SUT = new OfdbParser.OfdbResolvers.OfdbBarcodeSearchYearResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbBarcodeSearchReferenceResolverTest()
        {
            var input = "<a href=\"view.php?page=fassung&fid=268777&vid=396788\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/396/396788_f.jpg&quot; width=&quot;220&quot; height=&quot;255&quot;&gt;',SHADOW,true)\">Blu-ray Disc: Warner Home (Deutschland), FSK 12</a>";
            input = XPathHelper.EscapeJavaScript(input);
            var expected = "268777;396788";
            var SUT = new OfdbBarcodeSearchReferenceResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }




        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleCoverImageTest_1()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString);
            var expected = "images/film/na.gif";
            var SUT = new OfdbSearchTitleCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearchTitleCoverImageTest_2()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&amp;quot;images/film/na.gif&amp;quot; width=&amp;quot;120&amp;quot; height=&amp;quot;168&amp;quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = XPathHelper.EscapeJavaScript(searchResultString2);
            var expected = "images/film/161/161764.jpg";
            var SUT = new OfdbSearchTitleCoverImageResolver();
            var actual = SUT.Resolve(input);

            Assert.Equal(expected, actual);
        }

     [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void EscapeJavaScriptTest()
        {
            //var input = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('<img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;>',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var input = searchResultString;
            var expected = "<a href=\"film/257582,Der-Kreis\" onmouseover=\"Tip('&lt;img src=&quot;images/film/na.gif&quot; width=&quot;120&quot; height=&quot;168&quot;&gt;',SHADOW,true)\">Kreis, Der<font size=\"1\"> / Kreis, Der</font> (1964)</a>";
            var actual = XPathHelper.EscapeJavaScript(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SubstitutePlaceHolderTest()
        {
            var inputUrl = "http://www.ofdb.de/film/{placeholder},";
            var inputReplace = "12345";
            var expected = "http://www.ofdb.de/film/12345,";
            var actual = OfdbSearch.SubstitutePlaceHolder(inputUrl, inputReplace);
            Assert.Equal(expected, actual);
        }


        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearch_SearchByTitleTest()
        {
            var input = "Kreis, Der";
            var SUT = new OfdbSearch();
            var result = SUT.SearchByTitle(input);
            Assert.Equal("Kreis, Der", result.FirstOrDefault().Title);

        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbSearch_SearchByTitleWithoutResultTest()
        {
            var input = "Kreis,Der";
            var SUT = new OfdbSearch();
            var result = SUT.SearchByTitle(input);
            Assert.Empty(result);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SearchMovieByEngineIdTest()
        {
            //var input = "258134";
            var input = "258134;386665";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);
            Assert.Equal("Bestimmung - Divergent, Die", actual.FirstOrDefault().Title);
            Assert.Equal("139", actual.FirstOrDefault().Length);
            Assert.Equal("4010324039804", actual.FirstOrDefault().Barcode);
        }


        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SearchMovieByEngineIdWithMissingBarcodeTest()
        {
            var input = "258134;410780";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);
            Assert.Equal("Bestimmung - Divergent, Die", actual.FirstOrDefault().Title);
            Assert.Equal("126", actual.FirstOrDefault().Length);
            Assert.Null(actual.FirstOrDefault().Barcode);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SearchMovieByEngineIdWithMissingPlotTest()
        {
            // we search for a movie with missing plot which caused an exception
            // https://github.com/viper3400/MovieSearchEngine/issues/6
            var input = "277170";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);
            Assert.Equal("Kirschblüten und rote Bohnen", actual.FirstOrDefault().Title);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SearchMovieByEngineIdWithInvalidEditionTest()
        {
            var input = "228415;40652";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);
            Assert.Equal("Oma & Bella", actual.FirstOrDefault().Title);
            Assert.Null(actual.FirstOrDefault().Length);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void SearchMovieByBarcodeTest()
        {
            var input = "5051890288042";
            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByBarcode(input);

            Assert.Equal("ofdb", actual.FirstOrDefault().MetaEngine);
            Assert.Equal("Interstellar", actual.FirstOrDefault().Title);
            Assert.Equal("2014", actual.FirstOrDefault().Year);
            Assert.Equal("https://ssl.ofdb.de/images/film/268/268777.jpg", actual.FirstOrDefault().ImgUrl);
            Assert.Equal("268777;396788", actual.FirstOrDefault().Reference);
            Assert.Equal(input, actual.FirstOrDefault().Barcode);

            var rating = Double.Parse(actual.FirstOrDefault().Rating);
            var checkRating = rating > 6 && rating < 9;
            Assert.True(checkRating, String.Format("Rating was ", rating));
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbDetailsPlotCompleteMultiLine()
        {
            var input = "8266;5025";
            var expectedPlotBuilder = new StringBuilder();
            expectedPlotBuilder.Append("Der Professor für Sprachen Henry Higgins (Rex Harrison) geht auf eine Wette ein, ");
            expectedPlotBuilder.Append("nach der er niemanden niederen Standes so trainieren könnte, daß er in der Adelsgesellschaft nicht auffallen würde.");
            expectedPlotBuilder.AppendLine();
            expectedPlotBuilder.Append("Higgins wählt sich das ordinäre Blumenmädchen Eliza Doolittle (Audrey Hepburn) als Zielobjekt aus und beginnt, ");
            expectedPlotBuilder.Append("ihren Akzent wegzutrainieren und ihr Manieren beizubringen. Das ist nicht ganz einfach, aber Eliza ist eine Musterschülerin...");

            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);

            Assert.Equal("My Fair Lady", actual.FirstOrDefault().Title);
            Assert.Equal(expectedPlotBuilder.ToString(), actual.FirstOrDefault().Plot);
        }

        [Fact]
        [Trait("Category", CAT_OFFLINE)]
        public void OfdbDetailsPlotCompleteSingleLine()
        {
            var input = "12143;11883";
            var expectedPlotBuilder = new StringBuilder();
            expectedPlotBuilder.Append("Der Abend ihrer Verlobung soll es sein: Elle Woods (Reese Witherspoon), superchic, beliebt, " +
                "gut gebaut, extrem blond und mit einem Abschluß in Modemarketing ausgezeichnet, erwartet einen beachtlichen Sechskaräter " +
                "von ihrem geliebten Warner (Matthew Davis). Doch der will nach Harvard gehen, wo man derlei Blondchen dem" +
                " Familienwillen opfern muß, wenn man mit dreißig Jahren Senator sein will. Ergo wird Elle vor die Tür gesetzt. " +
                "Nur gibt diese nicht auf, denn nur weil sie blond ist, ist sie noch lange nicht blöd. Zwar extrem beverly-hills-verhaltensgeschädigt, " +
                "aber hochintelligent schafft sie den Harvardeignungstest für Jura und fällt mit den neuesten Modetrends in der steifen Universitätsstadt ein, " +
                "wie die Hunnen in Europa. Als man sie dort auflaufen lassen will, besinnt sie sich auf Universitätstugenden und wird zur " +
                "ernstzunehmenden Jurastudentin, die bald Gelegenheit hat, in einem Mordprozeß ihre speziellen Kenntnisse anzuwenden...");

            var SUT = new OfdbSearch();
            var actual = SUT.SearchMovieByEngineId(input);

            Assert.Equal("Natürlich blond - Vor dem Gesetz sind alle blond!", actual.FirstOrDefault().Title);
            Assert.Equal(expectedPlotBuilder.ToString(), actual.FirstOrDefault().Plot);
        }
    }
}
