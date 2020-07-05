using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 提供Module的加载，对加载module的管理
    /// </summary>
    public abstract class ModuleManage
    {
        public ModuleManage()
        {}


        public abstract ModuleCollection Modules { get; }



        public bool IsLoad(string moduleName)
        {
            return this.GetModule(moduleName) != null;
        }
        public virtual IModule GetModule(string name)
        {
            return this.Modules?[name];
        }
        /// <summary>
        /// 指定路径Module(.Dll)加载
        /// </summary>
        public abstract bool LoadModule(string path);
    }
}
