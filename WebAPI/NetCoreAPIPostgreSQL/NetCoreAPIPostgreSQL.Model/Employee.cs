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
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string First_Last_Name { get; set; }
        public string Second_Last_Name { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birth_Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Admission_Date { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
    }
}
