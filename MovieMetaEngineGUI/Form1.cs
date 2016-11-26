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

        private void btnSearchEAN_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                MovieMetaEngine.IMovieMetaSearch search = new OfdbParser.OfdbMovieMetaSearch();
                foreach (var entry in search.SearchMovieByBarcode(tbSearch.Text))
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
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                MovieMetaEngine.IMovieMetaSearch search = new OfdbParser.OfdbMovieMetaSearch();
                foreach (var entry in search.SearchMovieByTitle(tbSearch.Text))
                {
                    listBox1.Items.Add(entry.Title + " - " + entry.Reference + " - " + entry.Year + " - " + entry.ImgUrl );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                //MovieMetaEngine.IMovieMetaSearch search = new OfdbWebGatewayConnector.OfdbWgMovieMetaSearch();
                MovieMetaEngine.IMovieMetaSearch search = new OfdbParser.OfdbMovieMetaSearch();
                foreach (var entry in search.SearchMovieByEngineId(tbSearch.Text))
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
    }
       
}

