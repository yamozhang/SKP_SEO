using System;
using System.Collections.Generic;
using System.Text;

namespace MEventBus
{
    /// <summary>
    /// 事件侦听器
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// 表示当前侦听器的标识
        /// </summary>
        object Listener { get; }

        /// <summary>
        /// 侦听器是否可以接收当前事件
        /// </summary>
        bool CanHandle(Event e)
        {
            return e.Listener == this.Listener;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        TaskPromise Listening(Event e);
    }
}
