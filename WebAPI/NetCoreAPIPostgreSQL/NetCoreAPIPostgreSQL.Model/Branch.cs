using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cant_Rooms { get; set; }
        public string Address { get; set; }
    }
}
