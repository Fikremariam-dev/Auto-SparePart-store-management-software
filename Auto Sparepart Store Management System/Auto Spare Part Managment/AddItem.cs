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
    public partial class AddItem : Form
    {
        Connection con = new Connection();
        public Menu m;
        public Boolean exit = true;
        public AddItem()
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
            AddSupplier Ads = new AddSupplier();
            Ads.s = 2;
            Ads.cb = this;
            Ads.Show();
            Ads.m = m;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (S_P_name.Text != "" && V_Model.Text != "" && cond.Text != "" && qun.Text != "" && price.Text != "" && Supplier.Text != "" && type.Text != "")
            {
                if (check("Quantity", qun.Text) && check("Price", price.Text))
                {
                    String cmd = "exec AddSpareParts '" + Supplier.Text + "', '" + cond.Text + "', '" + price.Text + "', '" + qun.Text + "' , '" + S_P_name.Text + "' , '" + type.Text + "', '" + V_Model.Text + "'";
                    MessageBox.Show(con.change(cmd));
                }
            }
            else
                MessageBox.Show("The task cannot be completed while there are empty fields left");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ;
        }
        public void Veh(String s)
        {
            V_Model.Items.Add(s);
        }
        private void AddItem_Load(object sender, EventArgs e)
        {
            Supplier.Items.Clear();
            con.GetSupp(null,this);
            con.getVehicle(this);
        }
        public void Supp (string sup)
        {
            Supplier.Items.Add(sup);
        }
        public void refreshVehicleList()
        {
            V_Model.Items.Clear();
            con.getVehicle(this);
        }
        public void refreshSupplierList()
        {
            Supplier.Items.Clear();
            con.GetSupp(null, this);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddVehicle adv = new AddVehicle();
            adv.caller = "Items";
            adv.adi = this;
            adv.Show();
            adv.m = m;
        }
        private void supudt (string supp)
        {
            MessageBox.Show(supp);
            Supplier.Items.Clear();
            con.GetSupp(null,this,supp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            S_P_name.Text = "";
            V_Model.Text = "";
            Supplier.Text = "";
            cond.Text = "";
            qun.Text = "";
            price.Text = "";
            type.Text = "";
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
        private void AddItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void AddItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m != null)
                m.exit = false;
            Application.Exit();
        }
    }
}
