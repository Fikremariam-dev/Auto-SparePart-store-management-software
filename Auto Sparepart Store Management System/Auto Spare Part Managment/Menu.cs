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
    public partial class Menu : Form
    {
        public string userName;
        public Boolean exit = true;
        public Menu()
        {
            InitializeComponent();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label3.Text = time.ToString();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Start log = new Start();
            log.Show();
        }
        private void changeUserNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            changeUserName un = new changeUserName();
            un.User = userName;
            un.Show();
            un.adm = this;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass();
            this.Hide();
            cp.Show();
            cp.userName = userName;
            cp.adm = this;
        }
        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddSupplier ads = new AddSupplier();
            ads.Show();
            ads.m = this;
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddVehicle adv = new AddVehicle();
            adv.m = this;
            adv.Show();
            this.Hide();
        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;    
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register ADR = new Register();
            ADR.m = this;
            ADR.Show();
        }

        private void manageToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage Am = new Manage();
            Am.Show();
            Am.m = this;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddItem adi = new AddItem();
            adi.m = this;
            adi.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View av = new View();
            av.m = this;
            av.Show();
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpDe u = new UpDe();
            u.Show();
            u.m = this;
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddOrder ado = new AddOrder();
            ado.Show();
            ado.m = this;
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report rp = new Report();
            rp.Show();
            rp.m = this;
            this.Hide();
        }
    }
}
