using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

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



        private IEnumerable<string> GetConfigModule()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(@".\app.config.json");
            IConfiguration config = configBuilder.Build();
            IConfigurationSection moduelSection = config.GetSection("UI:modules");
            IEnumerable<string> modules = moduelSection.AsEnumerable()
                                                       .Where(m => m.Key != "UI:modules")
                                                       .Select(m => config[m.Key]);
            return modules;
        }
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
            try
            {
                //获取配置文件中的UI模块
                IEnumerable<string> modules = this.GetConfigModule();
                foreach (string module in modules)
                {
                    //加载模块
                    this.LoadModule(Path.GetFullPath(module));
                }
            }
            catch
            {
                throw new Exception("未配置功能模块！");
            }
        }



        public override bool LoadModule(string path)
        {
            if (File.Exists(path))
                return this.LoadModuleFromFile(path);
            else if (Directory.Exists(path))
                return this.LoadModuleFromFolder(path);
            return false;
        }
    }

}
