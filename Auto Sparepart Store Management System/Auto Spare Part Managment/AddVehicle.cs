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
    public partial class AddVehicle : Form
    {
        public string caller = "admin";
        public AddItem adi;
        public Menu m;
        public AddCustomer Cust;
        public UpDe ud;
        public EditCust edc;
        ListViewItem list;
        public EmployeeMenu emp;
        Connection con = new Connection();
        public AddVehicle()
        {
            InitializeComponent();
        }

        private void AddVehicle_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("VID", 50);
            listView1.Columns.Add("model", 120);
            listView1.Columns.Add("M_year", 120);
            listView1.Columns.Add("color", 200);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (caller == "Items")
            {
                adi.Show();
                adi.refreshVehicleList();
            }
                
            else if (caller == "Emp")
            {
                emp.Show();
            }
            else if (caller == "AddCustomer")
            {
                Cust.refreshVehicleList();
                Cust.Show();
            }
            else if (caller == "UPDE")
            {
                ud.refreshVehicleList();
                ud.Show();
            }
            else if (caller == "Cust")
            {
                edc.refreshVehicleList();
                edc.Show();
            }
            else
            {
                m.Show();
            }
        }
        public void refresh()
        {
            listView1.Items.Clear();
            if (textBox2.Text != "")
            {
                String command = "exec viewVehicle '" + textBox2.Text + "'";
                con.view(command,null,this);
            }
        }
        public void Add (String S1, String S2, String S3, String S4)
        {
            list = listView1.Items.Add(S1);
            list.SubItems.Add(S2);
            list.SubItems.Add(S3);
            list.SubItems.Add(S4);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnDelOR_Click(object sender, EventArgs e)
        {
            if (VID.Text == "" || model.Text == "")
                MessageBox.Show("There is noting to remove");
            else
            {
                if (MessageBox.Show("Are you Sure you want to remove " + model.Text, "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) ;
                {
                    Connection con = new Connection();
                    con.exec("removeVehicle " + Convert.ToInt32(VID.Text));
                    String n = model.Text;
                    VID.Text = "";
                    model.Text = "";
                    m_year.Text = "";
                    color.Text = "";
                    MessageBox.Show(n + " has been Successfully removed");
                    listView1.Items.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(VID.Text != "")
            {
                MessageBox.Show("Item already exists");
                return;
            }
            if (model.Text != "" && m_year.Text != "" && color.Text != "")
            {
                string ret;
                String c = "exec AddVehicle  '" + model.Text + "', '" + m_year.Text + "', '" + color.Text + "'";
                ret = con.exec(c);
                MessageBox.Show(ret);
            }
            else
            {
                MessageBox.Show("The task cannot be completed while there are empty fields left");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (model.Text != "" && m_year.Text != "" && color.Text != "" && VID.Text != "")
            {
                String cmd = "exec VehicleUpdate " + Convert.ToInt32(VID.Text) + ", '" + model.Text + "', '" + m_year.Text + "', '" + color.Text + "'";
                String ret = con.exec(cmd);
                refresh();
                MessageBox.Show(ret);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VID.Text = listView1.FocusedItem.Text;
            model.Text = listView1.FocusedItem.SubItems[1].Text;
            m_year.Text = listView1.FocusedItem.SubItems[2].Text;
            color.Text = listView1.FocusedItem.SubItems[3].Text;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            VID.Text = "";
            model.Text = "";
            m_year.Text = "";
            color.Text = "";
        }


        private void AddVehicle_FormClosing(object sender, FormClosingEventArgs e)
        {
                DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    e.Cancel = true;
        }

        private void AddVehicle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adi != null)
                adi.exit = false;
            if (emp != null)
                emp.exit = false;
            if (Cust != null)
                Cust.exit = false;
            if (ud != null)
                ud.exit = false;
            if (edc != null)
                edc.exit = false;
            if(m != null)
                m.exit = false;
            Application.Exit();
        }
    }
}
