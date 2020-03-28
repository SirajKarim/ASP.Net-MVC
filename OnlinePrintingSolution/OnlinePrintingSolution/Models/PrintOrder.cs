using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution.Models
{
    public class PrintOrder
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Heigth { get; set; }
        public int Size { get; set; }
        public decimal Width { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int RequiredDate { get; set; }
        public int OrderDate { get; set; }


        public void Add()
        {
            //string q = "insert into PrintOrder (ProductId,ProductType,Size,Quantity,Price,RequiredDate,OrderDate) values   ('" + ProductId + "','" + ProductType + "','" + Size + "','" + Quantity + "','" + Price + "','" + RequiredDate + "','" + OrderDate + "')";
            SqlCommand cmd = new SqlCommand("SP_OrderDetail", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.Parameters.AddWithValue("@Heigth", Heigth);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@Width", Width);
            cmd.ExecuteNonQuery();
        }

        public List<PrintOrder> ShowAll()
        {
            //string q = "Select * from PrintOrder";
            SqlCommand cmd = new SqlCommand("OrderDetailShowAll", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<PrintOrder> lst = new List<PrintOrder>();
            while (sdr.Read())
            {
                PrintOrder po = new PrintOrder();
                po.OrderId = (int)sdr["OrderId"];
                po.ProductId = (int)sdr["ProductId"];
                po.Heigth = (decimal)sdr["Heigth"];
                po.Width = (decimal)sdr["Width"];
                po.Size = (int)sdr["Size"];
                po.Quantity = (int)sdr["Quantity"];
                po.Price = (int)sdr["Price"];
                po.RequiredDate = (int)sdr["RequiredDate"];
                po.OrderDate = (int)sdr["OrderDate"];
                lst.Add(po);
            }
            sdr.Close();
            return lst;
        }



        public PrintOrder Search()
        {
            //string q = "Select * from PrintOrder";
            SqlCommand cmd = new SqlCommand("SP_OrderDetailSearch", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            SqlDataReader sdr = cmd.ExecuteReader();
            PrintOrder po = new PrintOrder();
            while (sdr.Read())
            {
               
                po.OrderId = (int)sdr["OrderId"];
                po.ProductId = (int)sdr["ProductId"];
                po.Heigth = (decimal)sdr["Heigth"];
                po.Width = (decimal)sdr["Width"];
                po.Size = (int)sdr["Size"];
                po.Quantity = (int)sdr["Quantity"];
                po.Price = (int)sdr["Price"];
                po.RequiredDate = (int)sdr["RequiredDate"];
                po.OrderDate = (int)sdr["OrderDate"];
                
            }
            sdr.Close();
            return po;
        }

        public void Delete()
        {
            //string q = "Delete PrintOrder where OrderId='" + OrderId + "'";
            SqlCommand cmd = new SqlCommand("SP_OrderDetailDelete", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.ExecuteNonQuery();
        }

        public void Update()
        {

            SqlCommand cmd = new SqlCommand("SP_OrderDetailUpdate", connection.GetConnection());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Heigth", Heigth);
            cmd.Parameters.AddWithValue("@Size", Size);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@RequiredDate", RequiredDate);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            cmd.Parameters.AddWithValue("@Width", Width);
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            cmd.ExecuteNonQuery();
        }

        

    }
}