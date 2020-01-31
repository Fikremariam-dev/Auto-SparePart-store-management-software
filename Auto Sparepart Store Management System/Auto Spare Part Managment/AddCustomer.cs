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
    public partial class AddCustomer : Form
    {
        Connection con = new Connection();
        public String SalesEmpUserName;
        public EmployeeMenu emp;
        public CustOrder C_Order;
        public bool exit = false;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            timer1.Start();
            con.getVehicle(null,null,this);
        }
        public void refreshVehicleList()
        {
            V_model.Items.Clear();
            con.getVehicle(null, null, this);
        }
        public void Veh(String s)
        {
            V_model.Items.Add(s);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTimer.Text = time.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FName.Text != "" && LName.Text != "" && V_model.Text != "" && CN.Text != "" && HN.Text != "" && SN.Text != "" && city.Text != "")
            {
                string cmd = "exec AddCustomer '" + FName.Text + "', '" + LName.Text + "', '" + V_model.Text + "', '" + CN.Text + "', '" + HN.Text + "', '" + SN.Text + "', '" + city.Text + "', '" + SalesEmpUserName + "'";
                MessageBox.Show(con.change(cmd));
            }
            else
                MessageBox.Show("The task cannot be completed while there are empty fields left", "Error");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            FName.Text = "";
            LName.Text = "";
            V_model.Text = "";
            CN.Text = "";
            HN.Text = "";
            SN.Text = "";
            city.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddVehicle adv = new AddVehicle();
            adv.Show();
            adv.Cust = this;
            this.Hide();
            adv.caller = "AddCustomer";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (C_Order != null)
                C_Order.Show();
            else
            emp.Show();
        }
        private void AddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sender == this)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void AddCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
                emp.exit = false;
            if (C_Order != null)
                C_Order.exit = false;
            Application.Exit();
        }
    }
}

