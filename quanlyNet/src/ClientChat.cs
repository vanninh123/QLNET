using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_NET
{
    public partial class ClientChat : Form
    {

        public ClientChat()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        IPEndPoint IP;
        Socket Client;

        private void ClientChat_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        // Gửi tin đi
         void button3_Click(object sender, EventArgs e)
        {
            Send();
            Addmessage(SharedVariable.username + ": " + TxtMessage.Text);
        }
        //Kết nối tới Server

        /* Cần:
         * Socket 
         * ID
         */


        void Connect()
        {
            //IP: Địa chỉ của Server
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
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
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        //Đóng kết nối hiện tại



        // Gửi tin
        void Send()
        {
            string text = SharedVariable.username + ": " + TxtMessage.Text;
            if (TxtMessage.Text != string.Empty)
            {
                Client.Send(Serialize(text));
            }
        }

        // Nhận tin
        void Receive()
        {
            try
            {
                while (true)
                {
                    //khai báo mảng byte để nhận dữ liệu dưới mảng byte
                    byte[] data = new byte[1024 * 5000];
                    Client.Receive(data); 
                    //chuyển data từ dạng byte sang dạng string
                    string message = (string)Deserialize(data);
                    Addmessage(message);
                }
            }
            catch
            {
                Close();
            }
        }

        //Add Message vào listview 
        void Addmessage(string message)
        {
            lvsMessage.Items.Add(new ListViewItem() { Text = message });
            TxtMessage.Clear();

        }
        byte[] Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void TxtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.Close();
            this.Dispose();
        }
    }
}
