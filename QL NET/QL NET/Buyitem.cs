using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlTypes;

namespace QL_NET
{
    public partial class Buyitem : Form
    {
        public Buyitem()
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
            int a = int.Parse(lblPrice.Text);
            int b = a % 1000;
            a = a / 1000;
            string c;
            if (a > 1 && b < 10)
            {
                c = a + ".00" + b;
            }
            else if (a > 1 && b > 10 && b < 100)
            {
                c = a + ".0" + b;
            }
            else if (a > 1 && b >= 100)
            {
                c = a + b + "";
            }
            else
            {
                c = b + ".000";
            }
            string text = DateTime.Now.ToString() + ": Máy " + SharedVariable.tempt + " - " + 
                SharedVariable.username + " : Đã Order " + lblQuantity.Text + " " + lblName.Text + " - " + c + "đ" ;
            Client.Send(Serialize(text));
        }
        byte[] Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private  async void Buyitem_Load(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + SharedVariable.id);
            Items item = res.ResultAs<Items>();
            lblName.Text = item.name;
            lblPrice.Text = item.price.ToString();
        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.Close();
            this.Dispose();
        }

        private async void pictureBox2_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + SharedVariable.id);
            Items item = res.ResultAs<Items>();


            int iprice = System.Convert.ToInt32(lblPrice.Text);
            int iquantity = System.Convert.ToInt32(lblQuantity.Text);
            if(iquantity == 1)
            {
                iquantity = 1;
            }
            else
            {
                iquantity--;
                iprice = item.price*iquantity;
            }
            lblPrice.Text = iprice.ToString();
            lblQuantity.Text = iquantity.ToString();
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + SharedVariable.id);
            Items item = res.ResultAs<Items>();
            int iquantity = System.Convert.ToInt32(lblQuantity.Text);
            iquantity = iquantity + 1;
            int iprice = item.price* iquantity;
            lblPrice.Text = iprice.ToString();
            lblQuantity.Text = iquantity.ToString();
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + SharedVariable.id);
            Items item = res.ResultAs<Items>();

            FirebaseResponse res1 = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res1.ResultAs<Users>();

            int ibalance = System.Convert.ToInt32(user.balance);
            int iquantity = System.Convert.ToInt32(lblQuantity.Text);
            int iprice = System.Convert.ToInt32(lblPrice.Text);
            if (iquantity > item.quantity)
            {
                MessageBox.Show("Hiện tại item này k đủ số lượng bạn cần , Vui lòng chọn item khác");
                this.Dispose();
                return;
            }
            if (ibalance <= iprice)
            {
                MessageBox.Show("Bạn k đủ tiền để mua , Vui lòng nạp thêm tiền");
                this.Dispose();
                return;
            }
            item.quantity = item.quantity - iquantity;
            ibalance = ibalance - iprice;
            user.balance = ibalance.ToString();
            MessageBox.Show("Mua hàng thành công");
            Send();

            db.client.SetTaskAsync("Items/" + SharedVariable.id, item);
            db.client.SetTaskAsync("user/" + SharedVariable.username, user);
            this.Dispose();
        }
    }
}
