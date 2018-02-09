using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShadowSocks.Controller;
using ShadowSocks.Extensions;
using ShadowSocks.Config;
using ShadowSocks.Properties;
using ShadowSocks.Model;
using ShadowSocks.Util;
using ShadowSocks.Encryption;

namespace ShadowSocks.View
{
    public partial class Main : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        private readonly ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));

        private List<ServerNode> servers = null;

        private ShadowSocksController mainController;

        private MenuViewController menuController;

        private Configuration configuration;

        private User user;

        private SiteConfig siteConfig;

        private System.Timers.Timer userCheckTimer;

        private int userCheckDuration = 1000 * 15;

        //当前选择的服务器索引
        private int currentServerId = -1;

        //当前运行状态
        private bool currentServerStatus = false;

        //当前运行类型
        private int currentServerType = 1;

        //服务节点数量
        private int serverCount = 0;

        public Main()
        {
            InitializeComponent();
            
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Amber900, Accent.Amber700, TextShade.WHITE);

            this.user = User.instance();
            this.mainController = ViewManager.instance.MainController;
            this.mainController.ConfigChanged += controller_ConfigChanged;

            this.initLocation();
            this.loadConfiguration();
            this.loadServers();
            this.setUserChecker();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.menuController = ViewManager.instance.MenuController;
            ViewManager.instance.controlNotifyTray(true);

            panServers.HorizontalScroll.Enabled = false;

            this.siteConfig = SiteConfig.instance();
            if (!this.siteConfig.sitename.IsNullOrEmpty() && this.siteConfig.sitename != lblWindowTitle.Text)
            {
                this.lblWindowTitle.Text = this.siteConfig.sitename;
            }
            this.renderUserInfo(User.instance());
        }

        private void loadConfiguration() {
            configuration = this.mainController.GetConfigurationCopy();
            currentServerId = configuration.GetCurrentServer().id;
            currentServerType = configuration.global ? 1 : 2;
        }

        private void loadServers()
        {
            try
            {
                Request.instance().GetAsync(Constants.SERVER_LIST_API, serverRequestCompleted);
            }
            catch (Exception exp)
            {
                Logging.LogUsefulException(exp.GetBaseException());
            }
        }

        private void renderServers(List<ServerNode> servers) {
            panServers.Controls.Clear();

            Configuration config = this.mainController.GetConfigurationCopy();

            int selectServerIndex = config.index;
            int selectServerId = this.getLocalServerIdFromIndex(selectServerIndex);

            List<Server> configServers = new List<Server>();

            this.serverCount = servers.Count;

            for (int i = 0; i < servers.Count; i++)
            {
                ServerNode serverNode = servers[i];
                Server server = new Server();
                if (Uri.CheckHostName(serverNode.Host) == UriHostNameType.Unknown)
                {
                    return;
                }

                string serverHost = serverNode.Host;
                serverHost = DES.DESDeCode(serverHost);
                string serverPassword = serverNode.Password;
                serverPassword = DES.DESDeCode(serverPassword);
                string serverMethod = serverNode.Method;
                serverMethod = DES.DESDeCode(serverMethod);
                string serverPort = serverNode.Port;
                serverPort = DES.DESDeCode(serverPort);
                int serverPortVal = Convert.ToInt32(serverPort);

                server.id = serverNode.Id;
                server.server = serverHost;
                server.server_port = serverPortVal;
                server.password = serverPassword;
                server.method = serverMethod;
                server.name = serverNode.Name;
                server.remarks = serverNode.Remark;
                server.icon = serverNode.Icon;

                if (selectServerId == 0 && i == 0)
                {
                    server.selected = true;
                }

                if (serverNode.Id == selectServerId)
                {
                    server.selected = true;
                }

                this.drawServerNode(server, i);

                Configuration.CheckServer(server);
                configServers.Add(server);
            }

            this.mainController.SaveServers(configServers, config.localPort);

            btnGlobalStart.Enabled = true;
            btnPacStart.Enabled = true;
        }

        private void renderUserInfo(User user) {
            lblUserName.Text = user.phoneMask;
            if (user.type == 1)
            {
                picUserStatus.Visible = true;
                picUserStatus.Location = new Point(picUserAvatar.Width + lblUserName.Width + 30, 26);
            }
            else {
                picUserStatus.Visible = false;
            }

            if (user.expired)
            {
                lblExpiredDate.Text = user.expiredate.ToString();
                btnRecharge.Width = 190;
                btnRecharge.Location = new Point(this.Width - 190 - 19, 16);
                btnRecharge.Text = "套餐已过期，请续费";
            }
            else
            {
                lblExpiredDate.Text = user.expiredate.ToString();
                btnRecharge.Text = "续费";
                btnRecharge.Location = new System.Drawing.Point(317, 16);
                btnRecharge.Size = new System.Drawing.Size(64, 40);
            }

            if (!user.avatar.IsNullOrWhiteSpace())
            {
                try
                {
                    Image avatarImage = Image.FromStream(WebRequest.Create(user.avatar).GetResponse().GetResponseStream());
                    picUserAvatar.Image = avatarImage;
                }
                catch (Exception)
                {
                    picUserAvatar.Image = Resources.logo;
                }
            }
            else {
                picUserAvatar.Image = Resources.logo_white;
            }
        }

        private void setUserChecker()
        {
            this.userCheckTimer = new System.Timers.Timer(userCheckDuration);
            this.userCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(userCheck_Tick);
            this.userCheckTimer.Enabled = true;
            this.userCheckTimer.Start();
        }

        private delegate void EventHandle(object sender, EventArgs e);
        public void userCheck_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            this.BeginInvoke(new EventHandle(userCheckAction), source, e);
        }

        public void userCheckAction(Object source, EventArgs e)
        {
            //定时器处理函数
            try
            {
                JObject res = Request.instance().Post(Constants.USER_INFO_API);
                if (res.ok())
                {
                    User user = User.instance();
                    user.setUser(res.content());

                    this.renderUserInfo(user);

                    if (user.expired == true)
                    {
                        this.mainController.ToggleEnable(false);
                    }
                }
                else if (res.expired())
                {

                    this.userCheckTimer.Stop();
                    this.userCheckTimer.Enabled = false;
                    this.userCheckTimer = null;

                    MessageBox.Show(
                        "账号已在其它设备登录",
                        "系统提示",
                        MessageBoxButtons.OK
                    );

                    this.logoutHandle();
                }
            }
            catch { }
        }

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            if ( this.Disposing || this.IsDisposed)
            {
                return;
            }

            if (this.mainController.changeType == "lan")
            {
                return;
            }

            Configuration config = this.mainController.GetConfigurationCopy();
            bool enabled = config.enabled;
            bool global = config.global;
            if (enabled)
            {
                if (global)
                {
                    btnGlobalStart.Text = "全局加速中...";
                    btnPacStart.Text = "智能加速";
                }
                else {
                    btnGlobalStart.Text = "全局加速";
                    btnPacStart.Text = "智能加速中...";
                }
                picStatusStop.Visible = false;
                picStatus.Visible = true;
            }
            else {
                btnGlobalStart.Text = "全局加速";
                btnPacStart.Text = "智能加速";
                picStatusStop.Visible = true;
                picStatus.Visible = false;
            }

            List<Server> configServers = config.configs;

            if (configServers != null && configServers.Count > 0)
            {
                this.currentServerId = config.GetCurrentServer().id;

                for (int i = 0; i < configServers.Count; i++)
                {
                    Server server = configServers[i];
                    Panel serverPanel = (Panel)panServers.Controls.Find("serverPanel_" + server.id, true)[0];
                    PictureBox serverStatus = (PictureBox)serverPanel.Controls.Find("serverStatus_" + server.id, true)[0];
                    if (server.id == currentServerId)
                    {
                        serverPanel.BackColor = Color.FromArgb(240, 250, 250); ;
                        serverStatus.Visible = true;
                    }
                    else
                    {
                        serverPanel.BackColor = Color.White;
                        serverStatus.Visible = false;
                    }
                }
            }
        }

        private void serverRequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string response = e.Result;
                JObject result = JObject.Parse(response);
                if (result.ok())
                {
                    var contentData = result.content();
                    var serverData = contentData.ToString();
                    servers = JsonConvert.DeserializeObject<List<ServerNode>>(serverData);

                    if (servers != null && servers.Count > 0)
                    {
                        System.Timers.Timer timer = new System.Timers.Timer();
                        timer.Interval = 500;
                        timer.Elapsed += delegate
                        {
                            this.renderServers(servers);
                            timer.Stop();
                        };
                        timer.Start();
                    }
                }
            }
            catch (Exception exp)
            {
                Logging.LogUsefulException(exp.GetBaseException());
            }
        }
        
        private void drawServerNode(Server server, int index)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { drawServerNode(server, index); }));
                return;
            }

            int serverWidth = 400;
            if (this.serverCount > 4)
            {
                serverWidth = serverWidth - 26;
            }

            Panel serverPanel = new Panel();
            serverPanel.Name = "serverPanel_" + server.id;
            serverPanel.Location = new System.Drawing.Point(0, (index) * 86);
            serverPanel.Width = serverWidth;
            serverPanel.Height = 86;
            serverPanel.Tag = server.id;

            Label serverName = new Label();
            serverName.AutoSize = true;
            serverName.Font = new Font("微软雅黑", 9F);
            serverName.ForeColor = Color.FromArgb(60, 60, 60);
            serverName.Location = new System.Drawing.Point(90, 20);
            serverName.Text = server.name;
            serverPanel.Controls.Add(serverName);

            Label serverRemark = new Label();
            serverRemark.AutoSize = true;
            serverRemark.Font = new Font("微软雅黑", 8F);
            serverRemark.ForeColor = Color.FromArgb(130, 130, 130);
            serverRemark.Location = new System.Drawing.Point(90, 48);
            serverRemark.Text = Util.Utils.formatIPAddress(server.server);
            serverPanel.Controls.Add(serverRemark);

            PictureBox serverIcon = new PictureBox();
            serverIcon.Image = (Image)ShadowSocks.Properties.Resources.ResourceManager.GetObject(server.icon);
            serverIcon.Location = new System.Drawing.Point(18, 12);
            serverIcon.MaximumSize = new System.Drawing.Size(64, 64);
            serverIcon.MinimumSize = new System.Drawing.Size(64, 64);
            serverIcon.Size = new System.Drawing.Size(64, 64);
            serverIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            serverPanel.Controls.Add(serverIcon);

            PictureBox serverStatus = new PictureBox();
            serverStatus.Image = ShadowSocks.Properties.Resources.ico_check;
            serverStatus.Location = new System.Drawing.Point(320, 20);
            serverStatus.BackColor = Color.Transparent;
            serverStatus.MaximumSize = new System.Drawing.Size(44, 44);
            serverStatus.MinimumSize = new System.Drawing.Size(44, 44);
            serverStatus.Size = new System.Drawing.Size(44, 44);
            serverStatus.Visible = false;
            serverStatus.Name = "serverStatus_" + server.id;
            serverStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            
            if (server.selected == true)
            {
                serverStatus.Visible = true;
                serverPanel.BackColor = Color.FromArgb(240,250,250);
            }
            serverPanel.Controls.Add(serverStatus);

            serverPanel.MouseClick += ServerNodeClick;
            serverName.MouseClick += ServerNodeClick;
            serverIcon.MouseClick += ServerNodeClick;
            serverRemark.MouseClick += ServerNodeClick;

            panServers.Controls.Add(serverPanel);

        }

        private void ServerNodeClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < servers.Count; i++)
                {
                    ServerNode server = servers[i];
                    Panel serverPanel = (Panel)panServers.Controls.Find("serverPanel_" + server.Id, true)[0];
                    PictureBox serverStatus = (PictureBox)serverPanel.Controls.Find("serverStatus_" + server.Id, true)[0];
                    serverPanel.BackColor = Color.White;
                    serverStatus.Visible = false;
                }

                Control serverNode = (Control)sender;

                var serverNodeTag = serverNode.Tag;
                if (serverNodeTag == null)
                {
                    serverNode = serverNode.Parent;
                    serverNodeTag = serverNode.Tag;
                }

                this.currentServerId = (int)serverNodeTag;
                PictureBox serverStatus1 = (PictureBox)serverNode.Controls.Find("serverStatus_" + this.currentServerId, true)[0];
                serverNode.BackColor = Color.FromArgb(240, 250, 250);
                serverStatus1.Visible = true;
            }
        }
        
        private void initLocation() {
            Rectangle rect = Screen.GetWorkingArea(this);
            int locationX = rect.Width - this.Width - 100;
            int locationY = 100;
            this.Location = new Point(locationX, locationY);
        }

        private void btnGlobalStart_Click(object sender, EventArgs e)
        {
            if (user.expired)
            {
                return;
            }

            if (this.currentServerId == -1)
            {
                lblHint.Visible = true;
                lblHint.Text = "请选择加速节点";
                return;
            }

            int serverIndex = 0;
            
            //如果正在加速
            if (this.currentServerStatus == true) {
                //如果是pac模式，则直接切换为全局模式
                if (this.currentServerType == 2)
                {
                    this.currentServerType = 1;
                    this.mainController.ToggleGlobal(true);
                }
                else {
                    Configuration config = this.mainController.GetConfigurationCopy();
                    int preServerId = config.GetCurrentServer().id;
                    if (currentServerId != preServerId)
                    {
                        serverIndex = this.getServerIndexFromList(currentServerId);
                        this.subServerConnectCount(preServerId);
                        this.mainController.SelectServerIndex(serverIndex);
                        this.addServerConnectCount(currentServerId);
                    }
                    else {
                        this.currentServerStatus = false;
                        this.subServerConnectCount(this.currentServerId);
                        this.mainController.ToggleEnable(false);
                    }
                }
                return;
            }
            
            lblHint.Visible = false;

            this.currentServerType = 1;
            this.currentServerStatus = true;

            serverIndex = this.getServerIndexFromList(currentServerId);
            this.mainController.ToggleType(serverIndex, true);
            this.addServerConnectCount(currentServerId);
        }

        private void btnPacStart_Click(object sender, EventArgs e)
        {
            if (user.expired)
            {
                return;
            }

            if (this.currentServerId == -1)
            {
                lblHint.Visible = true;
                lblHint.Text = "请选择加速节点";
                return;
            }

            int serverIndex = 0;

            //如果正在加速
            if (this.currentServerStatus == true)
            {
                //如果是全局模式，则直接切换为智能模式
                if (this.currentServerType == 1)
                {
                    this.currentServerType = 2;
                    this.mainController.ToggleGlobal(false);
                }
                else {
                    Configuration config = this.mainController.GetConfigurationCopy();
                    int preServerId = config.GetCurrentServer().id;
                    if (currentServerId != preServerId)
                    {
                        serverIndex = this.getServerIndexFromList(currentServerId);
                        this.subServerConnectCount(preServerId);
                        this.mainController.SelectServerIndex(serverIndex);
                        this.addServerConnectCount(currentServerId);
                    }
                    else {
                        this.currentServerStatus = false;
                        this.subServerConnectCount(this.currentServerId);
                        this.mainController.ToggleEnable(false);
                    }
                }
                return;
            }

            lblHint.Visible = false;
            this.currentServerType = 2;
            this.currentServerStatus = true;
            serverIndex = this.getServerIndexFromList(currentServerId);
            this.mainController.ToggleType(serverIndex, false);
            this.addServerConnectCount(currentServerId);
        }

        private int getServerIndexFromList(int serverId) {
            int serverIndex = 0;
            for (int i = 0; i < servers.Count; i++) {
                ServerNode server = servers[i];
                if (server.Id == serverId)
                {
                    serverIndex = i;
                    break;
                }
            }
            return serverIndex;
        }

        private int getLocalServerIdFromIndex(int serverIndex) {
            List<Server> servers = configuration.configs;
            int serverId = 0;
            if (servers !=null && servers.Count > serverIndex)
            {
                serverId = servers[serverIndex].id;
            }
            return serverId;
        }

        private void showNoticeForm() {
            Notice noticeForm = ViewManager.instance.NoticeForm;

            Rectangle rect = Screen.GetWorkingArea(this);
            int formSpacer = 5;
            int locationX = this.Location.X - noticeForm.Width - formSpacer;
            if (locationX < noticeForm.Width)
            {
                locationX = this.Location.X + noticeForm.Width + formSpacer;
            }

            int locationY = this.Location.Y;

            noticeForm.Show();
            noticeForm.WindowState = FormWindowState.Normal;
            noticeForm.Activate();

            noticeForm.Location = new Point(locationX, locationY);
            noticeForm.FormClosed += noticeForm_FormClosed;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Setting settingForm = ViewManager.instance.SettingForm;

            Rectangle rect = Screen.GetWorkingArea(this);
            int formSpacer = 5;
            int locationX = this.Location.X - settingForm.Width - formSpacer;
            if (locationX < settingForm.Width)
            {
                locationX = this.Location.X + settingForm.Width + formSpacer;
            }

            int locationY = this.Location.Y;

            settingForm.Show();
            settingForm.WindowState = FormWindowState.Normal;
            settingForm.Activate();

            settingForm.Location = new Point(locationX, locationY);
            settingForm.FormClosed += settingForm_FormClosed;
            
        }

        private void noticeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewManager.instance.closeNoticeForm();
            Utils.ReleaseMemory(true);
        }

        private void settingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewManager.instance.closeSettingForm();
            Utils.ReleaseMemory(true);
        }

        private void redirectUserCenter() {
            string userCenterUri = Constants.DEFAULT_SEVER_ROOT + Constants.USER_CENTER_URI;
            Util.Utils.redirectToWebUrl(userCenterUri);
        }

        private void subServerConnectCount(int serverId)
        {
            var postData = new List<KeyValuePair<string, string>>();
            var postServerId = DES.DESEnCode(serverId.ToString());
            postData.Add(new KeyValuePair<string, string>("sid", postServerId));
            try
            {
                Request.instance().Post(Constants.SERVER_DISCONNECT_API, postData);
            }
            catch { }
        }

        private void addServerConnectCount(int serverId)
        {
            var postData = new List<KeyValuePair<string, string>>();
            var postServerId = DES.DESEnCode(serverId.ToString());
            postData.Add(new KeyValuePair<string, string>("sid", postServerId));
            try
            {
                Request.instance().Post(Constants.SERVER_CONNECT_API, postData);
            }
            catch(Exception ex){
                Console.Write(ex.GetBaseException());
            }
        }

        private void btnRecharge_Click(object sender, EventArgs e)
        {
            string userRechargeUri = Constants.DEFAULT_SEVER_ROOT + Constants.RECHARGE_URI;
            Util.Utils.redirectToWebUrl(userRechargeUri);
        }

        private void picUserAvatar_Click(object sender, EventArgs e)
        {
            this.redirectUserCenter();
        }

        public void logoutHandle() {
            Configuration config = this.mainController.GetConfigurationCopy();
            if (config.enabled)
            {
                this.subServerConnectCount(this.currentServerId);
            }

            if (config.configs !=null && config.configs.Count > 0) {
                this.mainController.ToggleEnable(false);
                this.mainController.Stop();
            }

            
            if (this.userCheckTimer != null)
            {
                this.userCheckTimer.Stop();
                this.userCheckTimer.Enabled = false;
                this.userCheckTimer = null;
            }

            user.token = null;

            ViewManager viewManager = ViewManager.instance;

            viewManager.closeSettingForm();
            viewManager.closeLogForm();
            viewManager.controlNotifyTray(false);

            this.Dispose();

            viewManager.showLoginForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var logoutData = new List<KeyValuePair<string, string>>();
            logoutData.Add(new KeyValuePair<string, string>("token", user.token));
            Request.instance().Post(Constants.USER_LOGOUT_API, logoutData);

            this.logoutHandle();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {
            this.redirectUserCenter();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出加速服务吗？", " 系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.ExitApplicationHandle();
            }
            else {
                e.Cancel = true;
            }
        }

        private void ExitApplicationHandle() {

            Configuration config = this.mainController.GetConfigurationCopy();

            if (config.enabled)
            {
                this.subServerConnectCount(this.currentServerId);
            }

            if (config.configs !=null && config.configs.Count > 0) {
                this.mainController.ToggleEnable(false);
                this.mainController.Stop();
            }

            if (this.userCheckTimer!=null)
            {
                this.userCheckTimer.Stop();
                this.userCheckTimer.Enabled = false;
                this.userCheckTimer = null;
            }
            ViewManager.instance.controlNotifyTray(false);
            Environment.Exit(0);
        }

        public void ExitApplication()
        {
            if (MessageBox.Show("确定要退出加速服务吗？", " 系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.ExitApplicationHandle();
            }
        }
    }
}
