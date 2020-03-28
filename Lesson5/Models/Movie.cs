using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Movie
    {
        public int Movie_ID { get; set; }
        public string Name { get; set; }
        public List<Movie> Show()
        {
            
            SqlCommand sc = new SqlCommand("Select * from Movie", Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();
            List<Movie> lst = new List<Movie>();
            while(sdr.Read())
            {
                lst.Add(new Movie()
                {
                    Movie_ID = (int)sdr[0],
                    Name = (string)sdr[1]
                });
            }
            sdr.Close();
            return lst;
        }
    }
}