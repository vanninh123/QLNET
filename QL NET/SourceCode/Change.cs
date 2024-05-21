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
    public partial class Change : Form
    {
        public Change()
        {
            InitializeComponent();
                // ẩn mật khẩu
            TxtPassword.UseSystemPasswordChar = true;
            TxtNewPassword.UseSystemPasswordChar = true;
            TxtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (TxtPassword.UseSystemPasswordChar)
            {
                // Nếu mật khẩu đang được ẩn, hiển thị mật khẩu
                TxtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu mật khẩu đang được hiển thị, ẩn mật khẩu
                TxtPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (TxtNewPassword.UseSystemPasswordChar)
            {
                // Nếu mật khẩu đang được ẩn, hiển thị mật khẩu
                TxtNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu mật khẩu đang được hiển thị, ẩn mật khẩu
                TxtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (TxtConfirmPassword.UseSystemPasswordChar)
            {
                // Nếu mật khẩu đang được ẩn, hiển thị mật khẩu
                TxtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Nếu mật khẩu đang được hiển thị, ẩn mật khẩu
                TxtConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();

            if (TxtPassword.Text == user.password && TxtNewPassword.Text == TxtConfirmPassword.Text)
            {
                user.password = TxtNewPassword.Text;
                MessageBox.Show("Đổi mật khẩu thành công");
                db.client.SetTaskAsync("user/" + user.username, user);
                TxtPassword.Text = "";
                TxtNewPassword.Text = "";
                TxtConfirmPassword.Text = "";
                this.Close();
                return;
            }
            else if (TxtPassword.Text != user.password)
            {
                lblPassword.Text = "Invalid Password";
                TxtPassword.Text = "";
                return;
            }    
            else if(TxtNewPassword.Text != TxtConfirmPassword.Text)
            {
                lblConfirmPassword.Text = "Can't Confirm Password";
                TxtConfirmPassword.Text = "";
            }    

        }
        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
