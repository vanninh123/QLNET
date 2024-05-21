using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QL_NET
{
    
    public partial class Login : Form
    {
        int currentImageIndex = 0;
        string[] imagePaths = {
                "D:/Information Technology/QLNET/Yasou.jpg",
                "D:/Information Technology/QLNET/Aphe.jpg",
                "D:/Information Technology/QLNET/Ashe.jpg",
                "D:/Information Technology/QLNET/Swain.jpg",
                "D:/Information Technology/QLNET/Talon.jpg",
                "D:/Information Technology/QLNET/Nami.jpg",
                "D:/Information Technology/QLNET/Ekko.jpg",
                "D:/Information Technology/QLNET/Ez.jpg",
            };
        string currentImagePath = "D:/Information Technology/QLNET/Yasou.jpg";

        public Login()
        {
            InitializeComponent();
        }
        void connect()
        {
            if(Application.OpenForms.Count == 1)
            {
                timer1.Start();
            }    
        }

        void disconnect()
        {
            if(Application.OpenForms.Count > 1)
            {
                timer1.Stop();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            connect();
            LblUsername.Text = null; LblPassword.Text = null;
            
            if (!TxtPassword.UseSystemPasswordChar)
            {
                // Nếu mật khẩu đang được ẩn, hiển thị mật khẩu
                TxtPassword.UseSystemPasswordChar = true;
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {   

            FirebaseResponse res = await db.client.GetTaskAsync("user/" + TxtUsername.Text);

            if (res.Body == "null")
            {
                LblUsername.Text = "Invalid Username";
                timer2.Start();
                return;
            }
            else
            {
                Users user = res.ResultAs<Users>();
                SharedVariable.username = user.username;
                int S = System.Convert.ToInt32(user.balance);
                if (user.password == TxtPassword.Text)
                {   
                    if(S <= 0)
                    {
                        MessageBox.Show("Tài khoản của bạn hiện đã hết tiền , vui lòng đến quầy để nạp thêm tiền");
                    }
                    else if(user.isavailable == false)
                    {
                        MessageBox.Show("Tài khoản của bạn Đang được sử dụng ở nơi khác");
                    }
                    else
                    {
                        user.isavailable = false;
                        db.client.SetTaskAsync("user/" + user.username, user);
                        Main m = new Main();
                        m.ShowDialog();
                        timer1.Stop();
                    }

                }
                else
                {
                    LblPassword.Text = "Invalid Password";
                }
            };
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
                currentImageIndex = 0;

            currentImagePath = imagePaths[currentImageIndex];
            pictureBox1.ImageLocation = currentImagePath;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LblUsername.Text = "";
            LblPassword.Text = "";
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            label4.Hide();
        }
    }
}
