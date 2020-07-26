using System;
using MainApp;
using MFrameworke.Base.AppModule;
using System.Windows.Forms;

namespace Master.Setup
{
    internal static class AppStart
    {
        internal static MainHostModule HostModule { get; private set; }
        internal static HostModuleManage HostModuleManager { get; private set; }

        //启动程序
        internal static void StartUp()
        {
            Form appForm = new MainForm();
            IHostModule hostModule = SetHostModule((IModuleVisualable)appForm);
            SetModule(hostModule);
            AppRun(appForm);
        }
        /// <summary>
        /// 设置HostModule
        /// </summary>
        internal static IHostModule SetHostModule(IModuleVisualable visual)
        {
            return HostModule = new MainHostModule(visual);
        }
        /// <summary>
        /// 设置模块
        /// </summary>
        internal static void SetModule(IHostModule host)
        {
            HostModuleManager = HostModuleManageCurrent.Current;
            HostModuleManageCurrent.Current.SetHostModule(host);
            HostModuleManageCurrent.Current.RegisterModuleToHost(); 
        }

        private static void AppRun(Form form)
        {
            using (IHostModule host = HostModuleManager.HostModule)
            {
                HostModuleManager.Render();
                Application.Run(form);
            }
        }
    }
}
