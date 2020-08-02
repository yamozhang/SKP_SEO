using System;
using System.Collections.Generic;
using System.Text;

namespace MBusiness.ControlsParse
{
    /// <summary>
    /// 解析出controler
    /// </summary>
    internal class ControlDescription
    {
        internal ControlDescription(Dictionary<string, object> pars)
        {
            this.Builder(pars);
        }

        /// <summary>
        /// 表示当前的controler
        /// </summary>
        internal Type ControlType { get; private set; }
        /// <summary>
        /// 表示当前的action
        /// </summary>
        internal ActionDescription Action { get; private set; }

        private void Builder(Dictionary<string, object> pars)
        {
            if (pars == null)
                return;

            this.ControlType = this.GetControl(pars);
            this.Action = this.BuilderAction(pars);
        }
        private Type GetControl(Dictionary<string, object> pars)
        {
            if (!pars.ContainsKey("controler") || pars["controler"] == null)
                throw new Exception("未指定controler.");
            string controler = pars["controler"].ToString();

            Type t_controler = Type.GetType("MBusiness.Controls." + controler) ?? throw new Exception("Not found the controler");
            
            return t_controler;
        }
        private ActionDescription BuilderAction(Dictionary<string, object> pars)
        {
            return new ActionDescription(this, pars);
        }

        /// <summary>
        /// 构造当前control实例
        /// </summary>
        /// <returns></returns>
        internal object GetControlInst()
        {
            try
            {
                return Activator.CreateInstance(this.ControlType, true);
            }
            catch (Exception ex)
            {
                throw new Exception($"未能实例化controler：{this.ControlType.FullName}，请将构造函数设为无参。",ex);
            }
        }
    }
}
