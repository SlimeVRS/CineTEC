using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Employee
    {
        public int Id_Employee { get; set; }
        public string First_Name_Employee { get; set; }
        public string Second_Name_Employee { get; set; }
        public string First_Last_Name_Employee { get; set; }
        public string Second_Last_Name_Employee { get; set; }
        public string Phone_Employee { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birth_Date_Employee { get; set; }
        [DataType(DataType.Date)]
        public DateTime Admission_Date_Employee { get; set; }
        public string Password_Employee { get; set; }
        public string User_Employee { get; set; }
        public int Id_Branch_Employee { get; set; }
        public int Id_Rol_Employee { get; set; }
    }
}
