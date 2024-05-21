using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_NET
{
    public partial class Recharge : Form
    {
        public Recharge()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Connect();
        }
        IPEndPoint IP;
        Socket Client;

        void Connect()
        {
            //IP: Địa chỉ của Server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                Client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Hệ thống đang lỗi, Chúng tôi sẽ khắc phục sớm nhất có thể!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Send()
        {
            int a = int.Parse(lblMoney.Text);
            int b = a % 1000;
            a = a / 1000;
            string c; 
            if(a > 1 && b < 10 )
            {
                c = a + ".00" + b;
            } 
            else if( a > 1 && b > 10 && b < 100 ) 
            {
                c = a + ".0" + b;
            }
            else if(a > 1 && b >=100 )
            {
                c = a + b +"";
            }
            else
            { 
                c = b + ".000"; 
            }
            string text = DateTime.Now + ": Máy " + SharedVariable.tempt + " - " +
                SharedVariable.username + " : Đã nạp " + c + "đ " + "vào tài khoản" ;
            Client.Send(Serialize(text));
        }
        byte[] Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();
            int S = System.Convert.ToInt32(user.balance);

            S = S + SharedVariable.giatien;
            user.balance = S.ToString();

            db.client.SetTaskAsync("user/" + user.username, user);

            MessageBox.Show("Bạn đã nạp tiền thành công");
            Send();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblMoney.Text = SharedVariable.giatien.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.Close();
            this.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
