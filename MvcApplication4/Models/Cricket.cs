using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Cricket
    {
        public string Product_name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
       



        public void add()
        {
            string q = "Insert Into Library Values('" + Product_name + "','" + Size + "','" + Color + "'," + Price + ")";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void delete()
        {
            string q = "Delete Library Where Name= '" + Product_name + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void update()
        {
            string q = "Insert Into Library Values('" + Product_name + "','" + Size + "','" + Color + "'," + Price + ")";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Cricket> ShowAll()
        {
            List<Cricket> lst = new List<Cricket>();
            string q = "Select * From Book";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Cricket b = new Cricket();
                b.Product_name = (string)sdr[0];
                b.Size = (string)sdr[1];
                b.Color = (string)sdr[2];
                b.Price = (int)sdr[3];
                lst.Add(b);
            }
            sdr.Close();
            return lst;



        }
        public Cricket Search()
        {

            Cricket b = new Cricket();

            string q = "select * from Cricket where Product_name='" + Product_name + "'";
            SqlCommand sc = new SqlCommand(q,Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.Product_name = (string)sdr[0];
                b.Size = (string)sdr[1];
                b.Color = (string)sdr[2];
                b.Price = (int)sdr[3];
            }
            sdr.Close();
            return b;

        }
    }
}
