using System;
using System.Collections.Generic;

namespace MFrameworke.Base.AppExecute
{
    //表示一个程序执行流程，有一个个程序执行节点组成
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
                //default node
                AppNode next = context => { };
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
        public void Execute()
        {
            this.Builder?.Invoke(null);
        }
    }

    //程序执行节点
    public delegate void AppNode(object appContext);
}
