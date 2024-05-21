using QL_NET.Entity;
using QL_NET.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using Image = System.Drawing.Image;
using FireSharp.Response;
using System.CodeDom.Compiler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QL_NET
{
    public partial class Additem : Form
    {
        public Additem()
        {
            InitializeComponent();
        }
        private async void Additem_Load(object sender, EventArgs e)
        {
            int i = 1;
            int a = 0;
            int b = 0;
            int c = 0;
            while (true)
            {
                string temp = Checki(i);
                FirebaseResponse res1 = await db.client.GetTaskAsync("Items/" + "F" + temp);
                FirebaseResponse res2 = await db.client.GetTaskAsync("Items/" + "D" + temp);
                FirebaseResponse res3 = await db.client.GetTaskAsync("Items/" + "C" + temp);
                if (res1.Body == "null" && res1.Body == "null" && res3.Body == "null") { break; }
                if (res1.Body != "null") { a++; }
                if (res2.Body != "null") { b++; }
                if (res3.Body != "null") { c++; }
                i++;
            }
            for (int j = 1; j <= a; j++)
            {
                additem123("F" + Checki(j));
            }
            for (int j = 1; j <= b; j++)
            {
                additem123("D" + Checki(j));
            }
            for (int j = 1; j <= c; j++)
            {
                additem123("C" + Checki(j));
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + TxtId.Text);

            if (res.Body != "null")
            {
                MessageBox.Show("Id đã được sử dụng cho item khác");
                TxtId.Text = "";
                return;
            }
            int quantity1 = System.Convert.ToInt32(TxtQuantity.Text);
            int price1 = System.Convert.ToInt32(TxtPrice.Text);
            Items item = new Items
            {
                id = TxtId.Text,
                name = TxtName.Text,
                type = TxtType.Text,
                quantity = quantity1,
                url = TxtUrl.Text,
                price = price1,
            };

            db.client.SetTaskAsync("Items/" + TxtId.Text, item);
            MessageBox.Show("Add Item thành công");
            additem123(item.id);
            TxtId.Text = "";
            TxtName.Text = "";
            TxtType.Text = "";
            TxtQuantity.Text = "";
            TxtUrl.Text = "";
            TxtPrice.Text = "";
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if(lsvItems.SelectedItems.Count > 0)
            {
                lsvItems.Items.RemoveAt(lsvItems.SelectedItems[0].Index);
            }
            FirebaseResponse res1 = await db.client.DeleteTaskAsync("Items/" + TxtId.Text);
            MessageBox.Show("Xóa thành công item");
            TxtId.Text = "";
            TxtName.Text = "";
            TxtType.Text = "";
            TxtQuantity.Text = "";
            TxtUrl.Text = "";
            TxtPrice.Text = "";
        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            int num1;
            if (!int.TryParse(TxtQuantity.Text, out num1) && TxtQuantity.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                TxtQuantity.Text = "";
            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {
            int num1;
            if (!int.TryParse(TxtPrice.Text, out num1) && TxtPrice.Text !="" )
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!");
                TxtPrice.Text = "";
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lsvitems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(lsvItems.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lsvItems.SelectedItems[0];
                TxtId.Text = lvi.SubItems[0].Text;
                TxtName.Text = lvi.SubItems[1].Text;
                TxtType.Text = lvi.SubItems[2].Text;
                TxtQuantity.Text = lvi.SubItems[3].Text;
                TxtUrl.Text = lvi.SubItems[4].Text;
                TxtPrice.Text = lvi.SubItems[5].Text;
                TxtId.Enabled = false;
                btnSubmit.Enabled = false;
                btnCancel.Enabled = true;
                btnEdit.Enabled = true;
            }
        }

        private  async void additem123(string id)
        {
            FirebaseResponse res1 = await db.client.GetTaskAsync("Items/" + id);
            Items item = res1.ResultAs<Items>();
            ListViewItem listitem = new ListViewItem(item.id);
            listitem.SubItems.Add(item.name);
            listitem.SubItems.Add(item.type);
            listitem.SubItems.Add(item.quantity.ToString());
            listitem.SubItems.Add(item.url);
            listitem.SubItems.Add(item.price.ToString());
            lsvItems.Items.Add(listitem);
        }

        private string Checki(int i )
        {
            string a = string.Empty;
            if (i < 10)
            {
                a = "00" + i;
                return a;

            }
            else if (i < 100)
            {
                a = "0" + i;
                return a;

            }
            else return a;
        }
        int d = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnSubmit.Enabled = true;
            TxtId.Enabled = true;
            TxtId.Text = "";
            TxtName.Text = "";
            TxtType.Text = "";
            TxtQuantity.Text = "";
            TxtUrl.Text = "";
            TxtPrice.Text = "";
            lsvItems.Items.Clear();
            int i = 1;
            int a = 0;
            int b = 0;
            int c = 0;
            while (true)
            {
                string temp = Checki(i);
                FirebaseResponse res1 = await db.client.GetTaskAsync("Items/" + "F" + temp);
                FirebaseResponse res2 = await db.client.GetTaskAsync("Items/" + "D" + temp);
                FirebaseResponse res3 = await db.client.GetTaskAsync("Items/" + "C" + temp);
                if (res1.Body == "null" && res1.Body == "null" && res3.Body == "null") { break; }
                if (res1.Body != "null") { a++; }
                if (res2.Body != "null") { b++; }
                if (res3.Body != "null") { c++; }
                i++;
            }
            for (int j = 1; j <= a; j++)
            {
                additem123("F" + Checki(j));
            }
            for (int j = 1; j <= b; j++)
            {
                additem123("D" + Checki(j));
            }
            for (int j = 1; j <= c; j++)
            {
                additem123("C" + Checki(j));
            }


        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await db.client.GetTaskAsync("Items/" + TxtId.Text);
            int quantity1 = System.Convert.ToInt32(TxtQuantity.Text);
            int price1 = System.Convert.ToInt32(TxtPrice.Text);
            Items item = new Items
            {
                id = TxtId.Text,
                name = TxtName.Text,
                type = TxtType.Text,
                quantity = quantity1,
                url = TxtUrl.Text,
                price = price1,
            };
            db.client.SetTaskAsync("Items/" + TxtId.Text, item);
            if (lsvItems.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lsvItems.SelectedItems[0];
                lvi.SubItems[0].Text = TxtId.Text;
                lvi.SubItems[1].Text = TxtName.Text;
                lvi.SubItems[2].Text = TxtType.Text;
                lvi.SubItems[3].Text = TxtQuantity.Text;
                lvi.SubItems[4].Text = TxtUrl.Text;
                lvi.SubItems[5].Text = TxtPrice.Text;
                MessageBox.Show("Edit Item thành công");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}