using System;
using System.Windows.Forms;
using MFrameworke.Base.AppModule;
using System.Collections.Generic;
using System.Text;
using MCash.Services;

namespace MUser
{
    public class CashModuleUI : IModule
    {
        public CashModuleUI()
        {
            this.CashModule = new CashService();
        }

        internal CashService CashModule { get; private set; }
        public string Name { get; set; } = "CashModule";
        public bool Visible { get; set; } = false;

        public void Dispose()
        {
           
        }

        public object ExcuteCommand(object obj)
        {
            return null;
        }

        public object[] LoadUIComponent(object[] a)
        {
            return new object[] {
                this.CashModule.ModuleMenu,
                this.CashModule.ModuleUI,
                this.CashModule.MenuHandle
            };
        }
    }
}
