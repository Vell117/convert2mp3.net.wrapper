using convert2mp3.Etc;
using CsQuery;
using mshtml;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace convert2mp3
{
    public class Converter : IDisposable
    {
        private const string UrlLang = "/en";
        private const string ConvertUrl = "http://convert2mp3.net" + UrlLang + "/index.php?p=convert";
        private string ConversionUrl = null;
        private string ConvertResult = null;
        private string TagResult = null;
        private bool ShowIe = true;
        private string TagUrl = null;
        private IEForm ie = null;
        private bool _final = false;
        public bool Finalized { get { return _final; } }

        private string FinalFormUrl = null;

        public delegate void ConvertedEventMethod(bool ok, string[] artist, string[] name, string album, bool cover, string AudioHTML);
        public event ConvertedEventMethod WhenConverted;
        
        public delegate void ConvertStartEventMethod();
        public event ConvertStartEventMethod ConvertStart;

        public Converter(string URL, string format)
        {
            // create post values
            var values = new NameValueCollection();
            values["url"] = URL;
            values["format"] = format;
            values["9di2n3"] = "38668324";

            // get post result
            ConvertResult = Web.Post(ConvertUrl, values);

            StreamWriter writer = new StreamWriter("result.txt");
            writer.Write(ConvertResult);
            //Environment.Exit(1);

            // get url with tags and conversion
            CQ cq = new CQ(ConvertResult);
            foreach(var obj in cq.Find("iframe"))
            {
                if(obj.GetAttribute("id").Contains("convertFrame"))
                {
                    ConversionUrl = obj.GetAttribute("src");
                    break;
                }
            }
            /* old code
            string[] sp = ConvertResult.Split(new string[] { "<iframe id=\"convertFrame\" src=\"", "\" style=" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in sp)
                if (s.Contains("conversion.php"))
                    ConversionUrl = s;*/

            if (ConversionUrl == null)
                throw new Exception("Something wrong with parsing");

            string key = null, id = null;

            foreach(var split in ConversionUrl.Split('&'))
            {
                if (split.Contains("key="))
                    key = split.Split('=')[1];

                if (split.Contains("id="))
                    id = split.Split('=')[1];
            }

            if(key == null || id == null)
                throw new Exception("Something wrong with parsing");

            TagUrl = $"http://convert2mp3.net/en/index.php?p=tags&id={id}&key={key}";

            ie = new IEForm(this, ShowIe);
            ie.Show();
            ie.Visible = ShowIe;

            ie.ie.Navigating += Ie_Navigating;
            ie.ie.Navigated += Ie_Navigated;
            ie.ie.DocumentCompleted += Ie_DocumentCompleted;
            
            Screen myScreen = Screen.FromControl(ie);
            System.Drawing.Rectangle area = myScreen.WorkingArea;
            
            ie.Left = area.Width;
            ie.Top = area.Top;
        }

        private void Ie_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Ie_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void Ie_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e)
        {
            /*if (e.Url.ToString().ToLower().Contains("ad"))
                e.Cancel = true;*/
            if (e.Url.ToString().Contains("p=tags"))
            {
                try
                {
                    TagUrl = e.Url.ToString();

                    e.Cancel = true;
                    ie.ie.Stop();

                    TagResult = Web.Get(TagUrl.Split('?')[0], TagUrl.Split('?')[1]);

                    List<string> artist = new List<string>(), name = new List<string>();
                    string album = "", playUrl = "";
                    bool cover = false;

                    CQ cq = CQ.Create(TagResult);

                    foreach (IDomObject obj in cq.Find("form"))
                    {
                        if (obj.GetAttribute("action").Contains("index.php?p=complete"))
                        {
                            FinalFormUrl = "http://convert2mp3.net" + UrlLang + "/" + obj.GetAttribute("action");
                            break;
                        }
                    }

                    foreach (IDomObject obj in cq.Find("option"))
                    {
                        if (obj.ParentNode.GetAttribute("id").Contains("inputArtist"))
                        {
                            artist.Add(obj.InnerText);
                        }
                        if (obj.ParentNode.GetAttribute("id").Contains("inputTitle"))
                        {
                            name.Add(obj.InnerText);
                        }
                    }
                    
                    /*
                    foreach (IDomObject obj in cq.Find("select"))
                    {
                        if (obj.GetAttribute("id").Contains("inputArtist"))
                        {
                            artist = obj.FirstChild.InnerText;
                            break;
                        }
                    }

                    foreach (IDomObject obj in cq.Find("select"))
                    {
                        if (obj.GetAttribute("id").Contains("inputTitle"))
                        {
                            name = obj.FirstChild.InnerText;
                            break;
                        }
                    }*/

                    foreach (IDomObject obj in cq.Find("input"))
                    {
                        if (obj.GetAttribute("id").Contains("inputAlbum"))
                        {
                            string value = obj.GetAttribute("value");
                            album = value;
                            break;
                        }
                    }

                    foreach (IDomObject obj in cq.Find("input"))
                    {
                        if (obj.GetAttribute("id").Contains("inputCover"))
                        {
                            string value = obj.GetAttribute("value");
                            if (value == "1")
                                cover = true;

                            break;
                        }
                    }
                    /*
                    foreach (IDomObject obj in cq.Find("script"))
                    {
                        if (obj.InnerText.Contains("audiojs"))
                        {
                            playUrl += obj.ToString();
                            break;
                        }
                    }

                    foreach (IDomObject obj in cq.Find("div"))
                    {
                        if (obj.GetAttribute("class").Contains("audiojs"))
                        {
                            playUrl += obj.ToString();
                            break;
                        }
                    }
                    */
                    playUrl = null;

                    WhenConverted(true, artist.ToArray(), name.ToArray(), album, cover, playUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't convert: " + ex.ToString());
                    WhenConverted(false, null, null, null, false, null);
                }
            }
        }
        

        public void StartConverting()
        {
            if (Finalized)
                throw new Exception("This instance of c2mp3 is finalized. Create another one.");

            if (WhenConverted == null)
                throw new Exception("Please, make an event");

            ConvertStart?.Invoke();

            ie.Navigate(ConversionUrl);
        }

        public ResultFileInfo Finalize(string artist, string name, string album, bool cover)
        {
            var values = new NameValueCollection();
            values["artist"] = artist;
            values["title"] = name;
            values["album"] = album;

            if (cover)
                values["cover"] = "1";
            else 
                values["cover"] = "0";

            string CompletedPage = Web.Post(FinalFormUrl, values);

            _final = true;
            return ParseDownloadUrl(CompletedPage);
        }

        private ResultFileInfo ParseDownloadUrl(string CompletedPage)
        {
            CQ cq = CQ.Create(CompletedPage);
            ResultFileInfo result = new ResultFileInfo();
            //btn btn-success btn-large
            //<a href="http://cdl23.convert2mp3.net/cloud-save.php?id=youtube_Vhh_GeBPOhs&key=RFatvCxf4nRX" data-filename="Steve - Steve.mp3" class="dropbox-saver"></a>
            foreach (IDomObject obj in cq.Find("a"))
            {
                if (obj.GetAttribute("class").Contains("btn btn-success btn-large"))
                {
                    result.Link = obj.GetAttribute("href");
                }
                if (obj.GetAttribute("class").Contains("dropbox-saver"))
                {
                    result.FileName = obj.GetAttribute("data-filename"); 
                }
            }

            return result;
        }

        public ResultFileInfo Finalize()
        {

            string CompletedPage = Web.Get(FinalFormUrl.Split('?')[0], FinalFormUrl.Split('?')[0]);

            _final = true;
            return ParseDownloadUrl(CompletedPage);
        }

        public void Dispose()
        {
            _final = true;

            if (ie != null)
                ie.Dispose();
        }
    }
}
namespace convert2mp3.Etc
{
    public class ResultFileInfo
    {
        public string Link;
        public string FileName = "Default.mp3";
        
    }
}