using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Projection
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int Id_Movie { get; set; }
        public int Id_Room { get; set; }
    }
}
