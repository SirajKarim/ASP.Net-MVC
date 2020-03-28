using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }
        [Display(Name = "Birth Date")]
        public String BirthDate { get; set; }
         [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string HireDate { get; set; }


        public void Add()
        {
            

            SqlCommand cmd = new SqlCommand("AddEmployee", Connection.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeID", SqlDbType.Int).Value = EmployeeID;
            cmd.Parameters.AddWithValue("@BirthDate", SqlDbType.Int).Value = BirthDate;
            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.Int).Value = FirstName;
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.Int).Value = LastName;
            cmd.Parameters.AddWithValue("@Gender", SqlDbType.Int).Value = Gender;
            cmd.Parameters.AddWithValue("@HireDate", SqlDbType.Int).Value = HireDate;



            cmd.ExecuteNonQuery();
        }

        public void Delete()
        {
            string q = "Delete Employee Where Name= '" + EmployeeID + "'";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            cmd.ExecuteNonQuery();
        }


        //public void Update()
        //{
        //    string q = "Update Employee Set Name= '" + +"',BirtDate='" + BirtDate + "',FirstName= " + Contact_No + " Where EmployeeID='" + EmployeeID + "'";
        //    SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
        //    cmd.ExecuteNonQuery();
        //}

        public List<Employee> ShowAll()
        {
            List<Employee> lst = new List<Employee>();
            string q = "Select * From Employee";
            SqlCommand cmd = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Employee b = new Employee();
                b.EmployeeID= (int)sdr[0];
                b.BirthDate = (string)sdr[1];
                b.FirstName = (string)sdr[2];
                b.LastName = (string)sdr[3];
                b.Gender = (string)sdr[4];
                b.HireDate = (string)sdr[5];

                lst.Add(b);
            }
            sdr.Close();
            return lst;
        }
        public Employee Search()
        {

            Employee b = new Employee();

            string q = "select * from Employee  where EmployeeID='" + EmployeeID + "'";
            SqlCommand sc = new SqlCommand(q, Connection.GetConnection());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.EmployeeID = (int)sdr[0];
                b.BirthDate = (string)sdr[1];
                b.FirstName = (string)sdr[2];
                b.LastName = (string)sdr[3];
                b.Gender = (string)sdr[4];
                b.HireDate = (string)sdr[5];
            }
            sdr.Close();
            return b;

        }
    }
}