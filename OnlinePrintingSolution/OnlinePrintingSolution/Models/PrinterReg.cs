using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class PrinterReg
    {
        public int PrinterID { get; set; }
        //public string PCompanyName { get; set; }
        public string  OwnerName { get; set; }
        //public string Email{ get; set; }
        public string Address { get; set; }
        public string City { get; set; }
      //  public string Region { get; set; }
        public string Country { get; set; }
     //   public string ProvideServices { get; set; }
     //   public int PostalCode { get; set; }
        public int Nic { get; set; }
      //  public int Fax { get; set; }



        public void Add()
        {
           // string q = "insert into PrinterReg (PCompanyName,OwnerName,Email,Address,City,Country,ProvideServices,Phone) values   ('" + PCompanyName + "','" +OwnerName + "','" + Email + "','" + City + "','" + Country + "','" + Address + "','" + Email + "','" + Phone + "')";
            SqlCommand cmd = new SqlCommand("SP_AddPrinterReg", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrinterID",PrinterID);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
            cmd.Parameters.AddWithValue("@Nic", Nic);
            
            cmd.ExecuteNonQuery();
        }
        public List<PrinterReg> ShowAll()
        {
           // string q = "Select * from PrinterReg";
            SqlCommand cmd = new SqlCommand("PrinterRegShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<PrinterReg> lst = new List<PrinterReg>();
            while (sdr.Read())
            {
                PrinterReg pr = new PrinterReg();

               pr.PrinterID = (int)sdr["PrinterId"];
               pr.OwnerName = (string)sdr["OwnerName"];
               pr.Country= (string)sdr["Country"];
               pr.Address = (string)sdr["Address"];
               pr.City= (string)sdr["City"];
               pr.Country = (string)sdr["Country"];
               lst.Add(pr);
            }
            sdr.Close();
            return lst;
        }



        public PrinterReg Search()
        {
           // string q = "Select * from PrinterReg";
            SqlCommand cmd = new SqlCommand("SP_PrinterRegSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
            SqlDataReader sdr = cmd.ExecuteReader();
            PrinterReg pr = new PrinterReg();
            while (sdr.Read())
            {

                pr.PrinterID = (int)sdr["PrinterId"];
                pr.OwnerName = (string)sdr["OwnerName"];
                pr.Country = (string)sdr["Country"];
                pr.Address = (string)sdr["Address"];
                pr.City = (string)sdr["City"];
                pr.Country = (string)sdr["Country"];
               
            }
            sdr.Close();
            return pr;
        }

        public void Delete()
        {
           // string q = "Delete PrinterReg where PrinterId='" + PrinterId + "'";
            SqlCommand cmd = new SqlCommand("SP_PrinterRegDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
          //  string q = "Update Delivery  set PCompanyName ='" + PCompanyName + "' , OwnerName ='" + OwnerName + "' , .Email ='" + Email + "' , Address='" + Address + "' , City='" + City + "' ,Country='" + Country + "' , ProvideServices='" + ProvideServices + "' , Phone='" + Phone + "' where PrinterId='" + PrinterId + "' ";
            SqlCommand cmd = new SqlCommand("SP_PrinterRegUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@OwnerName", OwnerName);
            cmd.Parameters.AddWithValue("@Nic", Nic);
            cmd.ExecuteNonQuery();
        }


    }
}