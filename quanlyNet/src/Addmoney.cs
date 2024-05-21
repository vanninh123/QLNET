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
    public partial class Addmoney : Form
    {
        public Addmoney()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int num1;
            if (!int.TryParse(TxtMoney.Text, out num1) && TxtMoney.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                TxtMoney.Text = "";
            }
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
                int ibalance = System.Convert.ToInt32(user.balance);
                int imoney = System.Convert.ToInt32(TxtMoney.Text);
                ibalance = ibalance + imoney;
                user.balance = ibalance.ToString();
                db.client.SetTaskAsync("user/" + TxtUsername.Text, user);
                MessageBox.Show("Nạp tiền thành công");
                TxtMoney.Text = "";
                TxtUsername.Text = "";
            }
        }

        private void Addmoney_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
