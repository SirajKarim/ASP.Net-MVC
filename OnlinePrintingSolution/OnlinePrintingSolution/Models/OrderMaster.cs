using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class OrderMaster
    {

        public int OrderId { get; set; }
        public int CltId { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int OrderDate { get; set; }
        public int RequiredDate { get; set; }
        public int ProductId { get; set; }
        public int PrinterId { get; set; }
        public string ProductType { get; set; }


        public void Add()
        {
          //  string q = "insert into Delivery (CustomerID, OrderID,DEmployeeName ,ShipCountry,ShipCity,ShipAddress,OrderDate,RequiredDate,ShipedDate) values   ('" + CustomerId + "','" + OrderId + "','" + DEmployeeName + "','" + ShipCountry + "','" + ShipCity + "','" + ShipAddress + "','" + OrderDate + "','" + RequiredDate + "','" + ShipedDate + "')";
            SqlCommand cmd = new SqlCommand("SP_OrderMaster", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.Parameters.AddWithValue("@CltId", CltId);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            cmd.Parameters.AddWithValue("@PrinterId", PrinterId);
            cmd.ExecuteNonQuery();
        }
        public List<OrderMaster> ShowAll()
        {
           // string q = "Select * from Delivery";
            SqlCommand cmd = new SqlCommand("OrderMAsterShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<OrderMaster> lst = new List<OrderMaster>();
            while (sdr.Read())
            {
                OrderMaster Om = new OrderMaster();

               Om.OrderId = (int)sdr["OrderId"];
               Om.CltId = (int)sdr["CltId"];
               Om.Size= (int)sdr["Size"];
               Om.Quantity=(int)sdr["Quantity"];
               Om .Price= (int)sdr["Price"];
               Om.OrderDate=(int)sdr["OrderDate"];
               Om .RequiredDate= (int)sdr["RequiredDate"];
               Om.PrinterId = (int)sdr["PrinterId"];
                lst.Add(Om);
            }
            sdr.Close();
            return lst;
        }

        public OrderMaster Search()
        {
           // string q = "Select * from Delivery";
            SqlCommand cmd = new SqlCommand("SP_OrderMasterSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId",OrderId);
            SqlDataReader sdr = cmd.ExecuteReader();

            OrderMaster Om = new OrderMaster();
            while (sdr.Read())
            {


                Om.OrderId = (int)sdr["OrderId"];
                Om.CltId = (int)sdr["CltId"];
                Om.Size = (int)sdr["Size"];
                Om.Quantity = (int)sdr["Quantity"];
                Om.Price = (int)sdr["Price"];
                Om.OrderDate = (int)sdr["OrderDate"];
                Om.RequiredDate = (int)sdr["RequiredDate"];
                Om.PrinterId = (int)sdr["PrinterId"];

            }
            sdr.Close();
            return Om;
        }

        public void Delete()
        {
            //string q = "Delete Delivery where DEmployeeId='" + DEmployeeId + "'";
            SqlCommand cmd = new SqlCommand("SP_OrderMasterDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {
            SqlCommand cmd = new SqlCommand("SP_OrderMasterUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
          //  cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.Parameters.AddWithValue("@CltId", CltId);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@ProductType", ProductType);
            cmd.Parameters.AddWithValue("@PrinterId", PrinterId);

            cmd.ExecuteNonQuery();
        }


    }
}