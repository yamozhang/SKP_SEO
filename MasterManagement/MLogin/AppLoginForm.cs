using MUIFW;
using System;
using MEventBus;
using System.Windows.Forms;

namespace MLogin
{
    public partial class AppLoginForm : Form
    {
        public AppLoginForm()
        {
            InitializeComponent();
        }

        public bool IsLogin { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TaskPromise task = EventBus.Bus.PublishEvent(null, this, new
            {
                controler = "UserLogin",
                action = "Login",
                userName = this.txt_name.Text,
                password = this.txt_password.Text
            });

            task.SetComplete(this, (a) =>
            {
                this.Cursor = Cursors.Default;

                this.IsLogin = a.TakeResult<bool>();
                if (this.IsLogin)
                    this.Close();
                else
                    MessageBox.Show(this, "登录失败！", "提示：");
            });
        }
    }
}
