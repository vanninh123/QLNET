using FireSharp.Response;
using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Windows.Forms;
namespace QL_NET
{
    public partial class Main : Form
    {
        private Form currentFormChild;
        private void OpenchildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        int tempM = 0;
        int tempHours = 0;
        int tempMinutes = 0;
        public Main()
        {

            InitializeComponent();
            connect();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Recharge1 F4 = new Recharge1();
            F4.Show();
        }

        void connect()
        {
            timer1.Start();
            timer2.Start();
        }

        async void disconnect()
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();
            if (Application.OpenForms.Count < 2)
            {
                user.isavailable = true;
                resetComputer();
                db.client.SetTaskAsync("user/" + SharedVariable.username, user);
                timer1.Stop();
                timer2.Stop();
            }

        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            int i = 1;
            while (true)
            {
                FirebaseResponse res1 = await db.client.GetTaskAsync("Computers/" + i);
                if (res1.Body == "null")
                {
                    i--;
                    break;
                }
                else i++;
            }
            while (true)
            {
                Random rd = new Random();
                SharedVariable.tempt = rd.Next(1, i);
                FirebaseResponse res2 = await db.client.GetTaskAsync("Computers/" + SharedVariable.tempt);
                Computers computer0 = res2.ResultAs<Computers>();

                if (computer0.Isavailable == false)
                { continue; }
                else { break; }

            }


            Computers computer = new Computers()
            {
                code = SharedVariable.tempt,
                username = SharedVariable.username,
                timestart = DateTime.Now.ToString(),
                Isavailable = false,
            };
            db.client.SetTaskAsync("Computers/" + SharedVariable.tempt, computer);




            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();
            lblName.Text = user.name;
            lblUsername.Text = user.username;
            //lblTotalM.Text = user.balance.ToString();
            int S = System.Convert.ToInt32(user.balance);

        }



        private void Button4_Click_1(object sender, EventArgs e)
        {
            OpenchildForm(new Food());

        }


        private void takeValues1(int a, int b)
        {
            if (a >= 10 && b >= 10)
            {
                lblTotalT.Text = a + ":" + b;
            }
            else if (a < 10 && b >= 10)
            {
                lblTotalT.Text = "0" + a + ":" + b;
            }
            else if (a >= 10 && b < 10)
            {
                lblTotalT.Text = a + ":0" + b;
            }
            else
            {
                lblTotalT.Text = "0" + a + ":0" + b;
            }
        }



        private async void takeValues(int a, int b)
        {
            if (a >= 10 && b >= 10)
            {
                lblTime.Text = a + ":" + b;
            }
            else if (a < 10 && b >= 10)
            {
                lblTime.Text = "0" + a + ":" + b;
            }
            else if (a > 10 && b < 10)
            {
                lblTime.Text = a + ":0" + b;
            }
            else
            {
                lblTime.Text = "0" + a + ":0" + b;
            }
        }


        private async void resetComputer()
        {
            FirebaseResponse res3 = await db.client.GetTaskAsync("Computers/" + SharedVariable.tempt);
            Computers computer2 = new Computers();
            computer2.code = SharedVariable.tempt;
            computer2.Isavailable = true;
            computer2.username = "xxxxxxx";
            computer2.timestart = "00:00";
            db.client.SetTaskAsync("Computers/" + SharedVariable.tempt, computer2);


        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();
            int S = System.Convert.ToInt32(user.balance);
            if (S <= 0)
            {
                user.balance = S.ToString();
                db.client.SetTaskAsync("user/" + user.username, user);
                disconnect();
                this.Close();
                return;
            }
            tempM = tempM + 100;
            tempMinutes = tempMinutes + 1;
            if (tempMinutes == 60)
            {
                tempHours = tempHours + 1;
                tempMinutes = 0;
            }
            takeValues(tempHours, tempMinutes);
            if (SharedVariable.minutes == 0)
            {
                SharedVariable.hours = SharedVariable.hours - 1;
                SharedVariable.minutes = 60;
            }
            SharedVariable.minutes = SharedVariable.minutes - 1;

            S = S - 100;
            if (S <= 0)
            {
                S = 0;
            }
            user.balance = S.ToString();
            db.client.SetTaskAsync("user/" + user.username, user);
        }

        private async void timer2_Tick(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("user/" + SharedVariable.username);
            Users user = res.ResultAs<Users>();
            int S = System.Convert.ToInt32(user.balance);
            lblMoney.Text = tempM.ToString();
            lblTotalM.Text = S.ToString();
            SharedVariable.hours = S / 6000;
            SharedVariable.minutes = S % 6000;
            SharedVariable.minutes = SharedVariable.minutes / 100;
            takeValues1(SharedVariable.hours, SharedVariable.minutes);
            if (S <= 0 || Application.OpenForms.Count < 2)
            {
                disconnect();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharedVariable.giatien = 20000;
            Recharge F3 = new Recharge();
            F3.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recharge F3 = new Recharge();
            F3.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recharge F3 = new Recharge();
            F3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recharge F3 = new Recharge();
            F3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Recharge F3 = new Recharge();
            F3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Change F5 = new Change();
            F5.Show();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SharedVariable.giatien = 200000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            ClientChat chat2 = new ClientChat();
            chat2.Show();

        }

        private async void button10_Click(object sender, EventArgs e)
        {
            disconnect();
            this.Dispose();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SharedVariable.giatien = 20000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SharedVariable.giatien = 30000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SharedVariable.giatien = 50000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SharedVariable.giatien = 100000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SharedVariable.giatien = 500000;
            Recharge r1 = new Recharge();
            r1.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }



        private void button19_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenchildForm(new Drink());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Cigarette());
        }



        private void lblTotalM_Click(object sender, EventArgs e)
        {

        }


    }
}
