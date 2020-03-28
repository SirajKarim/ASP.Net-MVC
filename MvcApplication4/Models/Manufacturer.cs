using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Manufacturer
    {
        [Required]
        [Display(Name = " Manufacturer ID")]
        public int ManufacturerID { get; set; }
         [Display(Name = "Manufacturer Name")]
        public string ManufacturerName{ get; set; }
        public string Address { get; set; }
         public string Email { get; set; }

         public string Contact_No { get; set; }
         public string Detail { get; set; }
        

         public void Add()
        {
            SqlCommand cmd = new SqlCommand("AddManufacturer", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mID", SqlDbType.Int).Value = ManufacturerID;
            cmd.Parameters.AddWithValue("@mName", SqlDbType.Int).Value = ManufacturerName;
            cmd.Parameters.AddWithValue("@Address", SqlDbType.Int).Value = Address;
            cmd.Parameters.AddWithValue("@Email", SqlDbType.Int).Value = Email;
            cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.Int).Value = Contact_No;
            cmd.Parameters.AddWithValue("@Detail", SqlDbType.Int).Value = Detail;



            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            string q = "Delete Manufacturer Where Name= '" + ManufacturerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void Update()
        {
            string q = "Update Product Set Name= '" + ManufacturerName + "',Contact_No= " + Contact_No + " Where ManufacturerID='" + ManufacturerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Manufacturer> ShowAll()
        {
            List<Manufacturer> lst = new List<Manufacturer>();
            string q = "Select * From Manufacturer";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Manufacturer b = new Manufacturer();
                b.ManufacturerID = (int)sdr[0];
                b.ManufacturerName = (string)sdr[1];
                b.Address = (string)sdr[2];
                b.Email = (string)sdr[3];
                b.Contact_No = (string)sdr[4];
               b.Detail = (string)sdr[5];
        
                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Manufacturer Search()
        {

            Manufacturer b = new Manufacturer();

            string q = "select * from Manufacturer  where ManufacturerID='" + ManufacturerID + "'";
            SqlCommand sc = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.ManufacturerID = (int)sdr[0];
                b.ManufacturerName = (string)sdr[1];
                b.Address = (string)sdr[2];
                b.Email = (string)sdr[3];
                b.Contact_No = (string)sdr[4];
            }
            sdr.Close();
            return b;

        }
    }
}

    