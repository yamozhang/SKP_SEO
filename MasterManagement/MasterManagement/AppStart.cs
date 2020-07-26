using System;
using MainApp;
using MLogin;
using System.Windows.Forms;
using Master.Setup.AppExecute;
using MFrameworke.Base.AppModule;

namespace Master.Setup
{
    internal class AppStart
    {
        public AppStart()
        {
            this.App = new AppExcuteLine();
        }

        internal MainHostModule HostModule { get; private set; }
        internal HostModuleManage HostModuleManager { get; private set; }
        internal AppExcuteLine App { get; private set; }

        //启动程序
        internal void StartUp()
        {
            this.BuilderAuth();
            this.BuillderMainApp();
            this.App.Builder?.Invoke(null);
        }
        //设置登录验证
        internal  void BuilderAuth()
        {
            this.App.Use(pre => {
                return contenxt => {
                    pre?.Invoke(contenxt);
                    using (AppLoginForm login = new AppLoginForm())
                    {
                        Application.Run(login);
                        if (!login.IsLogin)
                            Environment.Exit(0);
                    }
                };
            });
        }
        //设置主程序启动
        internal void BuillderMainApp()
        {
            this.App.Use(pre => {
                return context => {
                    pre.Invoke(context);
                    Form app = new MainForm();
                    this.SetHostModule((IModuleVisualable)app);
                    this.AppRun(app);
                };
            });
        }

        /// <summary>
        /// 设置HostModule
        /// </summary>
        private  void SetHostModule(IModuleVisualable visual)
        {
            HostModule = new MainHostModule(visual);
            HostModuleManager = HostModuleManageCurrent.Current;

            HostModuleManageCurrent.Current.SetHostModule(HostModule);
            HostModuleManageCurrent.Current.RegisterModuleToHost();
        }
      
        /// <summary>
        /// 启动主程序
        /// </summary>
        /// <param name="form"></param>
        private  void AppRun(Form form)
        {
            using (IHostModule host = HostModuleManager.HostModule)
            {
                HostModuleManager.Render();
                Application.Run(form);
            }
        }
    }
}
