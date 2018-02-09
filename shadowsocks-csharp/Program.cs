using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

using ShadowSocks.Controller;
using ShadowSocks.Controller.Hotkeys;
using ShadowSocks.Util;
using ShadowSocks.View;

namespace ShadowSocks
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Utils.IsWinVistaOrHigher())
            {
                MessageBox.Show(
                    "不支持的操作系统版本，最低需求为Windows Vista。",
                    "系统提示", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
                return;
            }

            if (!Utils.IsSupportedRuntimeVersion())
            {
                MessageBox.Show(
                    "当前 .NET Framework 版本过低，请升级至4.6.2或更新版本。",
                    "系统提示", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );

                Process.Start("http://dotnetsocial.cloudapp.net/GetDotnet?tfm=.NETFramework,Version=v4.6.2");
                return;
            }

            Utils.ReleaseMemory(true);

            using (Mutex mutex = new Mutex(false, $"Global\\GreenDot_{Application.StartupPath.GetHashCode()}"))
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.ApplicationExit += Application_ApplicationExit;
                SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!mutex.WaitOne(0, false))
                {
                    Process[] oldProcesses = Process.GetProcessesByName("GreenDot Windows");
                    if (oldProcesses.Length > 0)
                    {
                        Process oldProcess = oldProcesses[0];
                    }
                    MessageBox.Show(
                        "加速服务正在运行中，请在任务栏查找相关图标。",
                        "系统提示",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                Directory.SetCurrentDirectory(Application.StartupPath);

                Logging.OpenLogFile();

                HotKeys.Init(ViewManager.instance.MainController);

                Login loginForm = new Login();
                Application.Run(loginForm);
            }
        }

        private static int exited = 0;

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (Interlocked.Increment(ref exited) == 1)
            {
                Environment.Exit(0);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (Interlocked.Increment(ref exited) == 1)
            {
                Environment.Exit(0);
            }
        }

        private static void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            ShadowSocksController mainController = ViewManager.instance.MainController;

            switch (e.Mode)
            {
                case PowerModes.Resume:
                    Logging.Info("os wake up");
                    if (mainController != null)
                    {
                        System.Timers.Timer timer = new System.Timers.Timer(10 * 1000);
                        timer.Elapsed += Timer_Elapsed;
                        timer.AutoReset = false;
                        timer.Enabled = true;
                        timer.Start();
                    }
                    break;
                case PowerModes.Suspend:
                    if (mainController != null)
                    {
                        mainController.Stop();
                        Logging.Info("main controller stopped");
                    }
                    Logging.Info("os suspend");
                    break;
            }
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (ViewManager.instance.MainController != null)
                {
                    ViewManager.instance.MainController.Start();
                    Logging.Info("main controller started");
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
            finally
            {
                try
                {
                    System.Timers.Timer timer = (System.Timers.Timer)sender;
                    timer.Enabled = false;
                    timer.Stop();
                    timer.Dispose();
                }
                catch (Exception ex)
                {
                    Logging.LogUsefulException(ex);
                }
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Application.ApplicationExit -= Application_ApplicationExit;
            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
            Application.ThreadException -= Application_ThreadException;
            HotKeys.Destroy();

            ViewManager viewManager = ViewManager.instance;

            if (viewManager.MainController != null)
            {
                viewManager.closeMainController();
            }
            SystemProxy.Disable();
        }
    }
}
