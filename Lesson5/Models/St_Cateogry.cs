using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class St_Cateogry
    {
        public int St_Cat_ID { get; set; }
        public string Cat_Name { get; set; }

        public List<St_Cateogry> ShowAll()
        {
            SqlCommand sc = new SqlCommand("Get_St_Catehogry", Connection.Get());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            List<St_Cateogry> lst = new List<St_Cateogry>();
            while (sdr.Read())
            {
                lst.Add(new St_Cateogry()
                {
                   St_Cat_ID = (int)sdr[0],
                    Cat_Name = (string)sdr[1]
                   
                });
            }
            sdr.Close();
            return lst;

        }

    }
}