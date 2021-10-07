using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Id_Branch { get; set; }
    }
}
