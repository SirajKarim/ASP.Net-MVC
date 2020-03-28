using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class MaterialType
    {
        public int MaterialTypId { get; set; }
        public string MaterialName { get; set; }


        public void Add()
        {
            //string q = "insert into CustomerData (CustomerName,CompanyName,ContactNo,ContactTitle,City,Country,Nic,Email,Address) values   ('" + CustomerName + "','" + CompanyName + "','" + ContactNo + "','" + ContactTitle + "','" + City + "','" + Country + "','" + Nic + "','" + Email + "','" + Address + "')";
            SqlCommand cmd = new SqlCommand("SP_Add1Material", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaterialTypId", MaterialTypId);
            cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
            cmd.ExecuteNonQuery();
        }
        public List<MaterialType> ShowAll()
        {
            // string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_MaterialShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<MaterialType> lst = new List<MaterialType>();
            while (sdr.Read())
            {
                MaterialType mt = new MaterialType();

               mt.MaterialTypId = (int)sdr[0];
               mt.MaterialName = (string)sdr[1];

                lst.Add(mt);
            }
            sdr.Close();
            return lst;
        }


        public MaterialType Search()
        {
            //  string q = "Select * from CustomerData";
            SqlCommand cmd = new SqlCommand("SP_MaterialSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaterialTypId", MaterialTypId);
            SqlDataReader sdr = cmd.ExecuteReader();
            MaterialType mt = new MaterialType();

            while (sdr.Read())
            {

                mt.MaterialTypId = (int)sdr[0];
                mt.MaterialName = (string)sdr[1];
            }
            sdr.Close();
            return mt;
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand("SP_MaterialUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaterialTypId", MaterialTypId);
            cmd.Parameters.AddWithValue("@MaterialName", MaterialName);
            cmd.ExecuteNonQuery();
        }


        public void Delete()
        {
            // string q = "Delete CustomerData where CustomerID='" + CustomerID + "'";
            SqlCommand cmd = new SqlCommand("SP_MaterialDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaterialTypId", MaterialTypId);
            cmd.ExecuteNonQuery();
        }
    }
}