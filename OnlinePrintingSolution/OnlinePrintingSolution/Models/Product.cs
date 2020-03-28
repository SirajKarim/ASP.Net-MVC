using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }


        public void Add()
        {
            //string q = "insert into CustomerData (CustomerName,CompanyName,ContactNo,ContactTitle,City,Country,Nic,Email,Address) values   ('" + CustomerName + "','" + CompanyName + "','" + ContactNo + "','" + ContactTitle + "','" + City + "','" + Country + "','" + Nic + "','" + Email + "','" + Address + "')";
            SqlCommand cmd = new SqlCommand("SP_Product", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.ExecuteNonQuery();
        }
        public List<Product> ShowAll()
        {
            // string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_ProductShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Product> lst = new List<Product>();
            while (sdr.Read())
            {
                Product p = new Product();

              p.ProductID = (int)sdr[0];
              p.ProductName= (string)sdr[1];

                lst.Add(p);
            }
            sdr.Close();
            return lst;
        }


        public Product Search()
        {
            //  string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_ProductSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ ProductID", ProductID);
            SqlDataReader sdr = cmd.ExecuteReader();
            Product p = new Product();

            while (sdr.Read())
            {

                p.ProductID = (int)sdr[0];
                p.ProductName = (string)sdr[1];
            }
            sdr.Close();
            return p;
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand("SP_PoductUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ ProductID", ProductID);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.ExecuteNonQuery();
        }


        public void Delete()
        {
            // string q = "Delete CustomerData where CustomerID='" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand("SP_ProductDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ ProductID", ProductID);
            cmd.ExecuteNonQuery();
        }
    }
}