using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model of the rol
    public class Rol
    {
        public int Id_Rol { get; set; }                 // Id of the rol 
        public string Name_Rol { get; set; }            // Name of the rol
        public string Description_Rol { get; set; }     // Description of the rol
    }
}
