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
    public partial class Register : Form
    {
        public Menu m;
        Connection con = new Connection();
        public Register()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            m.Show();
        }
        private void clear()
        {
            FName.Text = "";
            LName.Text = "";
            BDate.Text = "";
            CN.Text = "";
            HN.Text = "";
            City.Text = "";
            UN.Text = "";
            SN.Text = "";
            PWD.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (FName.Text != "" && LName.Text != "" && BDate.Text != "" && CN.Text != "" && HN.Text != "" && SN.Text != "" && City.Text != "" && UN.Text != "" && PWD.Text != "")
            {
                String cmd = "exec RegisterUser '"+ FName.Text + "', '" + LName.Text + "', '" + BDate.Text +"', '" + CN.Text + "' , '" + HN.Text + "', '" + SN.Text + "' , '" + City.Text + "' , '" + UN.Text + "' , '" + PWD.Text +"'";
                string ret = con.exec(cmd);
                if (ret == "Completed Successfully")
                    clear();
                MessageBox.Show(ret);
            }
            else
                MessageBox.Show("Task Cannot be completed while there are empty fields left");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTimer.Text = time.ToString();
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            m.exit = false;
            Application.Exit();
        }
    }
}
