namespace MainApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.split_Master = new System.Windows.Forms.SplitContainer();
            this.tree_nav = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.split_Master)).BeginInit();
            this.split_Master.Panel1.SuspendLayout();
            this.split_Master.SuspendLayout();
            this.SuspendLayout();
            // 
            // split_Master
            // 
            this.split_Master.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.split_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Master.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split_Master.Location = new System.Drawing.Point(0, 0);
            this.split_Master.Name = "split_Master";
            // 
            // split_Master.Panel1
            // 
            this.split_Master.Panel1.Controls.Add(this.tree_nav);
            this.split_Master.Panel1MinSize = 200;
            // 
            // split_Master.Panel2
            // 
            this.split_Master.Panel2.BackColor = System.Drawing.Color.White;
            this.split_Master.Size = new System.Drawing.Size(993, 607);
            this.split_Master.SplitterDistance = 200;
            this.split_Master.SplitterWidth = 1;
            this.split_Master.TabIndex = 0;
            this.split_Master.TabStop = false;
            this.split_Master.Text = "splitContainer1";
            // 
            // tree_nav
            // 
            this.tree_nav.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree_nav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_nav.HideSelection = false;
            this.tree_nav.HotTracking = true;
            this.tree_nav.Indent = 20;
            this.tree_nav.LineColor = System.Drawing.Color.White;
            this.tree_nav.Location = new System.Drawing.Point(0, 0);
            this.tree_nav.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tree_nav.Name = "tree_nav";
            this.tree_nav.PathSeparator = "/";
            this.tree_nav.ShowLines = false;
            this.tree_nav.ShowNodeToolTips = true;
            this.tree_nav.ShowPlusMinus = false;
            this.tree_nav.ShowRootLines = false;
            this.tree_nav.Size = new System.Drawing.Size(198, 605);
            this.tree_nav.TabIndex = 0;
            this.tree_nav.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_nav_AfterSelect);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 607);
            this.Controls.Add(this.split_Master);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "升快排";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.split_Master.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Master)).EndInit();
            this.split_Master.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_Master;
        private System.Windows.Forms.TreeView tree_nav;
    }
}

