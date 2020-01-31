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
    public partial class ChangePass : Form
    {
        public string userName;
        public string Caller = "Admin";
        public Menu adm;
        public EmployeeMenu emp;
        public ChangePass()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
            if (Caller == "Admin")
                adm.Show();
            else
                emp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
                Connection con = new Connection();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox1.Text == textBox2.Text)
                {
                    string cmd = "exec Change_Pass '" + userName + "', '" + textBox3.Text + "', '" + textBox1.Text + "' , '" + Caller +"'";
                    MessageBox.Show(con.change(cmd));
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                    MessageBox.Show("The passwords you entered do not match!!!");
            }
            else
                MessageBox.Show("The task cannot be Completed while there are empty fields left");
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '●';
            textBox2.PasswordChar = '●';
            textBox3.PasswordChar = '●';
        }

        private void ChangePass_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
        }

        private void ChangePass_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adm != null)
                adm.exit = false;
            else
                emp.exit = false;
            Application.Exit();
        }
    }
}
