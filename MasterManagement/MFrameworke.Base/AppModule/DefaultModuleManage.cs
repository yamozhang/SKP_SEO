using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 提供默认的ModuleManage , 用于加载系统默认的界面模块阔扩展
    /// </summary>
    internal class DefaultModuleManage : ModuleManage
    {
        internal DefaultModuleManage()
        {
            this.Modules = new ModuleCollection();
            this.LoadDefaultPath();
        }



        public override ModuleCollection Modules { get;}



        private bool LoadModuleFromFile(string file)
        {
            IModule modul = ModuleLoader.LoadModule(file);
            if (modul == null)
                return false;

            this.Modules.Add(modul);
            return true;
        }
        private bool LoadModuleFromFolder(string folder)
        {
            string[] modulesPath = Directory.GetFiles(folder, "*.dll");
            if (modulesPath == null)
                return false;
            foreach (string p in modulesPath)
                this.LoadModuleFromFile(p);
            return true;
        }
        private void LoadDefaultPath()
        {
            this.LoadModule(Path.GetFullPath("./"));
        }



        public override bool LoadModule(string path)
        {
            if (File.Exists(path))
                return this.LoadModuleFromFolder(path);
            else if (Directory.Exists(path))
                return this.LoadModuleFromFolder(path);
            return false;
        }
    }

}
