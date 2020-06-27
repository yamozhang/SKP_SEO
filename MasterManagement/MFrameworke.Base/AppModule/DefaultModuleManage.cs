using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    internal class DefaultModuleManage : ModuleManage
    {
        public DefaultModuleManage()
        {
            this.RegisterPath("./");
        }



        public override bool LoadModule(string path)
        {
            try
            {
                return ModuleLoader.LoadModule(path) != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Module Load fail：{path}, {ex.Message}");
            }
            return false;
        }

        public override void RegisterPath(string path)
        {
            
            base.RegisterPath(path);
        }

    }
}
