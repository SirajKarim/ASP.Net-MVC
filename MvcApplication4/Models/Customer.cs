using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{

    public class Customer
    {
        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
         [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public string Address { get; set; }
           [Display(Name = "Contact Num ")]
        public string Contact_No { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public void Add()
        {
            //string q = "Insert Into Customer Values(" + CustomerID + ",'" + CustomerName + "','" + Address + "'," + Contact_No + ",'" + Country + "','" + City + "')";
            //SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            //cmd.ExecuteNonQuery();




            SqlCommand cmd = new SqlCommand("AddCustomer", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = CustomerID;
            cmd.Parameters.AddWithValue("@CustomerName", SqlDbType.Int).Value = CustomerName;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.Int).Value = Address;
            cmd.Parameters.AddWithValue("@Contact_No", SqlDbType.Int).Value = Contact_No;
            cmd.Parameters.AddWithValue("@Country", SqlDbType.Int).Value = Country;
            cmd.Parameters.AddWithValue("@City", SqlDbType.Int).Value = City;
          
       
          
            cmd.ExecuteNonQuery();

        }

        public void Delete()
        {
            string q = "Delete Customer Where Name= '" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void Update()
        {
            string q = "Update Customer Set Name= '" + CustomerName + "',Address='"+Address+"',Contact_No= " + Contact_No + " Where CostumerID='" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Customer> ShowAll()
        {
            List<Customer> lst = new List<Customer>();
            string q = "Select * From Customer";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Customer b = new Customer();
                b.CustomerID = (int)sdr[0];
                b.CustomerName = (string)sdr[1];
                b.Address = (string)sdr[2];
                b.Contact_No = (string)sdr[3];
                b.Country = (string)sdr[4];
                b.City = (string)sdr[5];

                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Customer Search()
        {

            Customer b = new Customer();

            string q = "select * from Customer  where CostumerID='" + CustomerID + "'";
            SqlCommand sc = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.CustomerID = (int)sdr[0];
                b.CustomerName = (string)sdr[1];
                b.Address = (string)sdr[2];
                b.Contact_No = (string)sdr[3];
                b.Country = (string)sdr[4];
                b.City = (string)sdr[5];
            }
            sdr.Close();
            return b;

        }
    }
}