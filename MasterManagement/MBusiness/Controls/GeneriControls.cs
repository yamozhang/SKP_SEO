using MEventBus;
using System;
using MBusiness.ControlsParse;

namespace MBusiness.Controls
{
    /// <summary>
    /// 一个通用的事件侦听器
    /// </summary>
    internal class GeneriControls : IListener
    {
        public object Listener => null;

        public bool CanHandle(Event e)
        {
            return true;
        }

        public TaskPromise Listening(Event e)
        {
            return this.Execute(e);
        }


        internal TaskPromise Execute(Event e)
        {
            ControlContextProvider controlProvider = new ControlContextProvider();
            ControlContext controlContext = controlProvider.Provider(e.Parmes);
            if (controlContext.Control == null || controlContext.Action == null)
                throw new Exception("未能解析出controler与action，请设置controler与action。");
            return controlContext.Action.Execute();
        }
    }
}
