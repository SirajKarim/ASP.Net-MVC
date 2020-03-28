using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayName("Upload")]
        public string Image_Path { get; set; }

        public void Add()
        {
            string a = "Insert into Student Values ('" + Name + "', '" + Image_Path+ "')";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            sc.ExecuteNonQuery();
        }
        public List<Student> ShowAll()
        {
            string a = "Select * From Student";
            SqlCommand sc = new SqlCommand(a, Connection.Get());
            SqlDataReader sdr = sc.ExecuteReader();

            List<Student> lst = new List<Student>();
            while (sdr.Read())
            {
                Student b = new Student()
                {
                    ID = (int)sdr["Student_ID"],
                    Name = (string)sdr["Name"],
                    Image_Path = (string)sdr["Image_Url"]
                };
                lst.Add(b);
            }
            sdr.Close();
            return lst;

        }

    }
}