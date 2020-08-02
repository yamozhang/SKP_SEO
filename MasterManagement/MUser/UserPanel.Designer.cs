namespace MUser
{
    partial class UserPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.list_user = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.sex = new System.Windows.Forms.ColumnHeader();
            this.age = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "快速查询：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 23);
            this.textBox1.TabIndex = 1;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(520, 26);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "查询";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // list_user
            // 
            this.list_user.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.list_user.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.sex,
            this.age});
            this.list_user.HideSelection = false;
            this.list_user.Location = new System.Drawing.Point(3, 70);
            this.list_user.Name = "list_user";
            this.list_user.Size = new System.Drawing.Size(782, 342);
            this.list_user.TabIndex = 3;
            this.list_user.UseCompatibleStateImageBehavior = false;
            this.list_user.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Name = "name";
            this.name.Text = "姓名";
            // 
            // sex
            // 
            this.sex.Name = "sex";
            this.sex.Text = "性别";
            // 
            // age
            // 
            this.age.Name = "age";
            this.age.Text = "年龄";
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 416);
            this.Controls.Add(this.list_user);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "UserPanel";
            this.Text = "UserPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ListView list_user;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader sex;
        private System.Windows.Forms.ColumnHeader age;
    }
}