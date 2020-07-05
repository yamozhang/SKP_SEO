using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Data;

namespace MFrameworke.Base.AppModule
{
    public static class ModuleLoader
    {
        /// <summary>
        /// Module加载
        /// </summary>
        public static IModule LoadModule(string mDllPath)
        {
            if (!File.Exists(mDllPath))
                return null;

            try
            {
                Assembly assembly = Assembly.LoadFrom(mDllPath);
                Type mType = typeof(IModule);
                Type module = assembly.GetTypes()?
                                      .FirstOrDefault(t => mType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

                return module != null ? (IModule)Activator.CreateInstance(module, false) : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now:yyyy/MM/dd hh:mm:ss} - {ex.Message} - 模块加载失败。");
                return null;
            }
        }

        public static IEnumerable<IModule> LoadModules(string dirPaht)
        {
            return null;
        }
    }
}
