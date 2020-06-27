using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// Module集合
    /// </summary>
    public class ModuleCollection : IEnumerable<IModule>
    {
        public ModuleCollection()
        {
            this.modules = new List<IModule>();
        }



        private List<IModule> modules;




        public IModule this[string name]
        {
            get => this.modules.Find(m => m.Name.Equals(name));
        }
        public IModule this[int index]
        {
            get => this.modules[index];
        }




        public bool Exists(IModule module)
        {
            return this.modules.Contains(module);
        }

        public void Add(IModule module)
        {
            if (module == null)
                return;

            this.modules.Add(module);
        }

        public void Remove(IModule module)
        {
            if (module == null)
                return;

            this.modules.Remove(module);
        }


        public IEnumerator<IModule> GetEnumerator()
        {
            foreach (IModule m in this.modules)
                yield return m;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
