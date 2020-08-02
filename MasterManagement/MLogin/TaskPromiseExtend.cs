using System;
using MEventBus;
using System.Windows.Forms;
using MUIFW;

namespace MLogin
{
    internal static class TaskPromiseExtend
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
                control.BeginUI(callback, p);
            });
        }
    }
}
