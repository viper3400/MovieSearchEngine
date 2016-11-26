using OfdbWebGatewayConnector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MovieSearchEngineUnitTests
{
    
    
    /// <summary>
    ///This is a test class for OfdbModelToMovieMetaModelMapperTest and is intended
    ///to contain all OfdbModelToMovieMetaModelMapperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OfdbModelToMovieMetaModelMapperTest
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
        ///A test for MapToMovieMetaMovieModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapToMovieMetaMovieModelTest()
        {
            OfdbWgDataModel.Movie.ofdbgw ofdbObject = null;          
            MovieMetaEngine.MovieMetaMovieModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapToMovieMetaMovieModel(ofdbObject);
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        ///A test for MapToMovieMetaActorModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapToMovieMetaActorModelTest()
        {
            OfdbWgDataModel.Movie.ofdbgwResultatPerson1 ofdbPerson1 = new OfdbWgDataModel.Movie.ofdbgwResultatPerson1();
            MovieMetaEngine.MovieMetaActorModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapToMovieMetaActorModel(ofdbPerson1);
            AutoMapper.Mapper.AssertConfigurationIsValid();            
        }

        /// <summary>
        ///A test for MapToMovieMetaSearchModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapEintragToMovieMetaMovieModelTest()
        {
            OfdbWgDataModel.Search.ofdbgwEintrag ofdbObject = new OfdbWgDataModel.Search.ofdbgwEintrag();
            MovieMetaEngine.MovieMetaMovieModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapEintragToMovieMetaMovieModel(ofdbObject);
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        ///A test for MapToMovieMetaEditionModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapToMovieMetaEditionModelTest()
        {
            OfdbWgDataModel.Movie.ofdbgwResultatTitel ofdbEdition = null; 
            MovieMetaEngine.MovieMetaEditionModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapToMovieMetaEditionModel(ofdbEdition);
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        ///A test for MapEanToMovieMetaMovieModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapEanToMovieMetaMovieModelTest()
        {
            OfdbWgDataModel.Ean.ofdbgwResultat ofdbObject = new OfdbWgDataModel.Ean.ofdbgwResultat();
            MovieMetaEngine.MovieMetaMovieModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapEanToMovieMetaMovieModel(ofdbObject);
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        /// <summary>
        ///A test for MapToMovieMetaMovieModel
        ///</summary>
        [TestMethod()]
        [TestCategory("AutoMapperTests")]
        public void MapToMovieMetaMovieModelTest1()
        {
            OfdbWgDataModel.Fassung.ofdbgw ofdbObject = new OfdbWgDataModel.Fassung.ofdbgw();            
            MovieMetaEngine.MovieMetaMovieModel actual;
            actual = OfdbWebGatewayConnector.OfdbModelToMovieMetaModelMapper.MapToMovieMetaMovieModel(ofdbObject);
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
