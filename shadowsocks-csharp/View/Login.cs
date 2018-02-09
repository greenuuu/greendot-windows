using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

using Newtonsoft.Json.Linq;
using MaterialSkin;
using MaterialSkin.Controls;

using ShadowSocks.Util;
using ShadowSocks.Model;
using ShadowSocks.Config;
using ShadowSocks.Extensions;
using ShadowSocks.Controller;
using System.Net;
using ShadowSocks.Encryption;

namespace ShadowSocks.View
{
    public partial class Login : MaterialForm
    {
        private bool loginEnabled = true;

        private readonly MaterialSkinManager materialSkinManager;

        public Login()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Amber900, Accent.Amber700, TextShade.BLACK);
            
            this.loadAppConfig();
        }

        public void loginButtonControl(bool enabled, string text)
        {
            if (!text.IsNullOrEmpty()) {
                btnLogin.Text = text;
            }
            loginEnabled = enabled;
        }

        private void loginMessageControl(String message) {
            if (!message.IsNullOrEmpty())
            {
                lblMessage.Visible = true;
                lblMessage.Text = message;
            }
            else {
                lblMessage.Visible = false;
                lblMessage.Text = "";
            }
        }

        private void LoginHandle() {
            if (!loginEnabled)
            {
                return;
            }

            loginMessageControl("");

            var phone = txtPhone.Text;
            var password = txtPassword.Text;

            if (phone.IsNullOrWhiteSpace())
            {
                loginMessageControl("请输入手机号码");
                return;
            }

            if (!ValidateHelper.PhoneValidator(phone))
            {
                loginMessageControl("手机号码格式不正确");
                return;
            }

            if (password.IsNullOrWhiteSpace()) {
                loginMessageControl("请输入登录密码");
                return;
            }

            if (!ValidateHelper.PasswordValidator(password))
            {
                loginMessageControl("密码格式不正确");
                return;
            }

            loginButtonControl(false, "登录中...");

            var loginData = new List<KeyValuePair<string, string>>();
            string encryptPhone = DES.DESEnCode(phone);
            string encryptPassword = DES.DESEnCode(password);

            loginData.Add(new KeyValuePair<string, string>("phone", encryptPhone));
            loginData.Add(new KeyValuePair<string, string>("password", encryptPassword));
            
            try
            {
                JObject res = Request.instance().Post(Constants.USER_LOGIN_API, loginData);

                if (res.ok())
                {
                    this.setLocalUserInfo(res.content());

                    this.Hide();
                    
                    ViewManager.instance.showMainForm();
                }
                else
                {
                    loginMessageControl((string)res.content());
                }
            }
            catch (Exception e)
            {
                loginMessageControl("服务器又被墙了，请稍候登录");
            }
            finally
            {
                loginButtonControl(true, "登录");
            }
        }

        private void setLocalUserInfo(dynamic userInfo) {
            userInfo["password"] = txtPassword.Text;
            User user = User.instance();
            user.setUser(userInfo);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.LoginHandle();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            var user = User.instance();
            if (!string.IsNullOrEmpty(user.phone))
            {
                txtPhone.Text = user.phone;
            }

            if (!string.IsNullOrEmpty(user.password))
            {
                txtPassword.Text = user.password;
            }

            txtPhone.Focus();
        }

        private void loadAppConfig()
        {
            try
            {
                Request.instance().GetAsync(Constants.APP_CONFIG_API, configRequestCompleted);
            }
            catch (Exception exp)
            {
                Logging.LogUsefulException(exp.GetBaseException());
            }
        }

        private void configRequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string response = e.Result;
                JObject result = JObject.Parse(response);
                if (result.ok())
                {
                    var content = result.content();

                    SiteConfig config = SiteConfig.instance();
                    config.setConfig(content);

                    if (config.usergiftday > 0)
                    {
                        lblRegisterHint.Text = "注册即送" + config.usergiftday + "天免费试用";
                        lblRegisterHint.Visible = true;
                    }
                    if (!config.sitename.IsNullOrEmpty() && config.sitename != lblHeaderName.Text)
                    {
                        lblHeaderName.Text = config.sitename;
                        lblHeaderName.Location = new System.Drawing.Point(this.Width / 2 - lblHeaderName.Width / 2, 113);
                    }
                    if (!config.siteword.IsNullOrEmpty() && config.siteword != lblHeaderHint.Text)
                    {
                        lblHeaderHint.Text = config.siteword;
                        lblHeaderHint.Location = new System.Drawing.Point(this.Width / 2 - lblHeaderHint.Width / 2, 156);
                    }
                }
            }
            catch (Exception exp)
            {
                Logging.LogUsefulException(exp.GetBaseException());
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.LoginHandle();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.LoginHandle();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Util.Utils.ReleaseMemory(true);
            Environment.Exit(0);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string registerLink = Constants.DEFAULT_SEVER_ROOT + Constants.USER_REGISTER_URI;
            Util.Utils.redirectToWebUrl(registerLink, false);
        }

        private void btnFindPwd_Click(object sender, EventArgs e)
        {
            string findPwdLink = Constants.DEFAULT_SEVER_ROOT + Constants.USER_FINDPWD_URI;
            Util.Utils.redirectToWebUrl(findPwdLink, false);
        }
    }
}
