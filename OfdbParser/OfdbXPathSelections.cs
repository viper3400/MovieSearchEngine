﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfdbParser.OfdbResolvers;

namespace OfdbParser
{

    static class OfdbXPathSelections
    {
        public static List<XPathSelection> GetSelections()
        {
            List<XPathSelection> xPathSelections = new List<XPathSelection>();

            #region SearchTitle
            // Retrieve SearchTitleResultTitle
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchTitleResultTitle,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}",
                    //XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[following-sibling::i[text()=\"Ungef&auml;hre Ergebnisse\"]]",
                    XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[contains(@href,\"film/\")]",
                    Resolver = new OfdbSearchTitleTitleResolver()
                });

            // Retrieve SearchTitleResultEngineId
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchTitleResultEngineId,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}",
                    //XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[following-sibling::i[text()=\"Ungef&auml;hre Ergebnisse\"]]",
                    XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[contains(@href,\"film/\")]",
                    Resolver = new OfdbSearchTitleReferenceResolver()
                });

            // Retrieve SearchTitleResultYear
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchTitleResultYear,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}",
                    //XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[following-sibling::i[text()=\"Ungef&auml;hre Ergebnisse\"]]",
                    XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[contains(@href,\"film/\")]",
                    Resolver = new OfdbSearchTitleYearResolver()
                });

            // Retrieve SearchTitleResultCoverImage
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchTitleResultCoverImage,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}",
                    //XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[following-sibling::i[text()=\"Ungef&auml;hre Ergebnisse\"]]",
                    XPath = "/html//i[text()=\"Exakte Ergebnisse\"]/following-sibling::a[contains(@href,\"film/\")]",
                    Resolver = new OfdbSearchTitleCoverImageResolver()
                });

            #endregion SearchTitle

            #region SearchBarcode
            // Retrieve SearchBarcodeResultTitle
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchBarcodeResultTitle,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}&Kat=EAN",
                    XPath = "/html//b[text()=\"EAN/UPC:\"]/following-sibling::a[contains(@href,\"film/\") and position()=1]/b/text()",
                    Resolver = new OfdbBarcodeSearchTitleResolver()
                });

            // Retrieve SearchBarcodeResultYear
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchBarcodeResultYear,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}&Kat=EAN",
                    XPath = "/html//b[text()=\"EAN/UPC:\"]/following-sibling::a[contains(@href,\"film/\") and position()=1]/b/text()",
                    Resolver = new OfdbBarcodeSearchYearResolver()
                });

            // Retrieve SearchBarodeResultCoverImage
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchBarodeResultCoverImage,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}&Kat=EAN",
                    XPath = "/html//b[text()=\"EAN/UPC:\"]/following-sibling::a[contains(@href,\"fassung&fid\")]",
                    Resolver = new OfdbBarcodeSearchCoverImageResolver()
                });

            // Retrieve SearchBarodeResultCoverImage
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.SearchBarcodeResultEngineId,
                    Url = "http://www.ofdb.de/view.php?page=suchergebnis&SText={placeholder}&Kat=EAN",
                    XPath = "/html//b[text()=\"EAN/UPC:\"]/following-sibling::a[contains(@href,\"fassung&fid\")]",
                    Resolver = new OfdbBarcodeSearchReferenceResolver()
                });

            #endregion SearchBarcode

            #region DetailsMovie

            // Retrieve DeatailsMovieTile
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsMovieTitle,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = " /html//h1[@itemprop=\"name\"]/font/b/text()",
                    Resolver = new OfdbPassThroughResolver()
                });

            // Retrieve DeatailsProductionLand
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsProductionCounty,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//a[contains(@href,\"view.php?page=blaettern&Kat=Land&Text=\")]/text()",
                    Resolver = new OfdbPassThroughResolver()
                });

            // Retrieve DeatailsYear
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsYear,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//a[contains(@href,\"view.php?page=blaettern&Kat=Jahr&Text=\")]/text()",
                    Resolver = new OfdbPassThroughResolver()
                });

            // Retrieve DetailsGenres
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsGenres,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//span[@itemprop=\"genre\"]/text()",
                    Resolver = new OfdbPassThroughResolver()
                });

            // Retrieve DetailsPlot
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsPlot,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//a[contains(@href,\"plot\")]",
                    Resolver = new OfdbDetailsPlotResolver()
                });

            // Retrieve DetailsActors
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsActors,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//a[@itemprop=\"actor\"]/span[@itemprop=\"name\"]/text()",
                    Resolver = new OfdbDetailsActorsResolver()
                });

            // Retrieve DetailsCoverImage
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsCoverImage,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//img[@itemprop=\"image\"]",
                    Resolver = new OfdbDetailsCoverImageResolver()
                });

            // Retrieve DetailsEditions
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetailsEditions,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//div[text()=\"Fassungen\"]/parent::node()/parent::node()/parent::node()/tr[2]/td[2]/table/tr//a/parent::node()/parent::node()/parent::node()/parent::node()",
                    Resolver = new OfdbDetailsEdtionsResolver()
                });

            // Retrieve DetailsRating
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.DetatilsRating,
                    Url = "http://www.ofdb.de/film/{placeholder},",
                    XPath = "/html//span[@itemprop=\"ratingValue\"]/text()",
                    Resolver = new OfdbPassThroughResolver()
                });

            #endregion DetailsMovie

            #region EditionDetails
            // Retrieve EditionRuntime
            xPathSelections.Add(
                new XPathSelection
                {
                    Name = XPathSelectionName.EditionRuntime,
                    //Url = "http://www.ofdb.de/view.php?page=fassung&fid=258134&vid=386665,",
                    Url = "http://www.ofdb.de/view.php?page=fassung{placeholder},",
                    XPath = "/html//font[text()=\"Laufzeit:\"]/parent::node()/parent::node()//b/text()",
                    Resolver = new OfdbEditionRuntimeResolver()
                });
            #endregion EditionDetails

            return xPathSelections;
        }
    }
}
