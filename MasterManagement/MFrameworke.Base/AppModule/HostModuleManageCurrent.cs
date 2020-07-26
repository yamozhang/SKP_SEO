using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 程序全局默认的HostModuleManage
    /// </summary>
    public class HostModuleManageCurrent
    {
        static HostModuleManageCurrent()
        {
            _current = new DefaultHostModuleBuilder().GetHostModule();
        }


        private static HostModuleManage _current;


        public static HostModuleManage Current => _current;

        public static void SetHostModuleManage(HostModuleManage hostManage)
        {
            if (hostManage == null)
                throw new ArgumentNullException(nameof(hostManage));

            _current = hostManage;
        }
    }
}
