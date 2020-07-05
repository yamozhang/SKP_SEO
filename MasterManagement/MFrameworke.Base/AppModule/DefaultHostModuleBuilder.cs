using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 提供默认HostModuleManage实例
    /// </summary>
    internal class DefaultHostModuleBuilder
    {
        internal DefaultHostModuleBuilder()
        { }


        internal DefualtHostModuleManage GetHostModule()
        {
            return new DefualtHostModuleManage(null, new DefaultModuleManage());
        }
    }
}
