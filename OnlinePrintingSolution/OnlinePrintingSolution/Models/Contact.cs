using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class Contact
    {
        public int PersonId{ get; set; }
        public int ContactTypeId { get; set; }
        public int contact { get; set; }
        public string ContactTypeName { get; set; }


        public void Add()
        {
            //string q = "insert into CustomerData (CustomerName,CompanyName,ContactNo,ContactTitle,City,Country,Nic,Email,Address) values   ('" + CustomerName + "','" + CompanyName + "','" + ContactNo + "','" + ContactTitle + "','" + City + "','" + Country + "','" + Nic + "','" + Email + "','" + Address + "')";
            SqlCommand cmd = new SqlCommand("SP_AddContact", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            cmd.Parameters.AddWithValue("@ContactTypeId", ContactTypeId);
            cmd.Parameters.AddWithValue("@ContactTypeName", ContactTypeName);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.ExecuteNonQuery();
        }
        public List<Contact> ShowAll()
        {
            // string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_ContactShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Contact> lst = new List<Contact>();
            while (sdr.Read())
            {
                Contact c = new Contact();

                c.PersonId = (int)sdr[0];
                c.ContactTypeId = (int)sdr[1];
                c.ContactTypeName = (string)sdr[2];
                c.contact = (int)sdr[3];
            
                lst.Add(c);
            }
            sdr.Close();
            return lst;
        }


        public Contact Search()
        {
            //  string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_ContactSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactTypeId", ContactTypeId);
            SqlDataReader sdr = cmd.ExecuteReader();
            Contact c = new Contact();

            while (sdr.Read())
            {

                c.PersonId = (int)sdr[0];
                c.ContactTypeId = (int)sdr[1];
                c.ContactTypeName = (string)sdr[2];
                c.contact = (int)sdr[3];
            }
            sdr.Close();
            return c;
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand("SP_ContactUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonId", PersonId);
            cmd.Parameters.AddWithValue("@ContactTypeId", ContactTypeId);
            cmd.Parameters.AddWithValue("@ContactTypeName", ContactTypeName);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.ExecuteNonQuery();
        }


        public void Delete()
        {
            // string q = "Delete CustomerData where CustomerID='" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand("SP_ContactDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactTypeId", ContactTypeId);
            cmd.ExecuteNonQuery();
        }
    }
}