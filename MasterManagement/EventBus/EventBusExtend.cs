using System;
using System.Collections.Generic;
using System.Text;

namespace MEventBus
{
    public static class EventBusExtend
    {
        public static TaskPromise PublishEvent(this EventBus bus, object listener, object source, object pars)
        {
            if (bus == null)
                throw new NullReferenceException();

            Event e = EventFactory.NewEvent(listener, source, pars);
            return bus.PublishEvent(e);
        }
    }
}
