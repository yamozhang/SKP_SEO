using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MEventBus
{
    /// <summary>
    /// 提供Event的创建
    /// </summary>
    public static class EventFactory
    {
        public static Dictionary<string, object> TakeFiled(object pars)
        {
            if (pars == null)
                return null;

            Dictionary<string, object> filed = new Dictionary<string, object>();
            Type t = pars.GetType();
            foreach (PropertyInfo p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                filed.Add(p.Name,p.GetValue(pars));
            }
            return filed;
        }
        public static Event NewEvent(object listener, object source, object pars)
        {
            return new Event(listener, source)
            {
                Parmes = TakeFiled(pars)
            };
        }
    }
}
