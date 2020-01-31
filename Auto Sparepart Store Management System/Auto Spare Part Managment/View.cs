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
    public partial class View : Form
    {
        Connection con = new Connection();
        public Menu m;
        public EmployeeMenu emp;
        ListViewItem list;
        public String S = "Admin";
        public View()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (S == "Admin")
                m.Show();
            else
                emp.Show();
        }

        private void View_Load(object sender, EventArgs e)
        {

            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("ID", 50);
            listView2.Columns.Add("Name", 100);
            listView2.Columns.Add("Supplier", 150);
            listView2.Columns.Add("Condition", 100);
            listView2.Columns.Add("Vehicle Model", 100);
            listView2.Columns.Add("Accuired date", 150);
            listView2.Columns.Add("Price", 100);
            listView2.Columns.Add("Quanity", 100);
            listView2.Columns.Add("Type", 100);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if(txtSearch.Text != ""  || textBox1.Text != "" || textBox2.Text != "")
            {
                string c = "exec Search_Spare_Part '" + txtSearch.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "'";
                con.view(c, null, null, null, this);
            }
        }
        public void parts(String S1, String S2, String S3, String S4, String S5, String S6, String S7,String S8,String S9)
        {
            list = listView2.Items.Add(S2);
            list.SubItems.Add(S7);
            list.SubItems.Add(S1);
            list.SubItems.Add(S3);
            list.SubItems.Add(S9);
            list.SubItems.Add(S4);
            list.SubItems.Add(S5);
            list.SubItems.Add(S6);
            list.SubItems.Add(S8);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (txtSearch.Text != "" || textBox1.Text != "" || textBox2.Text != "")
            {
                string c = "exec Search_Spare_Part '" + txtSearch.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "'";
                con.view(c, null, null, null, this);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            if (txtSearch.Text != "" || textBox1.Text != "" || textBox2.Text != "")
            {
                string c = "exec Search_Spare_Part '" + txtSearch.Text + "','" + textBox1.Text + "', '" + textBox2.Text + "'";
                con.view(c, null, null, null, this);
            }
        }

        private void View_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
        }

        private void View_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m != null)
                m.exit = false;
            else
                emp.exit = false;
            Application.Exit();
        }
    }
}
