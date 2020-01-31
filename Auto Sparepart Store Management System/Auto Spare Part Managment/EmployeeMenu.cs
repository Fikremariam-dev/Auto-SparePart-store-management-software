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
    public partial class EmployeeMenu : Form
    {
        public string userName;
        public Boolean exit = true;
        public EmployeeMenu()
        {
            InitializeComponent();
        }

        private void chaneUserNAmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            changeUserName un = new changeUserName();
            un.User = userName;
            un.Caller = "Employee";
            un.Show();
            un.em = this;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Start s = new Start();
            s.Show();
        }

        private void EmployeeMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label2.Text = time.ToString();
        }
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass();
            this.Hide();
            cp.Caller = "Employee";
            cp.Show();
            cp.emp = this;
            cp.userName = userName;
        }
        private void addVehicleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddVehicle adv = new AddVehicle();
            adv.Show();
            adv.caller = "Emp";
            adv.emp = this;
            this.Hide();
        }
        private void EmployeeMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void EmployeeMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer adc = new AddCustomer();
            adc.Show();
            adc.emp = this;
            adc.SalesEmpUserName = userName;
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditCust ed = new EditCust();
            ed.Show();
            ed.emp = this;
            this.Hide();
        }

        private void addOrderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustOrder co = new CustOrder();
            co.Show();
            co.emp = this;
            co.username = userName;
        }
        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View adm = new View();
            adm.S = "Emp";
            adm.Show();
            adm.emp = this;
            this.Hide();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales s = new Sales();
            s.emp = this;
            s.Show();
        }
    }
}
