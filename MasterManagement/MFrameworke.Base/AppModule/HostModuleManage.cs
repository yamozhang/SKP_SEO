using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// IHostModule管理，关联Module
    /// </summary>
    public abstract class HostModuleManage : IDisposable
    {
        protected HostModuleManage()
        { }

        public HostModuleManage(ModuleManage moduleManage) : this()
        {
            this.Module = moduleManage ?? throw new ArgumentNullException(nameof(moduleManage));
        }



        /// <summary>
        /// 作用于当前HostModule的Module
        /// </summary>
        public virtual ModuleManage Module { get; protected set; }
        /// <summary>
        /// 当前的HostModule
        /// </summary>
        public abstract IHostModule HostModule { get; }


        /// <summary>
        /// 将Module注册至HostModule
        /// </summary>
        public virtual void RegisterModuleToHost()
        {
            if (this.HostModule == null)
                throw new NullReferenceException($"{nameof(this.HostModule)}属性不能为Null");

            if (this.Module == null)
                throw new NullReferenceException($"{nameof(this.Module)}属性不能为Null");

            foreach (IModule module in this.Module.Modules)
            {
                if (this.HostModule.IsRegister(module))
                    continue;
                this.HostModule.RegisterModule(module);
            }
        }
        /// <summary>
        /// 设置当前关联的HostModule
        /// </summary>
        public abstract void SetHostModule(IHostModule hostModule);
        public virtual void Dispose()
        {
            this.HostModule?.Dispose();
        }


        public void Render()
        {
            if (this.HostModule == null)
                return;

            this.HostModule.RenderModule();
        }
    }
}
