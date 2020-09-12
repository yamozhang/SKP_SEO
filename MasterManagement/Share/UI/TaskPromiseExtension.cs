using System;
using MEventBus;
using System.Windows.Forms;

namespace Share.UI
{
    internal static class TaskPromiseExtend1
    {
        public static void SetComplete(this TaskPromise promise, Control control, Action<TaskPromise> callback)
        {
            if (promise == null)
                throw new NullReferenceException();


            if (control == null)
            {
                promise.SetCompleteInvoke(callback);
                return;
            }

            promise.SetCompleteInvoke(p => {
                control.InvokeAsync(callback, p);
            });
        }
    }
}
