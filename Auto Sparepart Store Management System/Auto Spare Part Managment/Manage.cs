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
    public partial class Manage : Form
    {
        public Menu m;
        Connection con = new Connection();
        ListViewItem list;
        public Manage()
        {
            InitializeComponent();
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Dispose();
            m.Show();
        }
        private void AdminManage_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("First Name", 100);
            listView1.Columns.Add("Last Name", 150);
            listView1.Columns.Add("B_Date", 90);
            listView1.Columns.Add("House No", 100);
            listView1.Columns.Add("Street Name", 100);
            listView1.Columns.Add("City", 100);
            listView1.Columns.Add("Contact No", 100);
            listView1.Columns.Add("user Name", 100);
            listView1.Columns.Add("Password", 100);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTimer.Text = time.ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserID.Text = listView1.FocusedItem.Text;
            FN.Text = listView1.FocusedItem.SubItems[1].Text;
            LN.Text = listView1.FocusedItem.SubItems[2].Text;
            B_Date.Text = listView1.FocusedItem.SubItems[3].Text;
            CN.Text = listView1.FocusedItem.SubItems[7].Text;
            HN.Text = listView1.FocusedItem.SubItems[4].Text;
            SN.Text = listView1.FocusedItem.SubItems[5].Text;
            city.Text = listView1.FocusedItem.SubItems[6].Text;
            UN.Text = listView1.FocusedItem.SubItems[8].Text;
            PWD.Text = listView1.FocusedItem.SubItems[9].Text;
        }
        public void Add (String S1, String S2, String S3, String S4, String S5, String S6, String S7,String S8,String S9,String S10)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S2);
            list.SubItems.Add(S3);
            list.SubItems.Add(S4);
            list.SubItems.Add(S5);
            list.SubItems.Add(S6);
            list.SubItems.Add(S7);
            list.SubItems.Add(S8);
            list.SubItems.Add(S9);
            list.SubItems.Add(S10);
        }
        private void refresh()
        {
            listView1.Items.Clear();
            if (txtSearch.Text != "")
            {
                String command = "exec viewEmp '" + txtSearch.Text + "'";
                con.view(command, null, null, null, null, null, this);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void clear()
        {
            txtUserID.Text = "";
            FN.Text = "";
            LN.Text = "";
            B_Date.Text = "";
            CN.Text = "";
            HN.Text = "";
            SN.Text = "";
            city.Text = "";
            UN.Text = "";
            PWD.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
                MessageBox.Show("There is noting to remove");
            else
            {
                if (MessageBox.Show("Are you Sure you want to remove " + FN.Text +" "+LN.Text, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.exec("removeEmp " + Convert.ToInt32(txtUserID.Text));
                    String n = FN.Text + " " + LN.Text;
                    clear();
                    MessageBox.Show(n + " has been Successfully removed");
                    listView1.Items.Clear();
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtUserID.Text != "" && FN.Text != "" && LN.Text != "" && B_Date.Text != "" && CN.Text != "" && HN.Text != "" && SN.Text != "" && city.Text != "" && UN.Text != "" && PWD.Text != "")
            {
                string Cmd = "exec empUpdate " + txtUserID.Text+ ", '" + FN.Text + "', '" + LN.Text + "', '" + B_Date.Text + "', '" + CN.Text + "', '" + HN.Text + "', '" + SN.Text + "', '" + city.Text + "', '" + UN.Text + "', '" + PWD.Text + "'";
                String ret = con.exec(Cmd);
                refresh();
                MessageBox.Show(ret);
            }
            else
                MessageBox.Show("Task cannot be completed if there are empty fields left!");
        }

        private void Manage_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void Manage_FormClosed(object sender, FormClosedEventArgs e)
        {
            m.exit = false;
            Application.Exit();
        }
    }
}
