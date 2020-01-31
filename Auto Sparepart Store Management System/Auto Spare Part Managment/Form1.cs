using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Auto_Spare_Part_managment
{

    public partial class Start : Form
    {

        public Start()
        {
            InitializeComponent();
        }

        private void loginAsAdminToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AdminLogin frmAD = new AdminLogin();
            frmAD.st = this;
            frmAD.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginAsEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminLogin em = new AdminLogin();
            em.q = 2;
            em.st = this;
            em.Show();
            this.Hide();
        }
        private void Start_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
