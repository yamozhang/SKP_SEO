using System;
using System.Collections.Generic;
using System.Text;

namespace MEventBus
{
    /// <summary>
    /// 消息总线适配消息处理
    /// </summary>
    public class EventBus
    {
        private EventBus() {
            listeners = new HashSet<IListener>();
        }


        private HashSet<IListener> listeners;


        private static EventBus _bus;
        public static EventBus Bus => _bus ?? (_bus = new EventBus());


        /// <summary>
        /// 添加一个侦听器
        /// </summary>
        public void AddListener(IListener listener)
        {
            if (listener == null)
                throw new ArgumentNullException(nameof(listener));
            this.listeners.Add(listener);
        }


        /// <summary>
        /// 移除一个侦听器
        /// </summary>
        public void RemoveListener(IListener listener)
        {
            if (listener == null)
                return;

            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }


        /// <summary>
        /// 将消息发送所有匹配的侦听器
        /// </summary>
        public List<TaskPromise> PublishEvents(Event e)
        {
            List<TaskPromise> list = new List<TaskPromise>();
            foreach (IListener listener in this.listeners)
            {
                if (e.Listener != listener.Listener && !listener.CanHandle(e))//匹配当前的事件侦听器
                    continue;

                list.Add(listener.Listening(e));
            }
            return list;
        }

        /// <summary>
        /// 将消息发送到第一个匹配的侦听器
        /// </summary>
        public TaskPromise PublishEvent(Event e)
        {
            TaskPromise task = null;
            foreach (IListener listener in this.listeners)
            {
                if (e.Listener != listener.Listener && !listener.CanHandle(e))//匹配当前的事件侦听器
                    continue;

                task = listener.Listening(e);
                break;
            }
            return task;
        }
    }
}
