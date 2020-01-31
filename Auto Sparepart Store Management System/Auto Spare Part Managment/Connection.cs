using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Auto_Spare_Part_managment
{
    class Connection
    {
        SqlConnection Conn;

        public int Login(string cmd)
        {
            int x = -1;
            using (Conn = new SqlConnection())
            {

                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;integrated security = true;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        x = Convert.ToInt32(reader[0]);
                    }
                }
                catch (SqlException)
                {
                    ;
                }
            }
            Conn.Close();
            return x;
        }
        public string exec (string cmd)
        {
            string ret = "Completed Successfully";
            using (Conn = new SqlConnection())
            {

                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    Cmd.ExecuteReader();
                }
                catch (SqlException)
                {
                    ret = "An error occured";
                }
            }
            Conn.Close();
            return ret;
        }
        public void view(String cmd, AddSupplier ads = null, AddVehicle adv = null, AddOrder ado = null, View v = null,UpDe ud = null,Manage adm = null,EditCust edc = null,CustOrder C_Order = null)
        {
            using (Conn = new SqlConnection())
            {
                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    if (ads != null)
                        while (reader.Read())
                        {
                            ads.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                        }
                    else if (adv != null)
                        while (reader.Read())
                        {
                            adv.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                        }
                    else if (ado != null)
                        while (reader.Read())
                        {
                            ado.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                        }
                    else if (v != null)
                        while (reader.Read())
                        {
                            v.parts(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                        }
                    else if (ud != null)
                        while (reader.Read())
                        {
                            ud.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString());
                        }
                    else if (edc != null)
                    {
                        while (reader.Read())
                            edc.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
                    }
                    else if(adm != null)
                        while (reader.Read())
                        {
                            adm.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(),reader[9].ToString());
                        }
                    else
                        while(reader.Read())
                        {
                            C_Order.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),reader[6].ToString());
                        }
                   }
                catch (SqlException)
                {
                    MessageBox.Show("An error occured","Error");
                }
            }
            Conn.Close();
        }
        public void getCustomer(String Cust,Sales s = null)
        {
            String cmd = "exec getCust '" + Cust + "'";
            using (Conn = new SqlConnection())
            {
                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (s != null)
                            s.Cust(reader[0].ToString());
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occured", "Error");
                }
            }
            Conn.Close();
        }
        public void GetSupp(AddOrder ado = null, AddItem ads = null, String supp = null,UpDe ud = null)
        {
            String cmd = "exec getSuppNames ''";
            if (supp != null)
                cmd = "exec getSuppNames '" + supp + "'";
            using (Conn = new SqlConnection())
            {
                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (ads != null)
                            ads.Supp(reader[0].ToString());
                        else if(ado != null)
                            ado.Supp(reader[0].ToString());
                        else
                            ud.Supp(reader[0].ToString());
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occured","Error");
                }
            }
            Conn.Close();
        }
        public void getVehicle(AddItem ad = null,UpDe ud = null,AddCustomer adc = null,EditCust edc =null,string veh = null)
        {
            String cmd = "exec getVehicle ''";
            if (veh != null)
                cmd = "exec getVehicle '" + veh + "'";
            using (Conn = new SqlConnection())
            {
                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    if (ad != null)
                        while (reader.Read())
                        {
                            ad.Veh(reader[0].ToString());
                        }
                    else if(ud != null)
                        while (reader.Read())
                        {
                            ud.Veh(reader[0].ToString());
                        }
                    else if (edc != null)
                        while (reader.Read())
                        {
                            edc.Veh(reader[0].ToString());
                        }
                    else
                        while(reader.Read())
                        {
                            adc.Veh(reader[0].ToString());
                        }
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occured","Error");
                }
            }
            Conn.Close();
        }
        public string change(string cmd)
        {
            string ret = "Completed Successfully";
            using (Conn = new SqlConnection())
            {

                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ret = reader[0].ToString();
                    }
                    }
                catch (SqlException)
                {
                    ret = "An error occured";
                }
            }
            Conn.Close();
            return ret;
        }
        public void report(String cmd,Report rr)
        {
            using (Conn = new SqlConnection())
            {
                try
                {
                    Conn.ConnectionString = "Server = (local);Database = Spare_parts;Trusted_Connection = true";
                    SqlCommand Cmd = new SqlCommand(cmd, Conn);
                    Conn.Open();
                    SqlDataReader reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rr.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                        //MessageBox.Show((reader[0].ToString()+ " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString()));
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occured", "Error");
                }
            }
            Conn.Close();
        }
    }
}