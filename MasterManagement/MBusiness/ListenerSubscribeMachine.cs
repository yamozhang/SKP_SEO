using MBusiness.Controls;
using MEventBus;

namespace MBusiness
{
    /// <summary>
    /// 侦听器注册机
    /// </summary>
    public class ListenerSubscribeMachine
    {
        public static void SubscribeListening()
        {
            GlobalListening(EventBus.Bus);
        }

        private static void GlobalListening(EventBus bus)
        {
            bus.AddListener(new GeneriControls());
        }
    }
}
