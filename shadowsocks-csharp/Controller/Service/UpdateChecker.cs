using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using ShadowSocks.Model;
using ShadowSocks.Util;
using ShadowSocks.Config;
using ShadowSocks.Extensions;

namespace ShadowSocks.Controller
{
    public class UpdateChecker
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.3319.102 Safari/537.36";

        private Configuration config;
        public bool NewVersionFound;
        public string LatestVersionNumber;
        public string LatestVersionSuffix;
        public string LatestVersionName;
        public string LatestVersionURL;
        public string LatestVersionLocalName;
        public event EventHandler CheckUpdateCompleted;

        public static string Version;

        private class CheckUpdateTimer : System.Timers.Timer
        {
            public Configuration config;

            public CheckUpdateTimer(int p) : base(p)
            {
            }
        }

        public void CheckUpdate(Configuration config, int delay)
        {
            CheckUpdateTimer timer = new CheckUpdateTimer(delay);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.config = config;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckUpdateTimer timer = (CheckUpdateTimer)sender;
            Configuration config = timer.config;
            timer.Elapsed -= Timer_Elapsed;
            timer.Enabled = false;
            timer.Dispose();
            CheckUpdate(config);
        }

        public void CheckUpdate(Configuration config)
        {
            this.config = config;
            try
            {
                Version = Util.Utils.getCurrentVersion();
                string checkUri = Constants.DEFAULT_SEVER_ROOT + Constants.UPDATE_CHECK_API + "?device=windows" + "&version=" + Version;

                Logging.Debug("Checking updates...");
                WebClient http = CreateWebClient();
                http.DownloadStringCompleted += http_DownloadStringCompleted;
                http.DownloadStringAsync(new Uri(checkUri));
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string response = e.Result;
                JObject result = JObject.Parse(response);
                if (result.ok() && result.content() != null)
                {
                    var content = result.content();
                    var version = content.version;
                    var downloadLink = content.downloadlink;
                    var name = content.name;
                    if (version != null && downloadLink != null && name != null)
                    {
                        NewVersionFound = true;
                        LatestVersionNumber = (string)version;
                        LatestVersionURL = (string)downloadLink;
                        LatestVersionName = (string)name;
                        startDownload();
                    }
                }
                else
                {
                    Logging.Debug("No update is available");
                    if (CheckUpdateCompleted != null)
                    {
                        CheckUpdateCompleted(this, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void startDownload()
        {
            try
            {
                LatestVersionLocalName = Utils.GetTempPath(LatestVersionName);
                WebClient http = CreateWebClient();
                http.DownloadFileCompleted += Http_DownloadFileCompleted;
                http.DownloadFileAsync(new Uri(LatestVersionURL), LatestVersionLocalName);
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void Http_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    Logging.LogUsefulException(e.Error);
                    return;
                }
                Logging.Debug($"New version {LatestVersionNumber}{LatestVersionSuffix} found: {LatestVersionLocalName}");
                if (CheckUpdateCompleted != null)
                {
                    CheckUpdateCompleted(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private WebClient CreateWebClient()
        {
            WebClient http = new WebClient();
            http.Headers.Add("User-Agent", UserAgent);
            //http.Proxy = new WebProxy(IPAddress.Loopback.ToString(), config.localPort);
            return http;
        }
    }
}
