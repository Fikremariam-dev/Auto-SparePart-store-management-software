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
    public partial class changeUserName : Form
    {
        public int x = 1;
        public string User ;
        public string Caller = "Admin";
        public Menu adm;
        public EmployeeMenu em;
        public changeUserName()
        {
            InitializeComponent();
        }

        private void changeUserName_Load(object sender, EventArgs e)
        {
            oldName.Text = User;
            textBox2.PasswordChar = '●';
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (Caller == "Admin")
            {
                adm.userName = User;
                adm.Show();
            }
            else
            {
                em.userName = newName.Text;
                em.Show();
            }
        }

        private void done_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (Caller == "Admin")
            { 
                adm.userName = newName.Text;
                adm.Show();
            }
            else
            {
                em.userName = newName.Text;
                em.Show();
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && newName.Text != "")
            {
                string cmd = "exec ChangeUN '" + oldName.Text + "', '" + newName.Text + "', '" + textBox2.Text + "', '" + Caller + "'";
                Connection con = new Connection();
                string s = con.change(cmd);
                MessageBox.Show(s);
                if (s == "Completed Successfully")
                {
                    User = newName.Text;
                    oldName.Text = newName.Text;
                    newName.Text = "";
                    textBox2.Text = "";
                }
            }
            else
                MessageBox.Show("Task cannot be completed while there are empty fields left!");
        }

        private void changeUserName_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void changeUserName_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adm != null)
                adm.exit = false;
            else
                em.exit = false;
            Application.Exit();
        }
    }
}
