using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShadowSocks.Controller;
using System.Windows.Forms;

namespace ShadowSocks.View
{
    public class ViewManager
    {
        
        private static ViewManager viewManager;

        private Main mainForm;
        private Log logForm;
        private Setting settingForm;
        private Login loginForm;
        private Notice noticeForm;

        private MenuViewController menuController;
        private ShadowSocksController mainController;
        
        public ViewManager()
        {
        }

        public static ViewManager instance
        {
            get
            {
                if (viewManager == null)
                {
                    viewManager = new ViewManager();
                }
                return viewManager;
            }
        }

        public ShadowSocksController MainController {
            get
            {
                if (mainController == null)
                {
                    mainController = ShadowSocksController.instance();
                }
                return mainController;
            }
        }

        public MenuViewController MenuController {
            get
            {
                if (menuController == null)
                {
                    menuController = new MenuViewController();
                }
                return menuController;
            }
        }

        public Main MainForm {
            get {
                if (this.mainForm == null || this.mainForm.IsDisposed)
                {
                    this.mainForm = new Main();
                }
                return mainForm;
            }
        }

        public Login LoginForm {
            get
            {
                if (this.loginForm == null || this.loginForm.IsDisposed)
                {
                    this.loginForm = new Login();
                }
                return loginForm;
            }
        }

        public Setting SettingForm
        {
            get
            {
                if (this.settingForm == null || this.settingForm.IsDisposed)
                {
                    this.settingForm = new Setting();
                }
                return settingForm;
            }
        }

        public Log LogForm
        {
            get
            {
                if (this.logForm == null || this.logForm.IsDisposed)
                {
                    this.logForm = new Log();
                }
                return logForm;
            }
        }

        public Notice NoticeForm
        {
            get
            {
                if (this.noticeForm == null || this.noticeForm.IsDisposed)
                {
                    this.noticeForm = new Notice();
                }
                return noticeForm;
            }
        }


        public void showMainForm() {
            this.MainForm.Show();
            this.MainForm.Activate();
            this.MainForm.WindowState = FormWindowState.Normal;
            this.MainForm.BringToFront();
        }

        public void closeMainForm() {
            if (mainForm!=null)
            {
                mainForm.Hide();
            }
        }

        public void showLoginForm()
        {
            this.LoginForm.Show();
            this.LoginForm.Activate();
            this.LoginForm.WindowState = FormWindowState.Normal;
            this.LoginForm.BringToFront();
        }

        public void closeLoginForm() {
            if (loginForm!=null)
            {
                loginForm.Hide();
            }
        }
        
        public void showLogForm()
        {
            this.LogForm.Show();
            this.LogForm.Activate();
            this.LogForm.WindowState = FormWindowState.Normal;
            this.LogForm.BringToFront();
        }

        public void closeLogForm()
        {
            if (logForm!=null)
            {
                logForm.Hide();
            }
        }

        public void showSettingForm()
        {
            this.SettingForm.Show();
            this.SettingForm.Activate();
            this.SettingForm.WindowState = FormWindowState.Normal;
            this.SettingForm.BringToFront();
        }

        public void showNoticeForm() {
            this.NoticeForm.Show();
            this.NoticeForm.Activate();
            this.NoticeForm.WindowState = FormWindowState.Normal;
            this.NoticeForm.BringToFront();
        }

        public void closeSettingForm()
        {
            if (settingForm!=null)
            {
                settingForm.Hide();
            }
        }

        public void closeNoticeForm() {
            if (noticeForm != null)
            {
                noticeForm.Hide();
            }
        }

        public void closeMainController() {
            if (mainController!=null)
            {
                mainController.Stop();
                mainController = null;
            }
        }

        public void controlNotifyTray(bool visiable) {
            if (menuController!=null)
            {
                menuController.controlNotifyTray(visiable);
            }
            if (visiable == false)
            {
                menuController = null;
            }
        }

        public void showBalloonTip(string title, string content, ToolTipIcon icon, int timeout) {
            if (menuController!=null)
            {
                menuController.showBalloonTip(title, content, icon, timeout);
            }
        }

    }
}
