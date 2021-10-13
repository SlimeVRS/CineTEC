using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class RoomFRONTEND
    {
        public int Id_Room { get; set; }
        public int Capacity_Room { get; set; }
        public int Rows_Room { get; set; }
        public int Columns_Room { get; set; }
        public string Name_Branch_Room { get; set; }
    }
}
