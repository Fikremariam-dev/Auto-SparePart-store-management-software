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
    public partial class AddOrder : Form
    {
        public Menu m;
        public Boolean exit = true;
        Connection con = new Connection();
        ListViewItem list;
        public AddOrder()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSupplier ads = new AddSupplier();
            ads.s = 1;
            ads.ca = this;
            ads.Show();
            ads.m = m;
        }
        public void Supp(string sup)
        {
            Supplier.Items.Add(sup);
        }
        private void AddOrder_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Order ID", 90);
            listView1.Columns.Add("Spare Part", 100);
            listView1.Columns.Add("Order Date", 150);
            listView1.Columns.Add("Quantity", 90);
            listView1.Columns.Add("price", 100);
            listView1.Columns.Add("Supplier", 100);
            con.GetSupp(this);
        }
        public void refreshSupplierList()
        {
            Supplier.Items.Clear();
            con.GetSupp(this);
        }
        public void Add(String S1, String S2, String S3, String S4, String S5, String S6)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S6);
            list.SubItems.Add(S2);
            list.SubItems.Add(S3);
            list.SubItems.Add(S4);
            list.SubItems.Add(S5);
        }
        private void refresh()
        {
            listView1.Items.Clear();
            if (textBox1.Text != "")
            {
                String command = "exec viewOrder '" + textBox1.Text + "'";
                con.view(command, null, null, this);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtOrderID.Text = listView1.FocusedItem.Text;
            name.Text = listView1.FocusedItem.SubItems[1].Text;
            qun.Text = listView1.FocusedItem.SubItems[3].Text;
            price.Text = listView1.FocusedItem.SubItems[4].Text;
            Supplier.Text = listView1.FocusedItem.SubItems[5].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtOrderID.Text = "";
            name.Text = "";
            qun.Text = "";
            price.Text = "";
            Supplier.SelectedIndex = -1;
            listView1.Items.Clear();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "" || name.Text == "")
                MessageBox.Show("There is noting to remove");
            else
            {
                if (MessageBox.Show("Are you Sure you want to remove " + name.Text, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.exec("RemoveOrder " + Convert.ToInt32(txtOrderID.Text));
                    String n = name.Text;
                    txtOrderID.Text = "";
                    name.Text = "";
                    qun.Text = "";
                    price.Text = "";
                    Supplier.Text = "";
                    refresh();
                    MessageBox.Show(n + " has been Successfully removed");
                    listView1.Items.Clear();
                }

            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text != "" )
            {
                MessageBox.Show("Item already exists");
            }
            else if(name.Text != "" && price.Text != "" && qun.Text != "" && Supplier.Text != "")
            {
                if (check("Quantity", qun.Text) && check("Price", price.Text))
                {
                    string cmd = "exec Addorder " + qun.Text + ", " + price.Text + ", '"  + Supplier.Text + "', '" + name.Text + "'";
                    string ret = con.change(cmd);
                    if(ret == "Completed Successfully")
                    MessageBox.Show(ret);
                }
            }
            else
            {
                MessageBox.Show("Task cannot be completed while there are empty fields left!");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("There is noting to Update");
            }
            else if (name.Text != "" && price.Text != "" && qun.Text != "" && Supplier.Text != "")
            {
                if(check("Quantity",qun.Text)&& check("Price", price.Text))
                {
                    String cmd = "exec updateOrder " + txtOrderID.Text + "," + qun.Text + ", " + price.Text + ", '" + Supplier.Text + "', '" + name.Text + "'";
                    string ret = con.change(cmd);
                    refresh();
                    MessageBox.Show(ret);
                }
            }
        }
        private Boolean check(String n,String var)
        {
            try
            {
                if (n == "Quantity")
                    Convert.ToInt32(var);
                else
                    Convert.ToDouble(var);
            }
            catch(System.FormatException)
            {
                MessageBox.Show(n + " cannot be: " + var);
                return false;
            }
            return true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblDate.Text = time.ToString();
        }

        private void AddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void AddOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            m.exit = false;
            Application.Exit();
        }
    }
}
