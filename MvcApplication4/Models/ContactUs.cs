using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class ContactUs
    {
        [Required]
       
        public int ContactID { get; set; }
         [Display(Name = "Contact Number ")]
        public string ContactNum { get; set; }
             [Display(Name = "First Name")]
        public string FirstName { get; set; }
             [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Message { get; set; }


        public void Add()
        {
            SqlCommand cmd = new SqlCommand("AddFeedBack", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactNum", SqlDbType.Int).Value = ContactNum;
            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.Int).Value = FirstName;
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.Int).Value = LastName;
            cmd.Parameters.AddWithValue("@Message", SqlDbType.Int).Value = Message;
            cmd.ExecuteNonQuery();
        
        }

       

        public List<ContactUs> ShowAll()
        {
            List<ContactUs> lst = new List<ContactUs>();
            string q = "Select * From ContactUs";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ContactUs b = new ContactUs();

                b.ContactNum = (string)sdr[0];
                b.FirstName = (string)sdr[1];
                b.LastName = (string)sdr[2];
                b.Message = (string)sdr[3];


                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
    }
}