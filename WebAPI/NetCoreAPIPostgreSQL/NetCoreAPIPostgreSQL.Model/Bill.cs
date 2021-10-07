using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Bill
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public int Id_Employee { get; set; }
        public int Id_Client { get; set; }
    }
}
