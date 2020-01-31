using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_Spare_Part_managment
{
    public partial class UpDe : Form
    {
        ListViewItem list;
        Connection con = new Connection();
        public Menu m;
        public bool exit = true;
        public UpDe()
        {
            InitializeComponent();
        }
        private void back_Click(object sender, EventArgs e)
        {
            this.Dispose();
                m.Show();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            PartNo.Text = "";
            qun.Text = "";
            Price.Text = "";
            txtProductName.Text = "";
            qun.Text = "";
            V_Model.Text = "";
            type.Text = "";
            cond.Text = "";
            Supplier.Text = "";
            listView1.Items.Clear();
        }
        public void Add(String S1, String S2, String S3, String S4, String S5, String S6, String S7, String S8, String S9)
        {
            list = listView1.Items.Add(S2);
            list.SubItems.Add(S7);
            list.SubItems.Add(S1);
            list.SubItems.Add(S3);
            list.SubItems.Add(S9);
            list.SubItems.Add(S4);
            list.SubItems.Add(S5);
            list.SubItems.Add(S6);
            list.SubItems.Add(S8);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        public void Supp(string sup)
        {
            Supplier.Items.Add(sup);
        }
        public void Veh(String s)
        {
            V_Model.Items.Add(s);
        }
        private void UpDe_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Supplier", 150);
            listView1.Columns.Add("Condition", 100);
            listView1.Columns.Add("Vehicle Model", 100);
            listView1.Columns.Add("Accuired date", 150);
            listView1.Columns.Add("Price", 100);
            listView1.Columns.Add("Quanity", 100);
            listView1.Columns.Add("Type", 100);
            con.GetSupp(null,null,null,this);
            con.getVehicle(null,this);
        }
        public void refreshVehicleList()
        {
            V_Model.Items.Clear();
            con.getVehicle(null, this);
        }
        public void refreshSupplierList()
        {
            Supplier.Items.Clear();
            con.GetSupp(null,null,null,this);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            PartNo.Text = listView1.FocusedItem.Text;
            txtProductName.Text = listView1.FocusedItem.SubItems[1].Text;
            V_Model.Text = listView1.FocusedItem.SubItems[4].Text;
            Price.Text = listView1.FocusedItem.SubItems[6].Text;
            qun.Text = listView1.FocusedItem.SubItems[7].Text;
            type.Text = listView1.FocusedItem.SubItems[8].Text;
            cond.Text = listView1.FocusedItem.SubItems[3].Text;
            Supplier.Text = listView1.FocusedItem.SubItems[2].Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (PartNo.Text != "" && txtProductName.Text != "" && V_Model.Text != "" && Price.Text != "" && type.Text != "" && cond.Text != "" && Supplier.Text != "")
            {
                if (check("Price", Price.Text) && check("Quantity", qun.Text))
                {
                    string cmd = "exec Spare_part_Update '" + PartNo.Text + "', '" + txtProductName.Text + "', '" + cond.Text + "', '" + Price.Text + "', '" + qun.Text + "', '" + type.Text + "', '" + V_Model.Text + "', '" + Supplier.Text + "'";
                    string ret = con.change(cmd);
                    refresh();
                    MessageBox.Show(ret);
                }
            }
            else
                MessageBox.Show("Task cannot be completed if there are empty fields left!");       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (PartNo.Text == "")
                MessageBox.Show("There is noting to remove");
            else
            {
                if (MessageBox.Show("Are you Sure you want to remove " + txtProductName.Text, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.exec("Delete_Spare_Parts " + Convert.ToInt32(PartNo.Text));
                    String n = txtProductName.Text;
                    refresh();
                    MessageBox.Show(n + " has been Successfully removed");
                }

            }
        }
        private Boolean check(String n, String var)
        {
            try
            {
                if (n == "Quantity")
                    Convert.ToInt32(var);
                else
                    Convert.ToDouble(var);
            }
            catch (System.FormatException)
            {
                MessageBox.Show(n + " cannot be: " + var);
                return false;
            }
            return true;
        }
        private void refresh()
        {
            listView1.Items.Clear();
            if (txtSearch.Text != "")
            {
                string c = "exec Search_Spare_Part '" + txtSearch.Text + "'";
                con.view(c, null, null, null, null, this);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblDate.Text = time.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddVehicle adv = new AddVehicle();
            adv.Show();
            adv.caller = "UPDE";
            adv.ud = this;
            adv.m = m;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSupplier ads = new AddSupplier();
            ads.Show();
            ads.s = 3;
            ads.ud = this;
            ads.m = m;
        }

        private void UpDe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void UpDe_FormClosed(object sender, FormClosedEventArgs e)
        {
             if (m != null)
                m.exit = false;
            Application.Exit();
        }
    }
}
