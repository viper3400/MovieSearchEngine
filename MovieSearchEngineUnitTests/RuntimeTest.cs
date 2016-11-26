using OfdbWebGatewayConnector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MovieSearchEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for RuntimeExtractorTest and is intended
    ///to contain all RuntimeExtractorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RuntimeTest
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
        ///A test for Parse
        ///</summary>
        [TestMethod()]
        [TestCategory("OfdbWgTest")]
        public void ParseTest()
        {
            string runtime = "113:20 Min.";
            string expected = "113";
            string actual;
            actual = OfdbWebGatewayConnector.Runtime.Parse(runtime);
            Assert.AreEqual(expected, actual);

            runtime = "98:39 Min. (92:07 Min. o. A.)";
            expected = "98";
            actual = OfdbWebGatewayConnector.Runtime.Parse(runtime);
            Assert.AreEqual(expected, actual);

            runtime = "	ca. 166 Min.";
            expected = "166";
            actual = OfdbWebGatewayConnector.Runtime.Parse(runtime);
            Assert.AreEqual(expected, actual);
        }
    }
}
