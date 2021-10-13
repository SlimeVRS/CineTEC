using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Bill
    {
        public int Id_Bill { get; set; }
        public float Total_Bill { get; set; }
        public int Id_Employee_Bill { get; set; }
        public int Id_Client_Bill { get; set; }
    }
}
