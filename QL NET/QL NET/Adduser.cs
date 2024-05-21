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
    public partial class Adduser : Form
    {
        public Adduser()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int num1;
            if (!int.TryParse(TxtBalance.Text, out num1) && TxtBalance.Text == "" && TxtBalance.Text == "-" )
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                TxtBalance.Text = "";
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num1;
            if (!int.TryParse(TxtPhoneNumber.Text, out num1) && TxtPhoneNumber.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                TxtPhoneNumber.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // validate 
            // Todo hash password
            if (TxtBalance.Text == "")
            {
                MessageBox.Show("Bạn phải nạp tiền vào tài khoản");
                return;
            }
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + TxtUsername.Text);

            if (res.Body != "null")
            {
                MessageBox.Show("User Name đã có người sử dụng");
                TxtUsername.Text = "";
                return;
            }

            Users user = new Users
            {
                name = TxtName.Text,
                username = TxtUsername.Text,
                password = TxtPassword.Text,
                phoneNumber = TxtPhoneNumber.Text,
                balance = TxtBalance.Text
            };
            db.client.SetTaskAsync("user/" + TxtUsername.Text, user);
            MessageBox.Show("Tạo TK thành công");
            TxtName.Text = "";
            TxtUsername.Text = "";
            TxtPassword.Text = "";
            TxtPhoneNumber.Text = "";
            TxtBalance.Text = "";
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtName_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void Newuser_Load(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
