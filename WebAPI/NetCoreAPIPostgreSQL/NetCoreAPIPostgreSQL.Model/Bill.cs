using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Bill model
    public class Bill
    {
        public int Id_Bill { get; set; }            // Id of the model
        public float Total_Bill { get; set; }       // Total of the 
        public int Id_Employee_Bill { get; set; }   // Id of the employee
        public int Id_Client_Bill { get; set; }     // Id of the client
    }
}
