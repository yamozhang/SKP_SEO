using System;
using System.Threading.Tasks;
using MEventBus;

namespace MBusiness.Controls
{
    static class BaseControlsExtend
    {

        internal static TaskPromise CreateTaskPromise(this BaseControls controler, bool complete = false, bool fail = false, Exception exception = null, object result = null)
        {
            return new CustemoTaskPromise()
            {
                Complete = complete,
                Fail = fail,
                Error = exception,
                Result = result
            };
        }
        internal static TaskPromise CreateTaskPromise(this BaseControls controler, Task task)
        {
            return new DefaultTaskPromise(task);
        }
        internal static TaskPromise CreateTaskPromise<T>(this BaseControls controler, Task<T> task)
        {
            return new DefaultResultTaskPromise<T>(task);
        }
        internal static TaskPromise CreateTaskPromise(this BaseControls controler, Action action)
        {
            return new DefaultTaskPromise(Task.Factory.StartNew(action));
        }
        internal static TaskPromise CreateTaskPromise<T>(this BaseControls controler, Func<T> action)
        {
            return new DefaultResultTaskPromise<T>(Task.Factory.StartNew<T>(action));
        }
    }
}
