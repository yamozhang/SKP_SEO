using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 程序默认全局的ModuleManager实例
    /// </summary>
    public class ModuleManageCurrent
    {

        static ModuleManageCurrent()
        {
            _current = new DefaultModuleManage();
        }


        private static ModuleManage _current;

        public static ModuleManage Current { get; private set; }

        public static void SetModuleManage(ModuleManage mrg)
        {
            if (mrg == null)
                throw new ArgumentNullException(nameof(mrg));
            _current = mrg;
        }
    }
}
