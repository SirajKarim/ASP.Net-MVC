using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Nic { get; set; }


        public void Add()
        {
            //string q = "insert into CustomerData (CustomerName,CompanyName,ContactNo,ContactTitle,City,Country,Nic,Email,Address) values   ('" + CustomerName + "','" + CompanyName + "','" + ContactNo + "','" + ContactTitle + "','" + City + "','" + Country + "','" + Nic + "','" + Email + "','" + Address + "')";
            SqlCommand cmd = new SqlCommand("SP_AddCust", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID",CustomerID);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@Nic", Nic);
           cmd.ExecuteNonQuery();
        }
        public List<Customer> ShowAll()
        {
           // string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_CustShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Customer> lst = new List<Customer>();
            while (sdr.Read())
            {
                Customer cs = new Customer();

                cs.CustomerID = (int)sdr["CustomerID"];
                cs.CustomerName = (string)sdr["CustomerName"];
                cs.City = (string)sdr["City"];
                cs.Country = (string)sdr["Country"];
                cs.Nic = (int)sdr["Nic"];
                cs.Address = (string)sdr["Address"];
                lst.Add(cs);
            }
            sdr.Close();
            return lst;
        }


        public Customer Search()
        {
          //  string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_CustSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID",CustomerID);
            SqlDataReader sdr = cmd.ExecuteReader();
            Customer cs = new Customer();

            while (sdr.Read())
            {

                cs.CustomerID = (int)sdr["CustomerID"];
                cs.CustomerName = (string)sdr["CustomerName"];
                cs.City = (string)sdr["City"];
                cs.Country = (string)sdr["Country"];
                cs.Nic = (int)sdr["Nic"];
                cs.Address = (string)sdr["Address"];
            }
            sdr.Close();
            return cs;
        }

        public void Update()
        {
            //string q = "Update  CustomerData set CustomerName='"+CustomerName+"' , CompanyName='"+CompanyName+"' , ContactNo='"+ContactNo+"' , ContactTitle='"+ContactTitle+"' , City='"+City+"' , Country='"+Country+"' , Nic='"+Nic+"' , Email='"+Email+"' , Address= '"+Address+"' where CustomerID='"+CustomerID+"' ";
            SqlCommand cmd = new SqlCommand("SP_CustUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@Nic", Nic);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID); cmd.ExecuteNonQuery();
        }


        public void Delete()
        {
           // string q = "Delete CustomerData where CustomerID='" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand("SP_CustDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID); 
            cmd.ExecuteNonQuery();
        }
    }
}
