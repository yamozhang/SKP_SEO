using System;
using System.Collections.Generic;

namespace MFrameworke.Base.AppExecute
{
    public class AppLine
    {
        public AppLine()
        {
            this.apps = new LinkedList<Func<AppNode, AppNode>>();
        }


        private LinkedList<Func<AppNode, AppNode>> apps;

        public AppNode Builder {
            get
            {
                AppNode next = null;
                LinkedListNode<Func<AppNode,AppNode>> pre = apps.Last;
                while (pre != null)
                {
                    next = pre.Value.Invoke(next);
                    pre = pre.Previous;
                }
                return next;
            }
        }


        public AppLine Use(Func<AppNode, AppNode> builder)
        {
            this.apps.AddLast(builder);
            return this;
        }
    }


    public delegate void AppNode(object appContext);
}
