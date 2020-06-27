using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 模块可视化的承载/管理
    /// </summary>
    public interface IHostModule
    {
        IModuleVisualable Render { get; set; }

        bool IsRegister(IModule module);

        void RegisterModule(IModule module);

        void UnRegisterMolude(IModule module);

        void RenderModule();

        object ExcuteCommand(object obj);
    }
}
