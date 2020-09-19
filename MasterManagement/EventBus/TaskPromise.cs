using System;
using System.Collections.Generic;
using System.Text;

namespace MEventBus
{
    /// <summary>
    /// 执行事件的任务承若
    /// </summary>
    public abstract class TaskPromise
    {
        /// <summary>
        /// 表示当前事件是否执行完成
        /// </summary>
        public abstract bool IsComplete { get; }
        /// <summary>
        /// 表示当前事件是否执行失败(如：异常情况）
        /// </summary>
        public abstract bool IsFail { get; }
        /// <summary>
        /// 需要传递的异常
        /// </summary>
        public virtual Exception Exception { get; }
        /// <summary>
        /// 简单的业务消息
        /// </summary>
        public string Message { get; set; }



        /// <summary>
        /// 等待
        /// </summary>
        public abstract void Wait();
        /// <summary>
        /// 任务完成后能够返回的值
        /// </summary>
        public abstract object GetResult();
        /// <summary>
        /// 支持设置回调，任务完成之后，不管成功还是失败
        /// </summary>
        public abstract void SetCompleteInvoke(Action<TaskPromise> callBack);
        /// <summary>
        /// 任务完成后能够返回的值
        /// </summary>
        public virtual T TakeResult<T>()
        {
            object reslt = this.GetResult();
            return reslt == null ? default(T) : (T)reslt;
        }
    }
}
