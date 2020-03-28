using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Product
    {
        [Required]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string Product_Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Price Each")]
        public int PriceEach { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
      



        public void Add()
        {
            string q = "Insert Into Product Values(" + ProductID + ",'" + Product_Name + "','" + Description + "'," + PriceEach + ",'" + Category + "'," + Quantity + ")";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            string q = "Delete Product Where Name= '" + ProductID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        public void Update()
        {
            string q = "Update Product Set Name= '" + Product_Name + "',Description='" + Description + "',PriceEach=" + PriceEach + "',Category='" + Category + "' Where ProductID='" + ProductID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }

        public List<Product> ShowAll()
        {
            List<Product> lst = new List<Product>();
            string q = "Select * From Product";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Product b = new Product();
                b.ProductID = (int)sdr[0];
                b.Product_Name = (string)sdr[1];
                b.Description = (string)sdr[2];
                b.PriceEach = (int)sdr[3];
                b.Category = (string)sdr[4];
                b.Quantity = (int)sdr[5];
                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Product Search()
        {

            Product b = new Product();

            string q = "select * from Product  where ProductID='" + ProductID + "'";
            SqlCommand sc = new SqlCommand(q,Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.ProductID = (int)sdr[0];
                b.Product_Name = (string)sdr[1];
                b.Description = (string)sdr[2];
                b.PriceEach = (int)sdr[3];
                b.Category = (string)sdr[4];
                b.Quantity = (int)sdr[5];
            }
            sdr.Close();
            return b;

        }
    }
}
