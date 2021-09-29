using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string First_Last_Name { get; set; }
        public string Second_Last_Name { get; set; }
        public string Phone { get; set; }
        public string Birth_Date { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
    }
}
