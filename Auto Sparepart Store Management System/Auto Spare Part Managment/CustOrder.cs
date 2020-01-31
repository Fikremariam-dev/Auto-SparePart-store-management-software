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
    public partial class CustOrder : Form
    {
        public EmployeeMenu emp;
        Connection con = new Connection();
        ListViewItem list;
        public string username;
        public bool exit = true;
        public CustOrder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            emp.Show();
        }

        private void CustOrder_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Order ID", 90);
            listView1.Columns.Add("Customer", 100);
            listView1.Columns.Add("Spare Part", 150);
            listView1.Columns.Add("Quantity", 90);
            listView1.Columns.Add("price", 100);
            listView1.Columns.Add("Order Date", 100);
            listView1.Columns.Add("Delivery Date", 100);
            //Get--Customer
        }
        public void Add (String S1, String S2, String S3, String S4, String S5, String S6, String S7)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S2);
            list.SubItems.Add(S5);
            list.SubItems.Add(S6);
            list.SubItems.Add(S7);
            list.SubItems.Add(S3);
            list.SubItems.Add(S4);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            OrderID.Text = listView1.FocusedItem.Text;
            Customer.Text = listView1.FocusedItem.SubItems[1].Text;
            SparePart.Text = listView1.FocusedItem.SubItems[2].Text;
            qun.Text = listView1.FocusedItem.SubItems[3].Text;
            price.Text = listView1.FocusedItem.SubItems[4].Text;
            Ddate.Text = listView1.FocusedItem.SubItems[5].Text;
        }

        private void refresh()
        {
            listView1.Items.Clear();
            if(textBox5.Text != "")
            {
                string cmd = "exec viewCustOrder '" + textBox5.Text + "'";
                con.view(cmd, null, null, null, null, null, null, null, this);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            Date.Text = time.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OrderID.Text = "";
            Customer.Text = "";
            SparePart.Text = "";
            qun.Text = "";
            price.Text = "";
            Ddate.Text = "";
            textBox5.Text = "";
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (OrderID.Text == "")
            {
                if (Customer.Text != "" && SparePart.Text != "" && qun.Text != "" && price.Text != "" && Ddate.Text != "")
                {
                    if (check("Quantity", qun.Text) && check("Price", price.Text))
                    {
                        string cmd = "exec addCustOrder '" + Customer.Text + "', '" + SparePart.Text + "', " + qun.Text  +", " + price.Text + ", '" + Ddate.Text + "'";
                        string ret = con.change(cmd);
                        MessageBox.Show(ret);
                    }
                }
                else
                    MessageBox.Show("task cannot be completed while there are empty fileds left");
            }
            else
                MessageBox.Show("order already exists");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (OrderID.Text != "")
            {
                if (Customer.Text != "" && SparePart.Text != "" && qun.Text != "" && price.Text != "" && Ddate.Text != "")
                {
                    if(check("Quantity",qun.Text) && check("Price",price.Text))
                    {
                        string cmd = "exec updtCustOrder " + OrderID.Text +", '" + Customer.Text + "', '" + SparePart.Text + "', " + qun.Text + ", " + price.Text + ", '" + Ddate.Text + "'";
                        string ret = con.change(cmd);
                        refresh();
                        MessageBox.Show(ret);
                    }
                }
            }
            else
                MessageBox.Show("There is noting to update");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OrderID.Text = "";
            qun.Text = "";
            price.Text = "";
            SparePart.Text = "";
            Customer.Text = "";
            Ddate.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (OrderID.Text != "")
            {
                string ret = con.exec("exec delC_order " + OrderID.Text);
                refresh();
                MessageBox.Show(ret);
            }
            else
                MessageBox.Show("There is noting to delete", "ERROR");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer adc = new AddCustomer();
            adc.C_Order = this;
            adc.Show();
            adc.emp = emp;
            adc.SalesEmpUserName = username;
        }

        private void CustOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void CustOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp.exit = false;
            Application.Exit();
        }
    }
}
