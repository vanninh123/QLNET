using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NET
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + TxtUsername.Text);
            if (res.Body == "null")
            {
                MessageBox.Show("User Không tồn tại , vui lòng nhập đúng username");
                TxtUsername.Text = "";
                return;
            }
            else
            {
                Users user = res.ResultAs<Users>();
                user.password = TxtPassword.Text;
                db.client.SetTaskAsync("user/" + TxtUsername.Text, user);
                MessageBox.Show("Đổi mật khẩu thành công");
                TxtPassword.Text = "";
                TxtUsername.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load_1(object sender, EventArgs e)
        {

        }
    }
}
