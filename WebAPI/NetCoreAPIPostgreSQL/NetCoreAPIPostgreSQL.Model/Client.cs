using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Client
    {
        public int Id_Client { get; set; }
        public string First_Name_Client { get; set; }
        public string Second_Name_Client { get; set; }
        public string First_Last_Name_Client { get; set; }
        public string Second_Last_Name_Client { get; set; }
        public string Phone_Client { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birth_Date_Client { get; set; }
        public string Password_Client { get; set; }
        public string User_Client { get; set; }
    }
}
