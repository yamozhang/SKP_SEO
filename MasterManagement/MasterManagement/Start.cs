using System;
using MainApp;
using MFrameworke.Base.AppModule;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace Master.Setup
{
    internal static class Start
    {
        internal static MainHostModule HostModule { get; private set; }

        public static void StartUp(IModuleVisualable visual)
        {
            HostModule = new MainHostModule(visual);

            HostModuleManageProvider.Current.SetHostModule(HostModule);
            HostModuleManageProvider.Current.RegisterModuleToHost();
            HostModuleManageProvider.Current.Render();
        }
    }
}
