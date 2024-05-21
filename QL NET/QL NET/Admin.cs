using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NET
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            connect();
        }
        IPEndPoint IP;
        Socket Server;
        private void connect()
        {
            //IP: Địa chỉ của Server

            IP = new IPEndPoint(IPAddress.Any, 12000);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Server.Bind(IP);
            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        Server.Listen(1000);
                        Socket client = Server.Accept();
                        SharedVariable.Socket = client;

                        ServerChat ser = new ServerChat();
                        ser.Show();
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 12000);
                    Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }

            });
            listen.IsBackground = true;
            listen.Start();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Adduser newuser = new Adduser();
            newuser.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adduser newuser1 = new Adduser();
            newuser1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Addmoney adm = new Addmoney();
            adm.Show();

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ChangePassword password = new ChangePassword();
            password.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerChat chat = new ServerChat();
            chat.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Additem additem = new Additem();
            additem.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

