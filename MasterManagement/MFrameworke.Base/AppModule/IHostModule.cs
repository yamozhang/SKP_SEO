using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 模块可视化的承载/管理
    /// </summary>
    public interface IHostModule : IDisposable
    {
        /// <summary>
        /// module界面呈现
        /// </summary>
        IModuleVisualable Render { get; }
        /// <summary>
        /// 是否已经注册
        /// </summary>
        bool IsRegister(IModule module);
        /// <summary>
        /// 注册
        /// </summary>
        void RegisterModule(IModule module);
        /// <summary>
        /// 卸载
        /// </summary>
        void UnRegisterMolude(IModule module);
        /// <summary>
        /// 开始渲染模块
        /// </summary>
        void RenderModule();

        object ExcuteCommand(object obj);
    }
}
