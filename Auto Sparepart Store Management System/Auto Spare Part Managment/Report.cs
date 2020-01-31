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
    public partial class Report : Form
    {
        double total = 0;
        double net = 0;
        ListViewItem list;
        public Menu m;
        Connection con = new Connection();
        public Report()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            m.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(StartDT.Text); 
        }
        private void gen()
        {
            listView1.Items.Clear();
            total = 0;
            net = 0;
            string cmd = "select * from rep('" + StartDT.Text + "'" + ", '" + endDate.Text + "')";
            con.report(cmd, this);
            string netloss = null;
            {
                if (net > 0)
                    label2.Text = "Net profit :-";
                else if (net < 0)
                {
                    label2.Text = "Net loss :-";
                    netloss = net.ToString().Substring(1);
                }
                else
                    label2.Text = "Net       :-";
            }
            label3.Text = total.ToString();
            if(netloss != null)
            {
                label4.Text = netloss;
                return;
            }
            label4.Text = net.ToString();
        }
        public void Add(string s1,string s2,string s3,string s4, string s5, string s6)
        {
            list = listView1.Items.Add(s1);
            list.SubItems.Add(s2);
            list.SubItems.Add(s3);
            list.SubItems.Add(s4);
            list.SubItems.Add(s5);
            list.SubItems.Add(s6);
            total += Convert.ToDouble(s5);
            net += Convert.ToDouble(s6);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Spare part", 100);
            listView1.Columns.Add("Quantity", 100);
            listView1.Columns.Add("price", 100);
            listView1.Columns.Add("Date sold", 110);
            listView1.Columns.Add("Total", 150);
            listView1.Columns.Add("Net", 100);
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            m.exit = false;
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            gen();
        }
    }
}
