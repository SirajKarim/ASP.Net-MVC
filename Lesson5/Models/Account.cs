using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson5.Models
{
    public class Account

    { 
        public int ID { get; set; }
        public string Password { get; set; }
        public static bool Check { get; set; }
    }
}