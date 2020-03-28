using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4
{
    public class Connection
    {
        static SqlConnection sc;

        public static SqlConnection GetConnection()
        {
            if (sc == null)
            {
                sc = new SqlConnection();
                sc.ConnectionString = " Data Source=MUHAMMADSIRAJ\\SQLEXPRESS; Initial Catalog=Sports Shop; Integrated Security=SSPI";
                sc.Open();
            }
            return sc;





        }
    }
}