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
    public partial class Cigarette : Form
    {
        public Cigarette()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Cigarette_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C001";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C002";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C003";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C004";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C005";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C006";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C007";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "C008";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }
    }
}
