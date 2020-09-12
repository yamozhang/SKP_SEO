using System;
using System.Threading.Tasks;
using MEventBus;

namespace MBusiness
{
    /// <summary>
    /// 封装一个Taks<T>
    /// </summary>
    class DefaultResultTaskPromise<T> : DefaultTaskPromise
    {
        public DefaultResultTaskPromise(Task<T> task) : base(task)
        {}

        public override bool IsComplete => this._task == null ? false : this._task.IsCompleted;
        public override bool IsFail => this._task == null ? false : this._task.IsFaulted;
        public override Exception Exception => this._task?.Exception;


        public override object GetResult()
        {
            if (this._task == null)
                return null;
            return ((Task<T>)this._task).Result;
        }
    }
}
