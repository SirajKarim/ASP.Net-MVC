using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Admin
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public static bool C { get; set; }
        public bool Check()
        {
            return UserID == 1 && Password == "abc";
        }


    }
}