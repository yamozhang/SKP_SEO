using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 用于处理module在界面的显示与卸载
    /// </summary>
    public interface IModuleVisualable
    {
        void VisualModule(IModule module);

        void UnInstallModule(IModule module);
    }
}
