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
    public partial class EditCust : Form
    {
        public EmployeeMenu emp;
        ListViewItem list;
        public bool exit = true;
        Connection con = new Connection();
        public EditCust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            emp.Show();
        }
        public void refreshVehicleList()
        {
            V_model.Items.Clear();
            con.getVehicle(null,null,null,this);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddVehicle adv = new AddVehicle();
            adv.Show();
            adv.caller = "Cust";
            adv.edc = this;
            adv.emp = emp;
        }

        public void refresh()
        {
            listView1.Items.Clear();
            if(Search.Text != "")
            {
                String cmd = "viewCust '" + Search.Text + "'";
                con.view(cmd,null,null,null,null,null,null,this);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FName.Text != "" && LName.Text != "" && V_model.Text != "" && CN.Text != "" && HN.Text != "" && SN.Text != "" && city.Text != "")
            {
                string cmd = "exec UpdCustomer "+ CID.Text + ", '" + FName.Text + "', '" + LName.Text + "', '" + V_model.Text + "', '" + CN.Text + "', '" + HN.Text + "', '" + SN.Text + "', '" + city.Text + "'";
                string ret = con.change(cmd);
                refresh();
                MessageBox.Show(ret);
            }
            else
                MessageBox.Show("Task Cannot Be Completed while there are empty fields left");            }

        private void EditCust_Load(object sender, EventArgs e)
        {
            
            con.getVehicle(null,null,null,this);
            listView1.Items.Clear();
            listView1.Columns.Add("CID", 50);
            listView1.Columns.Add("FName", 120);
            listView1.Columns.Add("LName", 120);
            listView1.Columns.Add("Vehicle Model", 120);
            listView1.Columns.Add("Contact NO", 200);
            listView1.Columns.Add("House Number", 120);
            listView1.Columns.Add("Streat name", 120);
            listView1.Columns.Add("city", 120);
        }
        public void Add(String S1, String S2, String S3, String S4,String S5,String S6, String S7,String S8)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S3);
            list.SubItems.Add(S4);
            list.SubItems.Add(S2);
            list.SubItems.Add(S8);
            list.SubItems.Add(S5);
            list.SubItems.Add(S6);
            list.SubItems.Add(S7);
        }
        public void Veh(String S1)
        {
            V_model.Items.Add(S1);
        }
        private void Search_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CID.Text = listView1.FocusedItem.Text;
            FName.Text = listView1.FocusedItem.SubItems[1].Text;
            LName.Text = listView1.FocusedItem.SubItems[2].Text;
            V_model.Text = listView1.FocusedItem.SubItems[3].Text;
            CN.Text = listView1.FocusedItem.SubItems[4].Text;
            HN.Text = listView1.FocusedItem.SubItems[5].Text;
            SN.Text = listView1.FocusedItem.SubItems[6].Text;
            city.Text = listView1.FocusedItem.SubItems[7].Text;
        }
        private void clear()
        {
            CID.Text = "";
            FName.Text = "";
            LName.Text = "";
            CN.Text = "";
            HN.Text = "";
            SN.Text = "";
            V_model.Text = "";
            city.Text = "";
        }
        private void btnDelOR_Click(object sender, EventArgs e)
        {
            if (CID.Text != "" || FName.Text != "")
            {
                if (MessageBox.Show("Are you Sure you want to delete " + FName.Text + " " + LName.Text, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string ret = con.exec("exec RemoveCust " + CID.Text);
                    String n = FName.Text + " "+ LName.Text;
                    if (ret == "Completed Successfully")
                    {
                        clear();
                        refresh();
                        MessageBox.Show(n + " has been Successfully deleted");
                    }
                    else
                        MessageBox.Show(ret);
                }
            }
            else
                MessageBox.Show("There is noting to delete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            listView1.Items.Clear();
        }

        private void V_model_TextChanged(object sender, EventArgs e)
        {
            con.getVehicle(null,  null, null, this, V_model.Text);
        }

        private void EditCust_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void EditCust_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp.exit = false;
            Application.Exit();
        }
    }
}
