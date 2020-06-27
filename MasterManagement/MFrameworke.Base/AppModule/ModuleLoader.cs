using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace MFrameworke.Base.AppModule
{
    public static class ModuleLoader
    {
        /// <summary>
        /// Module加载
        /// </summary>
        public static IModule LoadModule(string path)
        {
            if (!File.Exists(path))
                return null;

            Assembly assembly = Assembly.LoadFrom(path);
            Type module = assembly.GetType("MFrameworke.Base.AppModule.IModule");
            if (module == null)
                return null;
            return;
        }

        public static IEnumerable<IModule> LoadModules(string dirPaht)
        {
            return null;
        }
    }
}
