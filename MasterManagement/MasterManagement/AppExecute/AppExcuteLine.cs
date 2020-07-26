using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Setup.AppExecute
{
    internal class AppExcuteLine
    {
        internal AppExcuteLine()
        { }

        internal AppExcuteItem Builder { get; private set; }

        public AppExcuteLine Use(Func<AppExcuteItem, AppExcuteItem> builder)
        {
            this.Builder = builder?.Invoke(this.Builder);
            return this;
        }
    }


    internal delegate void AppExcuteItem(object appContext);
}
