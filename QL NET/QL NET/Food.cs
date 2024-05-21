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
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }

        private void Food_Load(object sender, EventArgs e)
        {
        }

        private void pcb1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F001";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F002";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F003";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F004";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F005";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SharedVariable.id = "F006";
            Buyitem buyitem = new Buyitem();
            buyitem.Show();
        }
    }
}
