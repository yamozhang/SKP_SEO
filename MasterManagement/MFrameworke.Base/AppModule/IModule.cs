using System;
using System.Collections.Generic;
using System.Text;

namespace MFrameworke.Base.AppModule
{
    /// <summary>
    /// 功能模块
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 模块标识，应该唯一
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 模块是否可见
        /// </summary>
        bool Visible { get; set; }
        /// <summary>
        /// 模块提供的服务(暂且不用，需在议)
        /// </summary>
        object ExcuteCommand(object obj);
    }
}
