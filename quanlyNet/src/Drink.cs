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
    public partial class Drink : Form
    {
        public Drink()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D001";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D002";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D003";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D004";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D005";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "D006";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }
    }
}
