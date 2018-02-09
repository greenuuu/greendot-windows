using System;
using System.Globalization;
using System.Text.RegularExpressions;

using ShadowSocks.Controller;
using ShadowSocks.Util;
using ShadowSocks.Encryption;
using System.Collections;

namespace ShadowSocks.Model
{
    public class User
    {
        private Properties.Settings settings = Properties.Settings.Default;
        private ShadowSocksController controller = ShadowSocksController.instance();
        
        public String password
        {
            get
            {
                if (!settings.password.IsNullOrEmpty())
                {
                    return DES.DESDeCode(settings.password);
                }
                return "";
            }
            set
            {
                if (!value.IsNullOrEmpty())
                {
                    settings.password = DES.DESEnCode(value);
                    settings.Save();
                }
            }
        }
        
        public String token
        {
            get
            {
                return settings.token;
            }
            set
            {
                settings.token = value;
                settings.Save();
            }
        }

        public String avatar {
            get
            {
                return settings.avatar;
            }
            set
            {
                settings.avatar = value;
                settings.Save();
            }
        }

        public String phone
        {
            get
            {
                return settings.phone;
            }
            set
            {
                settings.phone = value;
                settings.Save();
            }
        }

        public String phoneMask
        {
            get {
                if (!settings.phone.IsNullOrEmpty())
                {
                    String phoneNum = settings.phone;
                    phoneNum = Regex.Replace(phoneNum, "(\\d{3})\\d{4}(\\d{4})", "$1****$2");
                    return phoneNum;
                }
                return "";
            }
        }

        public String expiredate
        {
            get
            {
                DateTime dt = Convert.ToDateTime(settings.expiretime);
                return dt.ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);
            }
        }

        public String expiretime {
            get
            {
                return settings.expiretime;
            }
            set
            {
                settings.expiretime = value;
                settings.Save();
            }
        }

        public int expiredday {
            get
            {
                TimeSpan span = DateHelper.subtractCurrentDate(this.expiretime);
                if (span.Days > 0)
                {
                    return span.Days;
                }
                if (span.Hours > 0)
                {
                    return 1;
                }
                return span.Days;
            }
        }

        //todo:服务器端返回了expired

        public int type
        {
            get
            {
                return settings.type;
            }
            set
            {
                settings.type = value;
                settings.Save();
            }
        }

        public bool expired
        {
            get
            {
                return this.expiredday <= 0;
            }
        }

        public bool loggedIn
        {
            get
            {
                return !string.IsNullOrEmpty(token);
            }
        }

        private string _messageContent;

        public string messageContent
        {
            get
            {
                if (this.isMessageEnabled(this.messageId))
                {
                    this.setMessageDisabled(this.messageId);
                    return this._messageContent;
                }
                else {
                    return "";
                }
            }
            set
            {
                _messageContent = value;
            }
        }

        private string _messageId;

        public string messageId
        {
            get
            {
                return this._messageId;
            }
            set
            {
                _messageId = value;
            }
        }

        public String messages
        {
            get
            {
                return settings.messages;
            }
            set
            {
                settings.messages = value;
                settings.Save();
            }
        }

        public bool isMessageEnabled(string messageId) {
            string messages = this.messages;
            if (messages.IsNullOrEmpty()) {
                return true;
            }

            string[] messageDatas = messages.Split(',');
            bool exist = ((IList)messageDatas).Contains(messageId);
            return !exist;
        }
        
        public void setMessageDisabled(string messageId) {
            string messages = this.messages;
            if (messages.IsNullOrEmpty()) {
                messages = messageId;
            }
            else {
                messages = messages + "," + messageId;
            }
            this.messages = messages;
        }

        public void setUser(dynamic userInfo) {
            this.avatar = (string)userInfo["avatar"];
            this.expiretime = (string)userInfo["serviceexpiredate"];
            this.phone = (string)userInfo["phone"];
            this.token = (string)userInfo["token"];
            this.type = Convert.ToInt32(userInfo["type"]);
            if (userInfo["password"] != null)
            {
                this.password = (string)userInfo["password"];
            }

            if (userInfo["message_id"]!=null) {
                this.messageId = (string)userInfo["message_id"];
            }

            if (userInfo["message_content"] != null)
            {
                this.messageContent = (string)userInfo["message_content"];
            }
        }

        private static User _user = null;

        public static User instance()
        {
            if (_user == null)
            {
                _user = new User();
            }
            return _user;
        }
        
    }
}
