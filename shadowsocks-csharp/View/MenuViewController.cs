using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

using ShadowSocks.Controller;
using ShadowSocks.Model;
using ShadowSocks.Properties;
using ShadowSocks.Util;
using ShadowSocks.Config;
using ShadowSocks.Encryption;

namespace ShadowSocks.View
{
    public class MenuViewController
    {
        private NotifyIcon notifyIcon;
        private Bitmap icon_baseBitmap;
        private Icon icon_base, icon_in, icon_out, icon_both, targetIcon;
        private ContextMenu contextMenu;
        
        private MenuItem enableItem;
        private MenuItem modeItem;
        private MenuItem ServersItem;
        private MenuItem globalModeItem;
        private MenuItem PACModeItem;
        
        private Main mainForm;

        private User user;

        private SiteConfig siteConfig;

        private ShadowSocksController mainController;

        private UpdateChecker updateChecker;

        public MenuViewController()
        {
            this.mainController = ViewManager.instance.MainController;
            this.mainForm = ViewManager.instance.MainForm;
            this.user = User.instance();
            this.siteConfig = SiteConfig.instance();

            LoadMenu();

            this.mainController.EnableStatusChanged += controller_EnableStatusChanged;
            this.mainController.ConfigChanged += controller_ConfigChanged;
            this.mainController.EnableGlobalChanged += controller_EnableGlobalChanged;
            this.mainController.Errored += controller_Errored;
            this.mainController.TrafficChanged += controller_TrafficChanged;

            this.notifyIcon = new NotifyIcon();

            UpdateTrayIcon();

            this.notifyIcon.Visible = true;
            this.notifyIcon.ContextMenu = contextMenu;
            this.notifyIcon.MouseDoubleClick += notifyIcon_DoubleClick;
            this.notifyIcon.BalloonTipClicked += notifyIcon_BalloonTipClicked;
            this.notifyIcon.BalloonTipClosed += notifyIcon_BalloonTipClosed;

            LoadCurrentConfiguration();

            Configuration config = this.mainController.GetConfigurationCopy();
            this.updateChecker = new UpdateChecker();
            this.updateChecker.CheckUpdateCompleted += updateChecker_CheckUpdateCompleted;
            this.updateChecker.CheckUpdate(config, 5000);
        }

        private void controller_TrafficChanged(object sender, EventArgs e)
        {
            if (user.token == null) {
                return;
            }

            if (icon_baseBitmap == null)
                return;

            Icon newIcon;

            bool hasInbound = this.mainController.trafficPerSecondQueue.Last().inboundIncreasement > 0;
            bool hasOutbound = this.mainController.trafficPerSecondQueue.Last().outboundIncreasement > 0;

            if (hasInbound && hasOutbound)
                newIcon = icon_both;
            else if (hasInbound)
                newIcon = icon_in;
            else if (hasOutbound)
                newIcon = icon_out;
            else
                newIcon = icon_base;

            if (newIcon != this.targetIcon && notifyIcon!=null)
            {
                this.targetIcon = newIcon;
                notifyIcon.Icon = newIcon;
            }
        }

        private void controller_Errored(object sender, System.IO.ErrorEventArgs e)
        {
            MessageBox.Show(e.GetException().ToString(), String.Format(I18N.GetString("ShadowSocks Error: {0}"), e.GetException().Message));
        }

        #region Tray Icon

        private void UpdateTrayIcon()
        {
            int dpi;
            Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            dpi = (int)graphics.DpiX;
            graphics.Dispose();
            icon_baseBitmap = null;
            if (dpi < 97)
            {
                icon_baseBitmap = Resources.logo32;
            }
            else if (dpi < 121)
            {
                icon_baseBitmap = Resources.logo40;
            }
            else
            {
                icon_baseBitmap = Resources.logo48;
            }
            Configuration config = this.mainController.GetConfigurationCopy();
            bool enabled = config.enabled;
            bool global = config.global;
            icon_baseBitmap = getTrayIconByState(icon_baseBitmap, enabled, global);

            icon_base = Icon.FromHandle(icon_baseBitmap.GetHicon());
            targetIcon = icon_base;
            icon_in = Icon.FromHandle(AddBitmapOverlay(icon_baseBitmap, Resources.ico_in24).GetHicon());
            icon_out = Icon.FromHandle(AddBitmapOverlay(icon_baseBitmap, Resources.ico_out24).GetHicon());
            icon_both = Icon.FromHandle(AddBitmapOverlay(icon_baseBitmap, Resources.ico_in24, Resources.ico_out24).GetHicon());
            notifyIcon.Icon = targetIcon;

            string serverInfo = null;
            if (this.mainController.GetCurrentStrategy() != null)
            {
                serverInfo = this.mainController.GetCurrentStrategy().Name;
            }
            else
            {
                serverInfo = config.GetCurrentServer().FriendlyName();
            }
            string text = siteConfig.sitename + " " + UpdateChecker.Version + "\n" +
                          (enabled ? "加速服务已启用：" + (global ? "全局模式" : "智能模式") :
                              String.Format("加速服务未启用：Port {0}", config.localPort))  
                          + "\n" + serverInfo;
            ViewUtils.SetNotifyIconText(notifyIcon, text);
        }

        private Bitmap getTrayIconByState(Bitmap originIcon, bool enabled, bool global)
        {
            Bitmap iconCopy = new Bitmap(originIcon);
            for (int x = 0; x < iconCopy.Width; x++)
            {
                for (int y = 0; y < iconCopy.Height; y++)
                {
                    Color color = originIcon.GetPixel(x, y);
                    if (color.A != 0)
                    {
                        if (!enabled)
                        {
                            Color flyBlue = Color.FromArgb(192, 192, 192);
                            int red = color.R * flyBlue.R / 255;
                            int green = color.G * flyBlue.G / 255;
                            int blue = color.B * flyBlue.B / 255;
                            iconCopy.SetPixel(x, y, Color.FromArgb(color.A, red, green, blue));
                        }
                        else if (global)
                        {
                            Color flyBlue = Color.FromArgb(120, 120, 120);
                            int red   = color.R * flyBlue.R / 255;
                            int green = color.G * flyBlue.G / 255; 
                            int blue  = color.B * flyBlue.B / 255;
                            iconCopy.SetPixel(x, y, Color.FromArgb(color.A, red, green, blue));
                        }
                    }
                    else
                    {
                        iconCopy.SetPixel(x, y, Color.FromArgb(color.A, color.R, color.G, color.B));
                    }
                }
            }
            return iconCopy;
        }

        private Bitmap AddBitmapOverlay(Bitmap original, params Bitmap[] overlays)
        {
            Bitmap bitmap = new Bitmap(original.Width, original.Height, PixelFormat.Format64bppArgb);
            Graphics canvas = Graphics.FromImage(bitmap);
            canvas.DrawImage(original, new Point(0, 0));
            foreach (Bitmap overlay in overlays)
            {
                canvas.DrawImage(new Bitmap(overlay, original.Size), new Point(0, 0));
            }
            canvas.Save();
            return bitmap;
        }

        #endregion

        #region MenuItems and MenuGroups

        private MenuItem CreateMenuItem(string text, EventHandler click)
        {
            return new MenuItem(text, click);
        }

        private MenuItem CreateMenuGroup(string text, MenuItem[] items)
        {
            return new MenuItem(text, items);
        }

        private void LoadMenu()
        {
            this.contextMenu = new ContextMenu(new MenuItem[] {
                this.enableItem = CreateMenuItem("启用系统加速", new EventHandler(this.EnableItem_Click)),
                this.modeItem = CreateMenuGroup("系统加速模式", new MenuItem[] {
                    this.globalModeItem = CreateMenuItem("全局模式", new EventHandler(this.GlobalModeItem_Click)),
                    this.PACModeItem = CreateMenuItem("智能模式", new EventHandler(this.PACModeItem_Click))
                }),
                this.ServersItem = CreateMenuGroup("加速节点", new MenuItem[] {
                    new MenuItem("-")
                }),
                new MenuItem("-"),
                CreateMenuItem("访问官网", new EventHandler(this.web_home_click)),
                CreateMenuItem("个人中心", new EventHandler(this.web_profile_click)),
                new MenuItem("-"),
                CreateMenuItem("退出", new EventHandler(this.quit_Click))
            });
        }

        #endregion

        private void controller_ConfigChanged(object sender, EventArgs e)
        {
            if (user.token == null) {
                return;
            }
            LoadCurrentConfiguration();
            UpdateTrayIcon();
        }

        private void controller_EnableStatusChanged(object sender, EventArgs e)
        {
            enableItem.Checked = this.mainController.GetConfigurationCopy().enabled;
            modeItem.Enabled = enableItem.Checked;
        }
        
        private void controller_EnableGlobalChanged(object sender, EventArgs e)
        {
            globalModeItem.Checked = this.mainController.GetConfigurationCopy().global;
            PACModeItem.Checked = !globalModeItem.Checked;
        }

        private void updateChecker_CheckUpdateCompleted(object sender, EventArgs e)
        {
            siteConfig.version = updateChecker.LatestVersionNumber;

            if (updateChecker.NewVersionFound)
            {
                this.showBalloonTip(
                    String.Format("{0}有最新版本：{1}", 
                    siteConfig.sitename,
                    updateChecker.LatestVersionNumber + updateChecker.LatestVersionSuffix), 
                    "点击立即升级", 
                    ToolTipIcon.Info, 
                    3000
                );
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (updateChecker.NewVersionFound)
            {
                updateChecker.NewVersionFound = false;
                if (System.IO.File.Exists(updateChecker.LatestVersionLocalName))
                {
                    string argument = "/select, \"" + updateChecker.LatestVersionLocalName + "\"";
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
        }

        private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            if (updateChecker.NewVersionFound)
            {
                updateChecker.NewVersionFound = false;
            }
        }

        private void LoadCurrentConfiguration()
        {
            Configuration config = this.mainController.GetConfigurationCopy();
            UpdateServersMenu();
            enableItem.Checked = config.enabled;
            modeItem.Enabled = config.enabled;
            globalModeItem.Checked = config.global;
            PACModeItem.Checked = !config.global;

            if (user.expired)
            {
                this.enableItem.Enabled = false;
                this.modeItem.Enabled = false;
            }
        }

        private void UpdateServersMenu()
        {
            ServersItem.MenuItems.Clear();
            Configuration configuration = this.mainController.GetConfigurationCopy();
            if (configuration.configs!=null && configuration.configs.Count > 0)
            {
                for (int i = 0; i < configuration.configs.Count; i++)
                {
                    Server server = configuration.configs[i];
                    MenuItem item = new MenuItem(server.FriendlyName());
                    if (user.expired)
                    {
                        item.Enabled = false;
                    }
                    item.Tag = server.id;
                    item.Click += AServerItem_Click;
                    ServersItem.MenuItems.Add(i, item);
                }

                for (int j = 0; j < ServersItem.MenuItems.Count; j++)
                {

                    MenuItem item = ServersItem.MenuItems[j];
                    if (configuration.index == 0 && j == 0)
                    {
                        item.Checked = true;
                    }

                    int currentServerId = configuration.GetCurrentServer().id;
                    if (item.Tag != null && currentServerId == (int)item.Tag)
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            mainForm.ExitApplication();
        }

        private void web_home_click(object sender, EventArgs e)
        {
            string aboutUri = Constants.DEFAULT_SEVER_ROOT;
            Util.Utils.redirectToWebUrl(aboutUri);
        }

        private void web_profile_click(object sender, EventArgs e)
        {
            string userCenterUri = Constants.DEFAULT_SEVER_ROOT + Constants.USER_CENTER_URI;
            Util.Utils.redirectToWebUrl(userCenterUri);
        }

        private void notifyIcon_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ViewManager.instance.showMainForm();
            }
        }

        private void EnableItem_Click(object sender, EventArgs e)
        {
            this.mainController.ToggleEnable(!enableItem.Checked);

            int currentServerIndex = this.mainController.GetConfigurationCopy().index;
            int currentServerId = this.getServerIdByIndex(currentServerIndex);
            if (enableItem.Checked)
            {
                this.addServerConnectCount(currentServerId);
            }
            else {
                this.subServerConnectCount(currentServerId);
            }
        }

        private void GlobalModeItem_Click(object sender, EventArgs e)
        {
            this.mainController.ToggleGlobal(true);
        }

        private void PACModeItem_Click(object sender, EventArgs e)
        {
            this.mainController.ToggleGlobal(false);
        }
        
        private void AServerItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            int serverId = (int)item.Tag;

            Configuration config = this.mainController.GetConfigurationCopy();

            if (config.enabled)
            {
                int preServerIndex = config.index;
                int preServerId = this.getServerIdByIndex(preServerIndex);
                this.subServerConnectCount(preServerId);
            }


            int serverIndex = this.getServerIndexFormList(serverId);
            this.mainController.SelectServerIndex(serverIndex);

            if (config.enabled)
            {
                this.addServerConnectCount(serverId);
            }

        }

        private int getServerIndexFormList(int serverId) {
            List<Server> servers = this.mainController.GetConfigurationCopy().configs;
            int serverIndex = 0;
            for (int i = 0; i < servers.Count; i++)
            {
                Server server = servers[i];
                if (server.id == serverId)
                {
                    serverIndex = i;
                    break;
                }
            }
            return serverIndex;
        }

        public void controlNotifyTray(bool visiable)
        {
            this.notifyIcon.Visible = visiable;
        }
        
        public void showBalloonTip(string title, string content, ToolTipIcon icon, int timeout)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = content;
            notifyIcon.BalloonTipIcon = icon;
            notifyIcon.ShowBalloonTip(timeout);
        }

        private int getServerIdByIndex(int index)
        {
            List<Server> servers = this.mainController.GetConfigurationCopy().configs;
            return servers[index].id;
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
            catch { }
        }
    }
}
