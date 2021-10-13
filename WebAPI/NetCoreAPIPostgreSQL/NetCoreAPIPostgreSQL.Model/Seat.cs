using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Seat
    {
        public int Id_Seat { get; set; }
        public int Row_Seat { get; set; }
        public int Column_Seat { get; set; }
        public int State_Seat { get; set; }
        public int Id_Room_Seat { get; set; }
    }
}
