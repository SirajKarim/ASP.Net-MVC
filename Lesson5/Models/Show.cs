using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Show
    {
        public int Show_ID { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public int Movie_ID { get; set; }
        public List<Show> Shows(int m)
        {
            SqlCommand sc = new SqlCommand("Select * from Show where Movie_ID ="+m, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();
            List<Show> lst = new List<Show>();
            while(sdr.Read())
            {
                lst.Add(new Show()
                {
                    Show_ID = (int)sdr[0],
                    Name = (string)sdr[1],
                    Time=(string)sdr[2],
                    Movie_ID=(int)sdr[3]

                });
            }
            sdr.Close();
            return lst;
        }
        public List<Show> ShowAll()
        {
            SqlCommand sc = new SqlCommand("Select * from Show ", Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();
            List<Show> lst = new List<Show>();
            while (sdr.Read())
            {
                lst.Add(new Show()
                {
                    Show_ID = (int)sdr[0],
                    Name = (string)sdr[1],
                    Time = (string)sdr[2],
                    Movie_ID = (int)sdr[3]

                });
            }
            return lst;
        }

    }
}