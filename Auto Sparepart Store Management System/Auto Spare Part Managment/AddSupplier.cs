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
    public partial class AddSupplier : Form
    {
        public int s = 0;
        public AddOrder ca;
        public AddItem cb;
        ListViewItem list;
        public Menu m;
        public UpDe ud;
        Connection con = new Connection();
        public bool exit = true;
        public AddSupplier()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (s == 1)
            {
                ca.refreshSupplierList();
                ca.Show();
            }
                
            else if (s == 2)
            {
                cb.Show();
                cb.refreshSupplierList();
            }
            else if (s == 3)
            {
                ud.refreshSupplierList();
                ud.Show();
            }

            else
                m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(SuppID.Text != "")
            {
                MessageBox.Show("Item already exists");
            }
            else if (suppname.Text != "" && suppcity.Text != "" && suppcon.Text != "")
            {
                string ret;
                String c = "exec AddSupplier '" + suppname.Text + "', '" + suppcity.Text + "', '" + suppcon.Text + "'";
                Connection con = new Connection();
                ret = con.exec(c);
                MessageBox.Show(ret);
            }
            else
            {
                MessageBox.Show("Task cannot be completed while there are empty fileds left");
            }

        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("City", 120);
            listView1.Columns.Add("Contact NO", 200);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(suppname.Text != "" && SuppID.Text != "" && suppcon.Text != "" && suppcity.Text != "")
            {  
                String cmd = "exec SupplierUpdate " + Convert.ToInt32(SuppID.Text) + ", '" + suppname.Text + "', '" + suppcity.Text + "', '" + suppcon.Text + "'";
                String ret = con.exec(cmd);
                refresh();
                MessageBox.Show(ret);
            }
        }
        public void refresh()
        {
            listView1.Items.Clear();
            if (textBox2.Text != "")
            {
                String command = "exec viewSupp '" + textBox2.Text + "'";
                con.view(command, this);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        public void Add(String S1, String S2, String S3, String S4)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S4);
            list.SubItems.Add(S2);
            list.SubItems.Add(S3);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SuppID.Text = listView1.FocusedItem.Text;
            suppname.Text = listView1.FocusedItem.SubItems[1].Text;
            suppcity.Text = listView1.FocusedItem.SubItems[2].Text;
            suppcon.Text = listView1.FocusedItem.SubItems[3].Text;
        }

        private void btnDelOR_Click(object sender, EventArgs e)
        {
            if (SuppID.Text == "" || suppname.Text == "")
                MessageBox.Show("There is noting to remove");
            else
            {
                if (MessageBox.Show("Are you Sure you want to remove " + suppname, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    con.exec("RemoveSupp " + Convert.ToInt32(SuppID.Text));
                    String n = suppname.Text;
                    SuppID.Text = "";
                    suppname.Text = "";
                    suppcity.Text = "";
                    suppcon.Text = "";
                    MessageBox.Show(n + " has been Successfully removed");
                    listView1.Items.Clear(); 
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuppID.Text = "";
            suppname.Text = "";
            suppcity.Text = "";
            suppcon.Text = "";
            textBox2.Text = "";
        }
        private void AddSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void AddSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(m != null)
                m.exit = false;
            if (ca != null)
                ca.exit = false;
            if (cb != null)
                cb.exit = false;
            if (ud != null)
                ud.exit = false;
            Application.Exit();
        }
    }
}