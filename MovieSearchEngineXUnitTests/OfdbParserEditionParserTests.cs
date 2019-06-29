using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace MovieSearchXEngineUnitTests
{
    public class OfdbParserEditionParserTests
    {
        private List<string> input
        {
            get
            {
                var s = new List<string>();

                s.Add("<tr valign=\"top\"><td nowrap=\"\"><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Normal\">Deutschland:&nbsp;&nbsp;</font></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=385676\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/385/385676_f.jpg&quot; width=&quot;220&quot; height=&quot;315&quot;&gt;',SHADOW,true)\">DVD: Concorde</a></b><font class=\"Klein\"> KV</font></font></td></tr>");
                s.Add("<tr valign=\"top\"><td nowrap=\"\"></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=386665\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/386/386665_f.jpg&quot; width=&quot;220&quot; height=&quot;274&quot;&gt;',SHADOW,true)\">Blu-ray Disc: Concorde (Deluxe Fan Edition)</a></b><font class=\"Klein\"> K</font></font></td></tr>");
                s.Add("<tr valign=\"top\"><td nowrap=\"\"></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=386666\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/386/386666_f.jpg&quot; width=&quot;220&quot; height=&quot;256&quot;&gt;',SHADOW,true)\">Blu-ray Disc: Concorde (Deluxe Fan Edition) (ohne Schuber)</a></b><font class=\"Klein\"> K</font></font></td></tr>");
                s.Add("<tr valign=\"top\"><td nowrap=\"\"></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=379177\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/379/379177_f.jpg&quot; width=&quot;220&quot; height=&quot;311&quot;&gt;',SHADOW,true)\">Kino: Concorde Filmverleih</a></b> <font class=\"Klein\">10.04.2014</font></font></td></tr>");
                s.Add("<tr valign=\"top\"><td nowrap=\"\"></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=396134\">Pay-TV: sky Cinema</a></b> <font class=\"Klein\">14.03.2015</font></font></td></tr>");
                s.Add("<tr valign=\"top\"><td nowrap=\"\"><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Normal\">USA:&nbsp;&nbsp;</font></td><td nowrap=\"\">&nbsp;</td><td><font face=\"Arial,Helvetica,sans-serif\" size=\"2\" class=\"Daten\"><b><a href=\"view.php?page=fassung&fid=258134&vid=390402\" onmouseover=\"Tip('&lt;img src=&quot;images/fassung/390/390402_f.jpg&quot; width=&quot;220&quot; height=&quot;276&quot;&gt;',SHADOW,true)\">Blu-ray Disc: Summit (Steelbook) (BD & DVD) (Best Buy exkl.)</a></b><font class=\"Klein\"></font></font></td></tr>");

                return s;
            }
        }

        private List<MovieMetaEngine.MovieMetaEditionModel> expectedEditionModel
        {
            get
            {
                var expected = new List<MovieMetaEngine.MovieMetaEditionModel>();

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = "DVD: Concorde",
                    Country = "Deutschland",
                    Reference = "258134;385676"
                });

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = "Blu-ray Disc: Concorde (Deluxe Fan Edition)",
                    Country = "Deutschland",
                    Reference = "258134;386665"
                });

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = "Blu-ray Disc: Concorde (Deluxe Fan Edition) (ohne Schuber)",
                    Country = "Deutschland",
                    Reference = "258134;386666"
                });

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = "Kino: Concorde Filmverleih",
                    Country = "Deutschland",
                    Reference = "258134;379177"
                });

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = "Pay-TV: sky Cinema",
                    Country = "Deutschland",
                    Reference = "258134;396134"
                });

                expected.Add(new MovieMetaEngine.MovieMetaEditionModel()
                {
                    MetaEngine = "ofdb",
                    Name = ">Blu-ray Disc: Summit (Steelbook) (BD & DVD) (Best Buy exkl.)",
                    Country = "Deutschland",
                    Reference = "258134;390402"
                });


                return expected;
            }
        }

        [Trait("Category","CAT_OFFLINE")]
        [Fact]
        public void OfdbDetailsEdtionsResolverTest()
        {
            var SUT = new OfdbParser.OfdbResolvers.OfdbDetailsEdtionsResolver();
            var actual = SUT.Resolve<List<MovieMetaEngine.MovieMetaEditionModel>>(input);

            var expected = expectedEditionModel.FirstOrDefault(e => e.Reference == "258134;396134");
            var actualSUT = actual.FirstOrDefault(e => e.Reference == "258134;396134");
            Assert.Equal(expected.MetaEngine, actualSUT.MetaEngine);
            Assert.Equal(expected.Country, actualSUT.Country);
            Assert.Equal(expected.Name, actualSUT.Name);
        }
    }


}
