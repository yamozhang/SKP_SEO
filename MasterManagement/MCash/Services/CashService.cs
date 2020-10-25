using MCash.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MCash.Services
{
    internal class CashService
    {
        internal CashService()
        {
            this.ModuleUI = new CashPanel();
            this.ModuleUI.Dock = DockStyle.Fill;
            this.ModuleUI.BorderStyle = BorderStyle.None;

            TreeNode nav = new TreeNode("财务管理");
            nav.Nodes.Add(new TreeNode("余额记录"));
            nav.Nodes.Add(new TreeNode("后台充值"));
            nav.Nodes.Add(new TreeNode("财务管理"));
            this.ModuleMenu = nav;

            this.MenuHandle = (node, path) => {
                this.ModuleUI.TextSearch.Text = path;
            };
        }

        public CashPanel ModuleUI { get; private set; }
        public TreeNode ModuleMenu { get; private set; }

        public Action<object, string> MenuHandle { get; private set; }
    }
}
