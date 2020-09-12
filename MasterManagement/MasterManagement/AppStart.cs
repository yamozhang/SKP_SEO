using System;
using MainApp;
using MLogin;
using MAppServices;
using System.Windows.Forms;
using MFrameworke.Base.AppModule;
using MFrameworke.Base.AppExecute;

namespace Master.Setup
{
    internal class AppStart
    {
        public AppStart()
        {
            this.App = new AppLine();
        }


        internal MainHostModule HostModule { get; set; }
        internal HostModuleManage HostModuleManager { get; set; }
        internal AppLine App { get; set; }



        //启动程序
        internal static void StartUp()
        {
            AppStart start = new AppStart();
            start.UseService();  //设置程序服务启动
            start.UseAuth();     //生成验证过程
            start.UseMainApp();  //主程序启动过程
            start.App.Use(_ => context => { }); //default 

            start.App.Builder?.Invoke(null);
        }
    }
}
