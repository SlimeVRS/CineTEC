using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Director model
    public class Director
    {
        public int Id_Director { get; set; }        // Id of the director
        public string Name_Director { get; set; }   // Full name of the director
    }
}
