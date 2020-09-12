using System;
using System.Threading.Tasks;
using MEventBus;

namespace MBusiness.Controls
{
    /// <summary>
    /// 一个基础的控制器
    /// </summary>
    internal abstract class BaseControls : IListener
    {
        public object Listener => this.Control;
        public bool CanHandle(Event e)
        {
            return this.ShouldHandle(e);
        }
        public TaskPromise Listening(Event e)
        {
            return this.Execute(e);
        }


        #region 通过抽象与虚方法提供子类扩展
        internal abstract object Control { get; }
        internal virtual bool ShouldHandle(Event e)
        {
            return false;
        }
        internal abstract TaskPromise Execute(Event e);
        #endregion

    }
}
