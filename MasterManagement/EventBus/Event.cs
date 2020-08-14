using System;
using System.Collections.Generic;
using System.Text;

namespace MEventBus
{
    /// <summary>
    /// 事件
    /// </summary>
    public class Event
    {
        public Event()
        {
            this.Parmes = new Dictionary<string, object>();
        }
        public Event(object source, object listener) : this()
        {
            this.Source = source;
            this.Listener = listener;
        }


        /// <summary>
        /// 事件源    
        /// </summary>
        public object Source { get; }
        /// <summary>
        /// 期望得到的处理的listen标识
        /// </summary>
        public object Listener { get; }

        /// <summary>
        /// 传递给侦听器的额外的信息
        /// </summary>
        public Dictionary<string, object> Parmes { get; set; }
    }
}
