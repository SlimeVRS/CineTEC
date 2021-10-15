using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model for as eat
    public class Seat
    {
        public int Id_Seat { get; set; }        // Id of the seat
        public int Row_Seat { get; set; }       // Row of the seat
        public int Column_Seat { get; set; }    // Column of the seat
        public int State_Seat { get; set; }     // State of the seat
        public int Id_Room_Seat { get; set; }   // Id of the room where the seat is
    }
}
