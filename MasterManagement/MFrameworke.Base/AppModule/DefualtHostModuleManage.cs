using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 提供默认的HostModuleManage实现
    /// </summary>
    internal class DefualtHostModuleManage : HostModuleManage
    {
        internal DefualtHostModuleManage(IHostModule hostModule, ModuleManage moduleManage) : base(moduleManage)
        {
            this._hostModule = hostModule;
        }


        private IHostModule _hostModule;
        private ModuleManage _module;



        public override IHostModule HostModule => this._hostModule;
        public override ModuleManage Module
        {
            get => this._module;
            protected set => this._module = value;
        }


        public override void SetHostModule(IHostModule hostModule)
        {
            this._hostModule = hostModule;
        }
    }
}
