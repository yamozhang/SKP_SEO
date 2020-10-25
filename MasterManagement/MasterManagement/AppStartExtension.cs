using System;
using MLogin;
using MainApp;
using System.Text;
using MAppServices;
using System.Windows.Forms;
using System.Collections.Generic;
using MFrameworke.Base.AppModule;
using MLogin.Services;

namespace Master.Setup
{
    internal static class AppStartExtension
    {
        /// <summary>
        /// 后台业务服务注册
        /// </summary>
        /// <param name="start"></param>
        internal static void UseService(this AppStart start)
        {
            start.App.Use(next =>
            {
                return context => {
                    AppService.Start();
                    next?.Invoke(context);
                };
            });
        }

        /// <summary>
        /// 使用登录
        /// </summary>
        /// <param name="start"></param>
        internal static void UseAuth(this AppStart start)
        {
            start.App.Use(next => 
            {
                return context => {
                    //登录验证
                    UserAuthService.AuthService.BeginCheckAuth();
                    if (UserAuthService.AuthService.IsAuth)
                        next?.Invoke(context);
                };
            });
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="start"></param>
        internal static void UseMainApp(this AppStart start)
        {
            start.App.Use(next => {
                return context => {

                    IModuleVisualable app = new MainForm();
                    IHostModule host = new MainHostModule(app);
                    HostModuleManageCurrent.Current.SetHostModule(host);
                    HostModuleManageCurrent.Current.RegisterModuleToHost();
                    HostModuleManageCurrent.Current.Render();

                    start.HostModule = host as MainHostModule;
                    start.HostModuleManager = HostModuleManageCurrent.Current;

                    Application.Run(app as Form);
                    next.Invoke(context);
                };
            });
        }
    }
}
