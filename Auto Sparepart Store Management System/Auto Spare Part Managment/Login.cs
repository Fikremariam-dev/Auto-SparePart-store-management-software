using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Auto_Spare_Part_managment
{
    public partial class AdminLogin : Form
    {
        public Start st;
        public int q = 1;
        private string userName;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            txtPassword.PasswordChar = '●';
            DateTime time = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTime.Text = time.ToString();
        }
        private void login()
        {
            if (txtUsername.Text == "")
                MessageBox.Show("User name Cannot be left empty!");
            else if (txtPassword.Text == "")
                MessageBox.Show("Password Cannot be left empty!");
            else
            {
                userName = txtUsername.Text;
                string cmd = "exec Login_chk " + txtUsername.Text + ", " + txtPassword.Text;
                if (q == 2)
                    cmd = "exec Login_chk " + txtUsername.Text + ", " + txtPassword.Text + ",2";
                Connection con = new Connection();
                int x = con.Login(cmd);
                if (x == 1)
                {
                    this.Dispose();
                    Menu am = new Menu();
                    am.userName = this.userName;
                    am.Show();
                }
                else if (x == 2)
                {
                    this.Dispose();
                    EmployeeMenu emp = new EmployeeMenu();
                    emp.userName = this.userName;
                    emp.Show();
                }
                else if (x == -1)
                {
                    _ = MessageBox.Show("Wrong User name or Password. Please Try Again");
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            st.Show();
        }

        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                login();
            }
        }
    }
}
