using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Shop
    {
        [Required]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string Product_Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public int Total { get; set; }
        [Display(Name = " Upload Image")]
        public string ImagePath { get; set; }



        public void AddToDatabase()
        {

            SqlCommand cmd = new SqlCommand("AddProduct", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", SqlDbType.Int).Value = ProductID;
            cmd.Parameters.AddWithValue("@Product_Name", SqlDbType.Int).Value = Product_Name;
            cmd.Parameters.AddWithValue("@Description", SqlDbType.Int).Value = Description;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Int).Value = Price;
            cmd.Parameters.AddWithValue("@ImagePath", SqlDbType.Int).Value = ImagePath;




            cmd.ExecuteNonQuery();
        }


        public List<Shop> ShowonShop()
        {
            List<Shop> lst = new List<Shop>();
            string q = "Select * From CartProduct";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Shop s = new Shop();
                s.ProductID = (int)sdr[0];
                s.Product_Name = (string)sdr[1];
                s.Description = (string)sdr[2];
                s.Price = (int)sdr[3];
                s.ImagePath = (string)sdr[4];
                lst.Add(s);
            }

            sdr.Close();
            return lst;


        }
        public void Update()
        {
            SqlCommand cmd = new SqlCommand("AddProduct", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", SqlDbType.Int).Value = ProductID;
            cmd.Parameters.AddWithValue("@Product_Name", SqlDbType.Int).Value = Product_Name;
            cmd.Parameters.AddWithValue("@Description", SqlDbType.Int).Value = Description;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Int).Value = Price;
            cmd.Parameters.AddWithValue("@ImagePath", SqlDbType.Int).Value = ImagePath;
            cmd.ExecuteNonQuery();


        }
        public Shop Search()
        {

            Shop b = new Shop();

            string q = "select * from CartProduct  where Product_ID='" + ProductID + "'";
            SqlCommand sc = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Shop s = new Shop();
                s.ProductID = (int)sdr[0];
                s.Product_Name = (string)sdr[1];
                s.Description = (string)sdr[2];
                s.Price = (int)sdr[3];
                s.ImagePath = (string)sdr[4];

            }
            sdr.Close();
            return b;


            //}
        }
    }
}

