using MEventBus;
using MLogin;
using System;
using MEventBus.UI;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MUser
{
    public partial class UserPanel : UserControl
    {
        public UserPanel()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Fill;
        }
        
        private void btn_search_Click(object sender, EventArgs e)
        {
            EventBus.Bus.PublishEvent(null, this, new
            {
                controler = "UserBusiness",
                action = "GetName",
                name = "石登明"
            }).SetComplete(this, p =>
            {
                MessageBox.Show(p.TakeResult<string>());
                //this.RefreshListView(p.TakeResult<List<User>>());
            });
        }


        private void RefreshListView(List<User> users)
        {
            this.list_user.Items.Clear();
            if (users == null)
                return;

            ListViewItem item = new ListViewItem();
            foreach (User u in users)
            {
                item = new ListViewItem(u.Name);
                item.SubItems.Add(u.Sex);
                item.SubItems.Add(u.Age.ToString());
                this.list_user.Items.Add(item);
            }
        }
    }
}
