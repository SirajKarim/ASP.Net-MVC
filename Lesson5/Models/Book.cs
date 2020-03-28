using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public void Add()
        {
            string a = "Insert into Book Values ('" + ISBN + "', '" + Name + "', '" + Author + "', " + Price + ")";
            SqlCommand sc = new SqlCommand(a,Connection.Get());
            sc.ExecuteNonQuery();
            
        }
        public List<Book> ShowAll()
        {
            string a = "Select * From Book";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<Book> lst = new List<Book>();
            while(sdr.Read())
            {
                Book b = new Book()
                {
                    ISBN = (string)sdr["ISBN"],
                    Name = (string)sdr["Name"],
                    Author = (string)sdr["Author"],
                    Price = (decimal)sdr["Price"]
                };
                lst.Add(b);
            }
            sdr.Close();
            return lst;

        }
        public Book Search()
        {
            string a = "Select * From Book Where ISBN='"+ISBN+"'";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            Book b = new Book();
            while (sdr.Read())
            {


                b.ISBN = (string)sdr["ISBN"];
                b.Name = (string)sdr["Name"];
                b.Author = (string)sdr["Author"];
                b.Price = (decimal)sdr["Price"];
               
              
            }
            sdr.Close();
            return b;

        }
        public void Update()
        {
            string a = "Update Book set Name='" + Name + "', Author='" + Author + "', Price=" + Price + "  Where ISBN='"+ISBN+"'";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();

        }
        public void Delete()
        {
            string a = "Delete Book  Where ISBN='" + ISBN + "'";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();

        }
        public List<Book> Sorting(string obj)
        {
            string a = "select * from Book order by "+obj;
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<Book> lst = new List<Book>();
            while (sdr.Read())
            {
                Book b = new Book()
                {
                    ISBN = (string)sdr["ISBN"],
                    Name = (string)sdr["Name"],
                    Author = (string)sdr["Author"],
                    Price = (decimal)sdr["Price"]
                };
                lst.Add(b);
            }
            sdr.Close();
            return lst;

        }
    }
}