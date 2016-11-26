using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPathSelector = OfdbParser;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private XPathSelector.XPathRequest xSelector;
        private XPathSelector.XPathAgilityPackSelector hSelector;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lboxResult.Items.Clear();
            try
            {
                if (rBtnPure.Checked) xSelector = new XPathSelector.XPathRequest(tbUrl.Text);
                else if (rBtnHtmAgility.Checked) hSelector = new XPathSelector.XPathAgilityPackSelector(tbUrl.Text);
                else throw new ArgumentException("No radio button activated.");
            }
            catch (Exception ex)
            {
                lboxResult.Items.Add(ex.Message);
            }
            
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            lboxResult.Items.Clear();

            try
            {
                List<string> result;   
                if (rBtnPure.Checked) result = xSelector.GetXPathValues(tbXPath.Text);
                else if (rBtnHtmAgility.Checked) result = hSelector.GetXPathValues(tbXPath.Text);
                else throw new ArgumentException("No radio button activated.");
                
                lboxResult.Items.AddRange(result.ToArray());
            }
            catch (Exception ex)
            { 
                lboxResult.Items.Add(ex.Message);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string s1 = "";
            foreach (object item in lboxResult.Items) s1 += item.ToString() + "\r\n";
            Clipboard.SetText(s1);
        }


    }
}
