using System;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Share.UI
{
    public static class ControlExtension
    {
        public static void InvokeAsync(this Control control, Delegate call, params object[] pars)
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