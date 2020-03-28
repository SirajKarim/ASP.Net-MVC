using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayName("Student Category")]
        public int St_Cateogry_ID { get; set; }


        public void Add()
        {
            SqlCommand sc = new SqlCommand("Add_Student", Connection.Get());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Name", Name);
            sc.Parameters.AddWithValue("@St_Cat_ID", St_Cateogry_ID);
            sc.ExecuteNonQuery();

        }
        public List<Students> ShowAll()
        {
            string a = "Select * From Students";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<Students> lst = new List<Students>();
            while (sdr.Read())
            {
                Students b = new Students()
                {
                    ID = (int)sdr[0],
                    Name = (string)sdr[1],
                    St_Cateogry_ID = (int)sdr[2]
                };
                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
    }
}