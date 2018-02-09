using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;

using ShadowSocks.Model;
using ShadowSocks.Config;
using ShadowSocks.Encryption;
using ShadowSocks.Exceptions;

namespace ShadowSocks.Util
{
    public class Request
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.3319.102 Safari/537.36";
        private static int REQUEST_TIMES = 3;

        private static string[] CONF_URLS = {
            "",
            ""
        };


        private string serverRoot = null;

        private User user = User.instance();

        private static Request _request = null;

        public static Request instance()
        {
            if (_request == null)
            {
                _request = new Request();
            }
            return _request;
        }

        private string ServerRoot
        {
            get
            {
                if (serverRoot == null)
                {
                    for (int i = 0; i < CONF_URLS.Length; i++)
                    {
                        try
                        {
                            string result = _get(CONF_URLS[i]);
                            if (result != null)
                            {
                                serverRoot = DES.DESDeCode(result);
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                    }
                }
                if (serverRoot == null) {
                    serverRoot = Constants.DEFAULT_SEVER_ROOT;
                }
                return serverRoot;
            }
        }

        private string _get(string url)
        {
            String requestUrl = this.prepareGetData(url);

            for (int i = 0; i < REQUEST_TIMES; i++)
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                    request.Method = "GET";
                    request.Timeout = 6000;
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            return null;
        }

        private List<KeyValuePair<string, string>> PreparePostData(List<KeyValuePair<string, string>> data)
        {
            if (data == null)
            {
                data = new List<KeyValuePair<string, string>>();
            }

            data.Add(new KeyValuePair<string, string>("device", "windows"));
            data.Add(new KeyValuePair<string, string>("version", Utils.getCurrentVersion()));
            data.Add(new KeyValuePair<string, string>("token", user.token));
            
            return data;
        }

        private String prepareGetData(string requestUrl) {
            if (requestUrl.Contains("?"))
            {
                requestUrl = requestUrl + "&token=" + user.token;
            }
            else {
                requestUrl = requestUrl + "?token=" + user.token;
            }
            requestUrl = requestUrl + "&device=windows&version=" + Utils.getCurrentVersion();
            return requestUrl;
        }

        public JObject Post(string url, List<KeyValuePair<string, string>> data = null)
        {
            data = PreparePostData(data);
            var postData = new FormUrlEncodedContent(data);
            for (int i = 0; i < REQUEST_TIMES; i++)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = client.PostAsync(ServerRoot + url, postData).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var resultStr = response.Content.ReadAsStringAsync().Result;
                            dynamic result = JsonConvert.DeserializeObject(resultStr);
                            return result;
                        }
                    }
                }
                catch { }
            }
            throw new GreenDotException("http aysnc post with url: " + url + " failed.");
        }

        public string Get(string url)
        {
            return _get(ServerRoot + url);
        }

        public WebClient CreateWebClient()
        {
            WebClient http = new WebClient();
            http.Encoding = Encoding.UTF8;
            http.Headers.Add("User-Agent", UserAgent);
            return http;
        }

        public void GetAsync(string url, Action<object, DownloadStringCompletedEventArgs> done)
        {
            String requestUrl = ServerRoot + url;
            requestUrl = this.prepareGetData(requestUrl);

            WebClient http = CreateWebClient();
            http.DownloadStringAsync(new Uri(requestUrl));
            http.DownloadStringCompleted += (object o, DownloadStringCompletedEventArgs e) => done(o, e);
        }

        public void DownloadAsync(string url, string localFileName, Action<object, System.ComponentModel.AsyncCompletedEventArgs> done)
        {
            WebClient http = CreateWebClient();
            http.DownloadFileAsync(new Uri(url), localFileName);
            http.DownloadFileCompleted += (object o, System.ComponentModel.AsyncCompletedEventArgs e) => done(o, e);
        }
    }
}
