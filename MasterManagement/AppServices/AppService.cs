using MBusiness;

namespace MAppServices
{
    /// <summary>
    /// 整个程序的上层服务启动入口
    /// </summary>
    public class AppService
    {
        public static void Start()
        {
            ListenerSubscribeMachine.SubscribeListening();
        }
    }
}
