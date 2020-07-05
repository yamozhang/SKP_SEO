using System;
using MFrameworke.Base.AppModule;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace MainApp
{
    public partial class MainForm : Form, IModuleVisualable
    {
        public MainForm()
        {
            InitializeComponent();

            this.modules = new List<ModuleInfo>();
            this.curModule = null;
        }


        private List<ModuleInfo> modules;//加载过的模块
        private ModuleInfo? curModule;    //当前呈现的模块


        #region privat method
        //创建用于管理模块的容器
        private Panel CreateModuleContiner(IModule module)
        {
            return new Panel()
            {
                Name = "ModulePanel." + module.Name,
                Visible = true,
            };
        }
        //记录模块信息
        private ModuleInfo RegsiterModule(Panel moduleContiner, object[] components)
        {
            ModuleInfo module = new ModuleInfo();
            foreach (object componet in components)
            {
                if (componet is TreeNode)
                {
                    module.ModuleNode = (TreeNode)componet;
                }
                else if (componet is Control)
                {
                    module.ModulePanel = moduleContiner;
                    moduleContiner.Controls.Add((Control)componet);
                }
                else if (componet is Action<object, string>)
                {
                    module.Handler = (Action<object, string>)componet;
                }
            }
            return module;
        }
        //绑定模块UI界面
        private void LoadModuleUI(ModuleInfo module)
        {
            //如果没有任何模块加载过，则将module的ui加载只界面
            if (this.curModule == null)
            {
                if (module.ModulePanel != null)
                    this.split_Master.Panel2.Controls.Add(module.ModulePanel);
                this.curModule = module;
            }
            //如果界面已经在显示一个模块了，只需要加载菜单即可
            if (module.ModuleNode != null)
                this.tree_nav.Nodes.Add(module.ModuleNode);
        }
        private void UnInstallUI(ModuleInfo module)
        {
            if (module.ModuleNode != null)
                this.tree_nav.Nodes.Remove(module.ModuleNode);

            if (module.ModulePanel != null)
                this.split_Master.Panel2.Controls.Remove(module.ModulePanel);
        }
        //切换模块之间的页面
        private void SwitchModuleUI(ModuleInfo module)
        {
            if (module == null || this.curModule == null || module == this.curModule)
                return;

            this.split_Master.BeginInit();
            this.split_Master.Panel2.Controls.Remove(this.curModule.Value.ModulePanel);
            this.split_Master.Panel2.Controls.Add(module.ModulePanel);
            this.split_Master.EndInit();
        }
        #endregion


        #region event
        //树节点选择时
        private void tree_nav_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //当前节点父节点
            TreeNode root = e.Node;
            while (root.Parent != null)
                root = root.Parent;

            
            //找到对应的节点，进行事件处理
            ModuleInfo module = this.modules.FirstOrDefault(m => object.ReferenceEquals(root, m.ModuleNode));

            this.SwitchModuleUI(module);
            this.curModule = module;
            module.Handler?.Invoke(e.Node, e.Node.FullPath);
        }
        #endregion



        //承载模块UI
        public void VisualModule(IModule module)
        {
            if (module == null)
                return;

            //用一个panel将module包装
            Panel moduleContiner = this.CreateModuleContiner(module);

            object[] components = module.LoadUIComponent(null);
            if (components == null && components.Length < 1)
                return;

            ModuleInfo moduleInfo = this.RegsiterModule(moduleContiner, components);
            moduleInfo.Module = module;
            this.LoadModuleUI(moduleInfo);
            this.modules.Add(moduleInfo);
        }
        //卸载模块UI
        public void UnInstallModule(IModule module)
        {

        }






        /// <summary>
        /// 模块的信息
        /// </summary>
        private struct ModuleInfo
        {
            internal IModule Module;
            internal TreeNode ModuleNode;
            internal Panel ModulePanel;
            internal Action<object, string> Handler;


            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }


            public static bool operator ==(ModuleInfo a, ModuleInfo b)
            {
                if (a == null && b == null)
                    return true;
                else if (a == null || b == null)
                    return false;

                return a.Module == b.Module;
            }
            public static bool operator !=(ModuleInfo a, ModuleInfo b)
            {
                if (a == null && b == null)
                    return false;
                else if (a == null || b == null)
                    return true;

                return a.Module != b.Module; ;
            }
        }
    }
}
