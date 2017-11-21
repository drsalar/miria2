using System.IO;
using System.Net;
using System.Text;

namespace app1
{
    public class Http
    {
        public static string user;
        public static string name;
        public static string pwd;
        public static System.Net.CookieContainer cc;

        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            request.KeepAlive = true;
            if (cc != null)
            {
                request.CookieContainer = cc;
            }

            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return response.StatusCode.ToString();
                }
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码 
                }

                string[] cookies = response.Headers.GetValues("Set-Cookie");
                if (cookies != null && cookies.Length > 0)
                {
                    foreach (string cookie in cookies)
                    {
                        string[] cs = cookie.Split(';');
                        foreach (string ca in cs)
                        {
                            string[] kv = ca.Split('=');
                            if (kv.Length == 2)
                            {
                                Cookie c = new Cookie(kv[0].TrimStart(' '), kv[1], "/", "english.ulearning.cn");
                                if (cc == null)
                                {
                                    cc = new CookieContainer();
                                }
                                cc.Add(c);
                            }
                        }
                    }
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                return retString;
            }
            catch
            {
                return "";
            }
        }

        public static string HttpGet(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.KeepAlive = true;
            if (cc != null)
            {
                request.CookieContainer = cc;
            }
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response.StatusCode.ToString();
            }
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码 
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }

        public static void findname(string req)
        {
            int i = req.IndexOf("同学,");
            string r = req.Substring(0, i);
            i = r.LastIndexOf('>');
            name = r.Substring(i + 1);
        }
    }
}