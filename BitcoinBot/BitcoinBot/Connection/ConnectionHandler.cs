using System.IO;
using System.Net;

namespace BitcoinBot.Connection
{
    static class ConnectionHandler
    {
        static string Url { get; set; }
        static WebRequest webRequestUrl { get; set; }
        static WebProxy webProxy { get; set; }
        static string StringJson { get; set; }
        static Stream ObjStream { get; set; }
        static StreamReader ObjReader { get; set; }

        static bool TryConnection(string url)
        {
            webRequestUrl = WebRequest.Create(url);
            webRequestUrl.Proxy = webProxy;

            return webRequestUrl != null;
        }

        public static string GetJsonFromUrl(string url)
        {
            StringJson = null;

            if (TryConnection(url))
            {
                ObjStream = webRequestUrl.GetResponse().GetResponseStream();
                ObjReader = new StreamReader(ObjStream);

                var line = "";

                while (line != null)
                {
                    line = ObjReader.ReadLine();

                    if (line != null)
                        StringJson += line;
                }
                return StringJson;
            }
            return "Failed";
        }
    }
}
