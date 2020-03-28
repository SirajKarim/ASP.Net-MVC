using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlinePrintingSolution
{
    public class connection
    {
        public static SqlConnection sc;
        public static SqlConnection GetConnection()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = "Data Source=MUHAMMADSIRAJ\\SQLEXPRESS; Initial Catalog=OPS; Integrated Security=SSPI;";
                sc.Open();
            }
            return sc;
        }
    }
}