using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.IsLogin = true;
            this.Close();
        }
    }
}
