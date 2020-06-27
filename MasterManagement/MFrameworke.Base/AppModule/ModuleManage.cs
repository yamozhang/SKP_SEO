using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 提供Module的全局控制
    /// </summary>
    public abstract class ModuleManage
    {
        public ModuleManage()
        {
            this.Modules = new ModuleCollection();
        }
        public ModuleManage(IHostModule host) : this()
        {
            this.SetHostModule(host);
        }



        /// <summary>
        /// 扩展Module的承载体
        /// </summary>
        public IHostModule HostModule { get; protected set; }
        public ModuleCollection Modules { get; private set; }
        public  List<string> Paths { get; protected set; }


        /// <summary>
        /// 指定路径Module(.Dll)加载
        /// </summary>
        public abstract bool LoadModule(string path);

        public IModule GetModule(string name)
        {
            return this.Modules[name];
        }

        public virtual void RegisterPath(string path)
        {
            if (this.Paths == null)
                this.Paths = new List<string>();
            this.Paths.Add(path);
        }

        public virtual bool LoadModule()
        {
            if (this.Paths == null)
                return false;

            foreach (string path in this.Paths)
                if (this.LoadModule())
                    continue;
                else
                    return false;

            return false;
        }

        public virtual void RegisterModule(IModule module)
        {
            this.Modules.Add(module);
            this.HostModule?.RegisterModule(module);
        }

        public virtual void SetHostModule(IHostModule hostModule)
        {
            this.HostModule = hostModule;
        }

        /// <summary>
        /// 将扩展模块可视化
        /// </summary>
        public virtual void VisualModule()
        {
            if (this.HostModule == null)
                return;

            foreach (IModule m in this.Modules)
            {
                if (this.HostModule.IsRegister(m))
                    continue;
                this.HostModule.RegisterModule(m);
            }
            this.HostModule.RenderModule();
        }
        
    }
}
