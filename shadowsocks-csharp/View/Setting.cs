using System;
using System.ComponentModel;
using System.Diagnostics;

using MaterialSkin;
using MaterialSkin.Controls;

using System.Windows.Forms;
using ShadowSocks.Model;
using ShadowSocks.Config;
using ShadowSocks.Controller;

namespace ShadowSocks.View
{
    public partial class Setting : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        private readonly ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));

        private Configuration configuration;

        private ShadowSocksController mainController;

        private MenuViewController menuController;

        private UpdateChecker updateChecker;

        private SiteConfig siteConfig;

        public Setting()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue500, Primary.LightBlue500, Primary.Amber900, Accent.Amber700, TextShade.WHITE);

            this.menuController = ViewManager.instance.MenuController;
            this.mainController = ViewManager.instance.MainController;

            this.mainController.PACFileReadyToOpen += controller_FileReadyToOpen;
            this.mainController.UpdatePACFromGFWListCompleted += controller_UpdatePACFromGFWListCompleted;
            this.mainController.UpdatePACFromGFWListError += controller_UpdatePACFromGFWListError;

            this.siteConfig = SiteConfig.instance();
            this.configuration = this.mainController.GetConfigurationCopy();

            this.updateChecker = new UpdateChecker();
            this.updateChecker.CheckUpdateCompleted += updateChecker_CheckUpdateCompleted;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            chkAutoRun.Checked = AutoStartup.Check();
            chkLAN.Checked = configuration.shareOverLan;
            chkLAN.CheckedChanged += chkLAN_CheckedChanged;

            String currentVersion = Util.Utils.getCurrentVersion();
            if (siteConfig.version.IsNullOrEmpty() || currentVersion == siteConfig.version)
            {
                btnUpdate.Text = "当前已是最新版本";
                btnUpdate.Enabled = false;
            }
            else {
                btnUpdate.Enabled = true;
                btnUpdate.Text = "检查更新";
                btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            }
        }

        private void controller_FileReadyToOpen(object sender, ShadowSocksController.PathEventArgs e)
        {
            string argument = @"/select, " + e.Path;
            Process.Start("explorer.exe", argument);
        }

        private void controller_UpdatePACFromGFWListError(object sender, System.IO.ErrorEventArgs e)
        {
            btnPacRemote.Text = "从官方更新本地PAC文件";
            btnPacRemote.Enabled = true;

            ViewManager.instance.showBalloonTip("更新PAC文件失败", e.GetException().Message, ToolTipIcon.Error, 5000);
            Logging.LogUsefulException(e.GetException());
        }

        private void controller_UpdatePACFromGFWListCompleted(object sender, GFWListUpdater.ResultEventArgs e)
        {

            btnPacRemote.Text = "从官方更新本地PAC文件";
            btnPacRemote.Enabled = true;

            string result = e.Success
                ? "更新PAC文件成功。"
                : "未发现更新内容";
            ViewManager.instance.showBalloonTip("系统提示", result, ToolTipIcon.Info, 1000);
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (!AutoStartup.Set(chkAutoRun.Checked))
            {
                MessageBox.Show("设置开机启动失败。");
            }
        }

        private void updateChecker_CheckUpdateCompleted(object sender, EventArgs e)
        {
            btnUpdate.Text = "检查更新";
            btnUpdate.Enabled = true;

            if (updateChecker.NewVersionFound)
            {
                ViewManager.instance.showBalloonTip(
                    String.Format("{0}有最新版本：{1}",
                    this.siteConfig.sitename,
                    updateChecker.LatestVersionNumber + updateChecker.LatestVersionSuffix),
                    "点击立即更新",
                    ToolTipIcon.Info,
                    5000
                );
            }
        }

        private void chkLAN_CheckedChanged(object sender, EventArgs e)
        {
            this.mainController.ToggleShareOverLAN(chkLAN.Checked);
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            ViewManager viewManager = ViewManager.instance;
            viewManager.showLogForm();

            Log logForm = viewManager.LogForm;
            logForm.FormClosed += logForm_FormClosed;
        }

        private void logForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewManager.instance.closeLogForm();
        }

        private void btnPacEdit_Click(object sender, EventArgs e)
        {
            this.mainController.TouchPACFile();
        }

        private void btnPacRemote_Click(object sender, EventArgs e)
        {
            btnPacRemote.Text = "检查更新中...";
            btnPacRemote.Enabled = false;
            this.mainController.UpdatePACFromGFWList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Text = "检查更新中...";
            btnUpdate.Enabled = false;
            
            this.updateChecker.CheckUpdate(this.configuration);
        }

        private void redirectAboutPage()
        {
            string aboutUri = Constants.DEFAULT_SEVER_ROOT;
            Util.Utils.redirectToWebUrl(aboutUri);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            string userCenterUri = Constants.DEFAULT_SEVER_ROOT + Constants.USER_CENTER_URI;
            Util.Utils.redirectToWebUrl(userCenterUri);
        }

        private void picAbout_Click(object sender, EventArgs e)
        {
            this.redirectAboutPage();
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            this.redirectAboutPage();
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainController.PACFileReadyToOpen -= controller_FileReadyToOpen;
            this.mainController.UpdatePACFromGFWListCompleted -= controller_UpdatePACFromGFWListCompleted;
            this.mainController.UpdatePACFromGFWListError -= controller_UpdatePACFromGFWListError;
        }
    }
}
