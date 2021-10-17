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
        public int Id_Client { get; set; }                      // Id of the client
        public string First_Name_Client { get; set; }           // First name of the client
        public string Second_Name_Client { get; set; }          // Second name of the client
        public string First_Last_Name_Client { get; set; }      // First last name of the client
        public string Second_Last_Name_Client { get; set; }     // Second last of the client
        public string Phone_Client { get; set; }                // Phone number of the client

        [DataType(DataType.Date)]
        public DateTime Birth_Date_Client { get; set; }         // Birth date of the client
        public string Password_Client { get; set; }             // Password of the client
        public string User_Client { get; set; }                 // User of the client
    }
}
