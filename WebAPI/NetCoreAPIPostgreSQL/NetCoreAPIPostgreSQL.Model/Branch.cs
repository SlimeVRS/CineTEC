using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Branch Model
    public class Branch
    {
        public int Id_Branch { get; set; }              // Id of the branch
        public string Name_Branch { get; set; }         // Name of the branch
        public int Cant_Rooms_Branch { get; set; }      // Rooms quantity of the branch
        public string Address_Branch { get; set; }      // Address of the branch
    }
}
