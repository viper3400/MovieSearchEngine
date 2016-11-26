using OfdbWebGatewayConnector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MovieSearchEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for RequestTest and is intended
    ///to contain all RequestTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RequestTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for SearchMovieByTitle
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void SearchMovieByTitleTest()
        {
            OfdbWebGatewayConnector.OfdbWgMovieMetaSearch target = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
            string Title = "hitch"; 
            //System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> expected = null; // TODO: Initialize to an appropriate value
            int expected = 25;
            System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> actual;
            actual = target.SearchMovieByTitle(Title);
            Assert.AreEqual(expected, actual.Count);
            
        }

        /// <summary>
        ///A test for SearchByMovieId with OfdbEdition (over MovieMetaInterface)
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void SearchByMovieIdWithOfdbEditionOverMovieMetaInterfaceTest()
        {
            string requestId = "69878;138582";

            MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch("http://mirror1.ofdbgw.org/");

            System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> actual = search.SearchMovieByEngineId(requestId);

            Assert.AreEqual("113", actual.FirstOrDefault().Length);
            Assert.AreEqual("Hitch - Der Date Doktor", actual.FirstOrDefault().Title);
            Assert.AreEqual("Der Heiratsvermittler Alex \"Hitch\" Hitchens (Will Smith) schafft es, jedem Mann, auch wenn es anfangs noch so hoffnungslos erscheint, ein Date mit einer Frau seiner Wahl zu verschaffen. Dieser Tatsache ist er sich so sicher, dass er sogar eine Geld-zurück-Garantie gibt, wenn sich spätestens nach Date Nummer 3 noch keine Beziehung anbahnt. Doch überall gibt es Ausnahmen und in diesem Fall ist das der Versager Albert (Kevin James). Auch nach etlichen Unterrichtsstunden bei Hitch ist er nicht in der Lage, bei seiner Traumfrau zu landen. Zwischenzeitlich bekommt Hitch es auch noch mit der Undercover-Journalistin Sara (Eva Mendez) zu tun, die endlich Licht in das Geheimnis von seiner Arbeit bringen will. Genauso wie er selbst hat Sara die Hoffnung auf die Liebe aufgegeben, nachdem sie einst bitter enttäuscht wurde. Doch nach und nach kommen die beiden sich näher und Hitch muss selber erleben, wie es ist, wenn man vor seiner Angebeteten kein vernünftiges Wort herausbekommt...",
                actual.FirstOrDefault().Plot);
        }

        /// <summary>
        ///A test for SearchByMovieId with OfdbEdition (over MovieMetaInterface) searching for a 
        ///movie with only a short plot (Kurzebschreibung)
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void SearchByMovieIdWithOfdbEditionOverMovieMetaInterfaceWithShortPlotTest()
        {
            string requestId = "1389;348830";

            MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();

            System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> actual = search.SearchMovieByEngineId(requestId);

            Assert.Inconclusive("");
            Assert.AreEqual("149", actual.FirstOrDefault().Length);
            Assert.AreEqual("Contact", actual.FirstOrDefault().Title);
            Assert.AreEqual("Seit dem zu frühen Tod ihres Vaters ist Dr. Ellie Arroway (Jodie Foster) besessen von der Suche im All nach außerirdischem Leben für die Organisation SETI. Doch der Job ist schwer zu finanzieren, bis sie eines Tages tatsächlich ein Signal aus dem All auffangen. Die mehrfach verschlüsselte Botschaft ist eine absolute Sensation, denn sie enthält eine Bauanleitung für eine unbekannte Maschine, die nach Ansicht der Wissenschaftler, eine Sternenreise ermöglichen soll. Das Projekt wird zum Politikum, alle möglichen Institutionen melden Interesse daran an, die Finanzierung ist wacklig, da teuer. Und die Öffentlichkeit steht auch nicht immer hinter den Forschern. Als es schließlich zur Wahl des Reisekandidaten kommt, wird Ellie übergangen, weil sie reine Wissenschaftlerin und nicht religiös ist. Doch auf das Projekt wird ein Attentat verübt und Ellie ist ihrer Reise noch ferner als zuvor. Zumindest scheint es so...",
                actual.FirstOrDefault().Plot);
        }
 

        /// <summary>
        ///A test for SearchByMovieId (over MovieMetaInterface)
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void SearchByMovieIdOverMovieMetaInterfaceTest()
        {
            string requestId = "69878";

            MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();

            System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> actual = search.SearchMovieByEngineId(requestId);

            Assert.AreEqual("Hitch - Der Date Doktor", actual.FirstOrDefault().Title);
            Assert.AreEqual("2005", actual.FirstOrDefault().Year);

        }

       
        /// <summary>
        ///A test for SearchByEan
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void SearchByEanOverInterfaceTest()
        {
            string requestUrl = "4030521376748";
            MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
            System.Collections.Generic.List<MovieMetaEngine.MovieMetaMovieModel> actual = search.SearchMovieByBarcode(requestUrl);
            
            Assert.AreEqual("Hitch - Der Date Doktor", actual.FirstOrDefault().Title);
            Assert.AreEqual("2005", actual.FirstOrDefault().Year);

        }
    }
}
