using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMetaEngineGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MovieMetaEngine.IMovieMetaSearch _search;
        private void SetEngine()
        {
            switch (cBEngine.Text)
            {
                default:
                case "Ofdb":
                    _search = new OfdbParser.OfdbMovieMetaSearch();
                    break;
                case "TheMovieDb":
                    var opts = new TheMovieDbApi.TheMovieDbApiOptions
                    {
                        ApiImageBaseUrl = "https://image.tmdb.org/t/p/original",
                        ApiKey = tbApiKey.Text,
                        ApiUrl = "https://api.themoviedb.org",
                        UseApi = true,
                        ApiReferenceKey = "TheMovieDb"
                    };

                    _search = new TheMovieDbApi.TheMovieDbApiHttpClient(opts, new LoggerFactory().CreateLogger< TheMovieDbApi.TheMovieDbApiHttpClient>());
                   break; 
            }
        }
        private void btnSearchEAN_Click(object sender, EventArgs e)
        {
            SetEngine();
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                foreach (var entry in _search.SearchMovieByBarcode(tbSearch.Text))
                {
                    listBox1.Items.Add(entry.Title + " - " + entry.Reference);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearchTitle_Click(object sender, EventArgs e)
        {
            SetEngine();
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                foreach (var entry in _search.SearchMovieByTitle(tbSearch.Text))
                {
                    listBox1.Items.Add(entry.Title + " - " + entry.Reference + " - " + entry.Year + " - " + entry.ImgUrl + " -" + entry.BackgroundImgUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            SetEngine();
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                foreach (var entry in _search.SearchMovieByEngineId(tbSearch.Text))
                {
                    listBox1.Items.Add(NormalizeString(entry.Title));
                    listBox1.Items.Add(NormalizeString(entry.Year));
                    //listBox1.Items.Add(entry.SubTitle);
                    listBox1.Items.Add(NormalizeString(entry.Reference));
                    //listBox1.Items.Add(entry.OriginalTitle);
                    listBox1.Items.Add(NormalizeString(entry.MetaEngine));
                    listBox1.Items.Add(NormalizeString(entry.ImgUrl));
                    if (entry.Actors != null)
                    {
                        foreach (var a in entry.Actors)
                        {
                            listBox1.Items.Add(NormalizeString(a.ActorName));
                            listBox1.Items.Add(NormalizeString(a.MetaEngine));
                            listBox1.Items.Add(NormalizeString(a.Reference));
                        }
                    }

                    if (entry.Editions != null)
                    {
                        foreach (var edition in entry.Editions)
                        {
                            listBox1.Items.Add("Edition: " + NormalizeString(edition.Country) + " / "
                                + NormalizeString(edition.Reference) + " / " + NormalizeString(edition.Name));
                        }
                    }
                    listBox1.Items.Add(NormalizeString(entry.ProductionCountry));
                    listBox1.Items.Add(NormalizeString(entry.Plot));
                    listBox1.Items.Add(NormalizeString(entry.Rating));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }


        }

        private string NormalizeString(string entry)
        {
            return String.IsNullOrEmpty(entry) ? "n.v" : entry;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = ((ListBox)sender).SelectedItem.ToString();
            Clipboard.SetText(text);
        }
    }
       
}

