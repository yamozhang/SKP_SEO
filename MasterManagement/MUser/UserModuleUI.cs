using System;
using System.Windows.Forms;
using MFrameworke.Base.AppModule;

namespace MUser
{
    public class UserModuleUI : IModule
    {
        public string Name { get; set; } = "UserModule";
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
            TreeNode nav = new TreeNode("用户管理");
            nav.Nodes.Add(new TreeNode("普通用户"));
            nav.Nodes.Add(new TreeNode("大型用户"));
            nav.Nodes.Add(new TreeNode("潜在用户"));

            Label tip = new Label();
            tip.Text = "这是用户管理界面";
            tip.AutoSize = true;

            return new object[] {
                nav,
                new UserPanel()
            };
        }
    }
}
