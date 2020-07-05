using MFrameworke.Base.AppModule;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Setup
{
    internal class MainHostModule : IHostModule
    {
        public MainHostModule(IModuleVisualable render)
        {
            this.Render = render;
            this.RegisModules = new List<IModule>();
        }


        public IModuleVisualable Render { get; }
        public List<IModule> RegisModules { get; }
        

        public bool IsRegister(IModule module)
        {
            return this.RegisModules.IndexOf(module) > -1;
        }

        public void RegisterModule(IModule module)
        {
            if (module == null || this.IsRegister(module))
                return;

            this.RegisModules.Add(module);
        }

        public void UnRegisterMolude(IModule module)
        {
            if (module == null || !this.IsRegister(module))
                return;

            this.Render.UnInstallModule(module);
            this.RegisModules.Remove(module);
        }

        public void RenderModule()
        {
            foreach (IModule modul in this.RegisModules)
                this.Render.VisualModule(modul);
        }


        public object ExcuteCommand(object obj)
        {
            return null;
        }

        public void Dispose()
        {
            foreach (IModule module in this.RegisModules)
                module.Dispose();

            this.RegisModules.Clear();
        }
    }
}
