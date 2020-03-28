using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class DeliveryBoyReg
    {
        public int DBoyID { get; set; }
        public string DBoyName { get; set; }
        public string DBAddress { get; set; }
        public string DBCity { get; set; }
        public int DBNic { get; set; }
        public string DBCountry { get; set; }

        public void Add()
        {
            //string q = "insert into DBoyDetail (DBoyName,DContactNo,DContactTitle,DBCity,DBNic,DBEmail,DBAddress) values   ('" + DBoyName + "','" + DContactNo + "','" + DContactTitle + "','" + DBCity + "','" + DBNic + "','" + DBEmail + "','" + DBAddress + "')";
            SqlCommand cmd = new SqlCommand("SP_AddDBoyDetail", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DBoyID",DBoyID);
            cmd.Parameters.AddWithValue("@DBoyName",DBoyName);
            cmd.Parameters.AddWithValue("@DBAddress",DBAddress);
            cmd.Parameters.AddWithValue("@DBCity",DBCity);
            cmd.Parameters.AddWithValue("@DBCountry",DBCountry);
            cmd.Parameters.AddWithValue("@DBNic", DBNic);
            cmd.ExecuteNonQuery();
        }
        public List<DeliveryBoyReg> ShowAll()
        {
            //string q = "Select * from DBoyDetail";
            SqlCommand cmd = new SqlCommand("SP_DBoyDetailShowAll", connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            List<DeliveryBoyReg> lst = new List<DeliveryBoyReg>();
            while (sdr.Read())
            {
                DeliveryBoyReg db = new DeliveryBoyReg();

                db.DBoyID = (int)sdr[0];
                db.DBoyName = (string)sdr[1];
                db.DBCity = (string)sdr[2];
                db.DBNic = (int)sdr[3];
                db.DBCountry = (string)sdr[4];
                db.DBAddress = (string)sdr[5];
                lst.Add(db);
            }
            sdr.Close();
            return lst;
        }
        public DeliveryBoyReg Search()
        {
           // string q = "Select * from DBoyDetail";
            SqlCommand cmd = new SqlCommand("SP_DBoySearch", connection.GetConnection());
            cmd.Parameters.AddWithValue("@DBoyID", DBoyID);
            SqlDataReader sdr = cmd.ExecuteReader();
            DeliveryBoyReg db = new DeliveryBoyReg();
            while (sdr.Read())
            {
               

                db.DBoyID = (int)sdr[0];
                db.DBoyName = (string)sdr[1];
                db.DBCity = (string)sdr[2];
                db.DBNic = (int)sdr[3];
                db.DBCountry = (string)sdr[4];
                db.DBAddress = (string)sdr[5];
               
            }
            sdr.Close();
            return db;
        }
        public void Update()
        {
            //string q = "Update DBoyDetail set DBoyID= DBoyName='" + DBoyName + "' , DContactNo='" + DContactNo + "' , DContactTitle='" + DContactTitle + "' , DBCity='" + DBCity + "'  , DBNic='" + DBNic + "' , DBEmail='" + DBEmail + "' , DBAddress= '" + DBAddress + "' where DBoyID='" + DBoyID + "'  where  DBoyID ='" + DBoyID + "'  ";
            SqlCommand cmd = new SqlCommand("SP_DBoyUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DBoyID",DBoyID);
            cmd.Parameters.AddWithValue("@DBoyName",DBoyName);
            cmd.Parameters.AddWithValue("@DBAddress",DBAddress);
            cmd.Parameters.AddWithValue("@DBCity",DBCity);
            cmd.Parameters.AddWithValue("@DBCountry",DBCountry);
            cmd.Parameters.AddWithValue("@DBNic", DBNic);
            cmd.ExecuteNonQuery();
        }
        public void Delete()
        {
            //string q = "Delete DBoyDetail where DBoyID='" + DBoyID + "'";
            SqlCommand cmd = new SqlCommand("SP_DBoyDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DBoyID", DBoyID);
            cmd.ExecuteNonQuery();
        }
    }
}