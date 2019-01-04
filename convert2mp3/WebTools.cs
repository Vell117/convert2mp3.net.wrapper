using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace convert2mp3
{
    public static class Web
    {
        public static string Get(object Url, object Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        public static string Post(string Url, NameValueCollection collection)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues(Url, "POST", collection);

                return Encoding.Default.GetString(response);
            }
        }

        public static string Post(string Url, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}
