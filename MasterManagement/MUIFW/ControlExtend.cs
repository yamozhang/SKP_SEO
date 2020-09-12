using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MUIFW
{
    public static class ControlExtend
    {
        public static void BeginUI(this Control control, Delegate call, params object[] pars)
        {
            if (control == null)
                throw new NullReferenceException(nameof(control));

            if (control.InvokeRequired)
            {
                control.BeginInvoke(call, pars);
            }
            else
            {
                control.Invoke(call, pars);
            }
        }
    }
}
