using System;
using System.Windows.Forms;
using MFrameworke.Base.AppModule;
using System.Collections.Generic;
using System.Text;

namespace MUser
{
    public class CashModuleUI : IModule
    {
        public string Name { get; set; } = "CashModule";
        public bool Visible { get; set; } = false;

        public void Dispose()
        {
           
        }

        public object ExcuteCommand(object obj)
        {
            return null;
        }

        public object[] LoadUIComponent(object[] a)
        {
            TreeNode nav = new TreeNode("财务管理");
            nav.Nodes.Add(new TreeNode("充值记录"));
            nav.Nodes.Add(new TreeNode("后台记录"));
            nav.Nodes.Add(new TreeNode("后台扣款"));

            Label tip = new Label();
            tip.Text = "这是财务管理界面";
            tip.AutoSize = true;

            Panel p = new Panel();
            p.Dock = DockStyle.Fill;
            p.Controls.Add(tip);

            return new object[] { 
                nav, 
                p,
                new Action<object,string>((node,path) => { 
                    //用于响应节点选择之后的事见
                    tip.Text = "财务管理：" + ((TreeNode)node).Text;
                })
            };
        }
    }
}
