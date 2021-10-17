using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model of te room
    public class Room
    {
        public int Id_Room { get; set; }            // Id of the room
        public int Capacity_Room { get; set; }      // Capacity of the room
        public int Rows_Room { get; set; }          // Rows of the room
        public int Columns_Room { get; set; }       // Columns of the room
        public int Id_Branch_Room { get; set; }     // Branch id where the room is
    }
}
