using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowSocks.Model
{
    public class SiteConfig
    {
        private Properties.Settings settings = Properties.Settings.Default;

        public int usergiftday
        {
            get
            {
                return settings.usergiftday;
            }
            set
            {
                settings.usergiftday = value;
                settings.Save();
            }
        }

        public string sitename
        {
            get
            {
                return settings.sitename;
            }
            set
            {
                settings.sitename = value;
                settings.Save();
            }
        }

        public string siteword
        {
            get
            {
                return settings.siteword;
            }
            set
            {
                settings.siteword = value;
                settings.Save();
            }
        }

        public string company
        {
            get
            {
                return settings.company;
            }
            set
            {
                settings.company = value;
                settings.Save();
            }
        }

        public string version
        {
            get
            {
                return settings.version;
            }
            set
            {
                settings.version = value;
                settings.Save();
            }
        }

        public void setConfig(dynamic configInfo)
        {
            if (configInfo["usergiftday"]!=null)
            {
                this.usergiftday = Convert.ToInt32(configInfo["usergiftday"]);
            }
            
            this.sitename = (string)configInfo["sitename"];
            this.siteword = (string)configInfo["siteword"];
            this.company = (string)configInfo["company"];
        }

        private static SiteConfig _config = null;

        public static SiteConfig instance()
        {
            if (_config == null)
            {
                _config = new SiteConfig();
            }
            return _config;
        }

    }
}
