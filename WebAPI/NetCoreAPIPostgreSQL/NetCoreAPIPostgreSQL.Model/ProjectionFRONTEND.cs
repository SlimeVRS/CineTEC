using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class ProjectionFRONTEND
    {
        public int Id_Projection { get; set; }
        public string Time_Projection { get; set; }
        public string Name_Movie_Projection { get; set; }
        public int Id_Room_Projection { get; set; }
    }
}
