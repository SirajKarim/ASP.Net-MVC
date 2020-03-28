using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lesson5
{
    public class Connection
    {
        public static SqlConnection sc;

        public static SqlConnection Get()
        {
            if(sc==null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "Data Source=DESKTOP-POO8VDI;Initial Catalog=Library;Integrated Security=SSPI;";
                sc.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
                sc.Open();
            }
            return sc;
        }
    }
}