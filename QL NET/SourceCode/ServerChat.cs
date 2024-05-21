using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Runtime.CompilerServices;

namespace QL_NET
{
    public partial class ServerChat : Form
    {
        public ServerChat()
        {
            InitializeComponent();
        }


        private void Chat_Load(object sender, EventArgs e)
        {
            Thread Receive = new Thread(receive);
            Receive.IsBackground = true;
            Receive.Start(SharedVariable.Socket);
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
           send(SharedVariable.Socket);
           TxtMessage.Clear();
        }

        // Gửi tin
        private void send(Socket client)
        {
            if(TxtMessage.Text != string.Empty) 
            {
                client.Send(Serialize(TxtMessage.Text));
            }
        }

        void Addmessage(string message)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = message });
            TxtMessage.Clear();

        }
        private void receive(object obj) 
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 12000];
                    client.Receive(data);
                    string message = Deserialize(data).ToString();
                    Addmessage(message);
                }    
            }
            catch 
            {
                client.Close();
            }
        }

        private byte[] Serialize(object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }


    }
}
