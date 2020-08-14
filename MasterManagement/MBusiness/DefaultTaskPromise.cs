using MEventBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MBusiness
{
    /// <summary>
    /// 封装一个Task
    /// </summary>
    internal class DefaultTaskPromise : TaskPromise
    {
        public DefaultTaskPromise(Task task)
        {
            this._task = task;
        }

        protected Task _task;



        public override bool IsComplete => this._task == null ? false : this._task.IsCompleted;
        public override bool IsFail => this._task == null ? false : this._task.IsFaulted;
        public override Exception Exception => this._task?.Exception;


        public override object GetResult()
        {
            return null;
        }
        public override void SetCompleteInvoke(Action<TaskPromise> callBack)
        {
            if (callBack == null)
                return;

            Action<Action<TaskPromise>> call = this.BuildTaskDispose(callBack);
            if (this.IsComplete)
                call?.Invoke(callBack);
            this._task?.ContinueWith(t => call?.Invoke(callBack));
        }



        //生成一个包含线程资源释放的委托
        private Action<Action<TaskPromise>> BuildTaskDispose(Action<TaskPromise> callBack)
        {
            return new Action<Action<TaskPromise>>(this.TaskDisposeWapper);
        }
        private void TaskDisposeWapper(Action<TaskPromise> callBack)
        {
            callBack?.Invoke(this);
            this._task?.Dispose();
        }
    }
}
