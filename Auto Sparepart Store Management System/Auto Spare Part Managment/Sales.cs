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
    public partial class Sales : Form
    {
        Connection con = new Connection();
        public EmployeeMenu emp;
        public Sales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            emp.Show();
        }

        private void Sales_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp.exit = false;
            Application.Exit();
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
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
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox1.Items.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if(check("Quantity", textBox2.Text) && check("Price", textBox3.Text))
                {
                    string cmd = "exec SaleSP '" + textBox1.Text + "', '" + comboBox1.Text + "', " + textBox2.Text + ", " + textBox3.Text;
                    String ret = con.change(cmd);
                    MessageBox.Show(ret);
                    if (ret == "Completed Successfully")
                        clear();
                }
            }
            else
                MessageBox.Show("The task cannot be completed while there are empty field left");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text != "")
            {
                comboBox1.Items.Clear();
                con.getCustomer(comboBox1.Text,this);
            }
        }
        public void Cust(String C)
        {
            comboBox1.Items.Add(C);
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            int x = time.ToString().Length;
            String n = time.ToString();
            for (int i = 0; i < --x; i++)
            {
            if (n[i] == ' ')
            {
            n = n.Substring(0,i);
            }
            }
            textBox4.Text = n;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                comboBox1.Items.Clear();
                con.getCustomer(comboBox1.Text, this);
            }
        }
    }
}
