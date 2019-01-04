using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace convert2mp3
{
    public partial class IEForm : Form
    {
        public WebBrowser ie { get { return webBrowser; } }
        public bool AllowExit = false;
        public Converter conv;
        public IEForm(Converter c, bool visible)
        {
            conv = c;
            InitializeComponent();
            Visible = visible;
        }

        private void IEForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AllowExit;
        }

        public void Navigate(string url)
        {
            webBrowser.Navigate(url);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public void EditUrl(string n)
        {
            tbUrl.ReadOnly = false;
            tbUrl.Text = n;
            tbUrl.ReadOnly = true;
        }


        public string GetDocument()
        {
            var document = ie.Document;
            return document.All.ToString();
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            EditUrl(e.Url.ToString());
        }
    }
}
