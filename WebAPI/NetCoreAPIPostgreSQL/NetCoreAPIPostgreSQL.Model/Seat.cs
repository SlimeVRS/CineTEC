using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int State { get; set; }
    }
}
