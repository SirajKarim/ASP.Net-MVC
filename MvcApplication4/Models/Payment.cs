using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Payment
    {
        public int CostummerID { get; set; }
        public int Amount { get; set; }
        public string PaymentDate { get; set; }

         public void Add()
        {
            ////string q = "Insert Into Payment Values(" + CostummerID + "," + Amount + ",'" + PaymentDate + "')";
            ////SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            ////cmd.ExecuteNonQuery();


         

            //    SqlCommand cmd = new SqlCommand("Add_Player_Registration", Connection.GetConnection());
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@Player_ID", SqlDbType.Int).Value = player_ID;
            //    cmd.Parameters.AddWithValue("@First_Name", SqlDbType.Int).Value = First_Name;
            //    cmd.Parameters.AddWithValue("@Last_Name", SqlDbType.Int).Value = Last_Name;
            //    cmd.Parameters.AddWithValue("@Age", SqlDbType.Int).Value = Age;
            //    cmd.Parameters.AddWithValue("@Contact_No", SqlDbType.Int).Value = Contact_No;
            //    cmd.Parameters.AddWithValue("@Email", SqlDbType.Int).Value = Email;
            //    cmd.Parameters.AddWithValue("@Join_Date", SqlDbType.Int).Value = Join_Date;
            //    cmd.Parameters.AddWithValue("@Address", SqlDbType.Int).Value = Address;
            //    cmd.Parameters.AddWithValue("@CNIC", SqlDbType.Int).Value = CNIC;
            //    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Int).Value = Gender;
            //    cmd.Parameters.AddWithValue("@Salarey", SqlDbType.Int).Value = Salarey;
            //    cmd.ExecuteNonQuery();


            







        }

        public void Delete()
        {
            string q = "Delete Payment Where Name= '" + CostummerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void Update()
        {
            string q = "Update Payment Set Amount= " + Amount + ",PaymentDate='" + PaymentDate + "' Where CostummerID='" + CostummerID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Payment> ShowAll()
        {
            List<Payment> lst = new List<Payment>();
            string q = "Select * From Payment";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Payment b = new Payment();
                b.CostummerID = (int)sdr[0];
                b.Amount = (int)sdr[1];
                b.PaymentDate = (string)sdr[2];
               
                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Payment Search()
        {

            Payment b = new Payment();

            string q = "select * from Payment  where CostummerID='" + CostummerID + "'";
            SqlCommand sc = new SqlCommand(q,Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.CostummerID = (int)sdr[0];
                b.Amount = (int)sdr[1];
                b.PaymentDate = (string)sdr[2];
             
            }
            sdr.Close();
            return b;

        }
    }
    }
