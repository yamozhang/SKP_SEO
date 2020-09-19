using System;
using System.Threading.Tasks;
using MEventBus;

namespace MBusiness.Controls
{
    /// <summary>
    /// 一个基础的控制器
    /// </summary>
    internal class BaseControls
    {
        internal TaskPromise Promise { get; set; }
    }
}
