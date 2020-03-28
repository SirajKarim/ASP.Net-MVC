using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Order
    {
        public int CostumerID { get; set; }
        public string Order_Date { get; set; }
        public string Release_Date { get; set; }
        public string ShippedDate { get; set; }
        public string Comments { get; set; }
        public void Add()
        {
            string q = "Insert Into Order Values(" + CostumerID + ",'" + Order_Date + "','" + Release_Date + "','" + ShippedDate + "','" + Comments + "')";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            string q = "Delete Order Where Name= '" + CostumerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void Update()
        {
            string q = "Update Order Set Order_Date= " + Order_Date + ",Release_Date='" + Release_Date + "',ShippedDate='"+ShippedDate+"' Where CostumerID='" + CostumerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Order> ShowAll()
        {
            List<Order> lst = new List<Order>();
            string q = "Select * From Order";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Order b = new Order();
                b.CostumerID = (int)sdr[0];
                b.Order_Date = (string)sdr[1];
                b.Release_Date = (string)sdr[2];
                b.ShippedDate = (string)sdr[3];
                b.Comments = (string)sdr[4];

                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Order Search()
        {

            Order b = new Order();

            string q = "select * from Order  where CostumerID='" + CostumerID + "'";
            SqlCommand sc = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.CostumerID = (int)sdr[0];
                b.Order_Date = (string)sdr[1];
                b.Release_Date = (string)sdr[2];
                b.ShippedDate = (string)sdr[3];
                b.Comments = (string)sdr[4];

            }
            sdr.Close();
            return b;

        }
    }
}