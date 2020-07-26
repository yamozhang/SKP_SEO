namespace MLogin
{
    partial class AppLoginForm
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
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lbl_emploNum = new System.Windows.Forms.Label();
            this.txt_emploNum = new System.Windows.Forms.TextBox();
            this.lbl_cellNum = new System.Windows.Forms.Label();
            this.txt_cellNum = new System.Windows.Forms.TextBox();
            this.lbl_validate = new System.Windows.Forms.Label();
            this.txt_validate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_name.Location = new System.Drawing.Point(84, 40);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(44, 17);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "账号：";
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Location = new System.Drawing.Point(133, 37);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(243, 23);
            this.txt_name.TabIndex = 1;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_password.Location = new System.Drawing.Point(84, 85);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(44, 17);
            this.lbl_password.TabIndex = 0;
            this.lbl_password.Text = "密码：";
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_password.Location = new System.Drawing.Point(133, 82);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(243, 23);
            this.txt_password.TabIndex = 1;
            // 
            // lbl_emploNum
            // 
            this.lbl_emploNum.AutoSize = true;
            this.lbl_emploNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_emploNum.Location = new System.Drawing.Point(84, 133);
            this.lbl_emploNum.Name = "lbl_emploNum";
            this.lbl_emploNum.Size = new System.Drawing.Size(44, 17);
            this.lbl_emploNum.TabIndex = 0;
            this.lbl_emploNum.Text = "工号：";
            // 
            // txt_emploNum
            // 
            this.txt_emploNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_emploNum.Location = new System.Drawing.Point(133, 130);
            this.txt_emploNum.Name = "txt_emploNum";
            this.txt_emploNum.Size = new System.Drawing.Size(243, 23);
            this.txt_emploNum.TabIndex = 1;
            // 
            // lbl_cellNum
            // 
            this.lbl_cellNum.AutoSize = true;
            this.lbl_cellNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_cellNum.Location = new System.Drawing.Point(72, 181);
            this.lbl_cellNum.Name = "lbl_cellNum";
            this.lbl_cellNum.Size = new System.Drawing.Size(56, 17);
            this.lbl_cellNum.TabIndex = 0;
            this.lbl_cellNum.Text = "手机号：";
            // 
            // txt_cellNum
            // 
            this.txt_cellNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cellNum.Location = new System.Drawing.Point(133, 178);
            this.txt_cellNum.Name = "txt_cellNum";
            this.txt_cellNum.Size = new System.Drawing.Size(243, 23);
            this.txt_cellNum.TabIndex = 1;
            // 
            // lbl_validate
            // 
            this.lbl_validate.AutoSize = true;
            this.lbl_validate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_validate.Location = new System.Drawing.Point(72, 232);
            this.lbl_validate.Name = "lbl_validate";
            this.lbl_validate.Size = new System.Drawing.Size(56, 17);
            this.lbl_validate.TabIndex = 0;
            this.lbl_validate.Text = "验证码：";
            // 
            // txt_validate
            // 
            this.txt_validate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_validate.Location = new System.Drawing.Point(133, 229);
            this.txt_validate.Name = "txt_validate";
            this.txt_validate.Size = new System.Drawing.Size(243, 23);
            this.txt_validate.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(133, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_version
            // 
            this.lbl_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_version.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_version.Location = new System.Drawing.Point(411, 469);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(32, 16);
            this.lbl_version.TabIndex = 3;
            this.lbl_version.Text = "V1.0";
            // 
            // AppLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 494);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_validate);
            this.Controls.Add(this.lbl_validate);
            this.Controls.Add(this.txt_cellNum);
            this.Controls.Add(this.lbl_cellNum);
            this.Controls.Add(this.txt_emploNum);
            this.Controls.Add(this.lbl_emploNum);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_name);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AppLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升快排后台管理系统--非工作人员禁止使用，严禁泄露";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lbl_emploNum;
        private System.Windows.Forms.TextBox txt_emploNum;
        private System.Windows.Forms.Label lbl_cellNum;
        private System.Windows.Forms.TextBox txt_cellNum;
        private System.Windows.Forms.Label lbl_validate;
        private System.Windows.Forms.TextBox txt_validate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_version;
    }
}

