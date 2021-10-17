using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model of protagonist
    public class Protagonist
    {
        public int Id_Protagonist { get; set; }         // Id of the protagonist
        public string Name_Protagonist { get; set; }    // Full name of the protagonist
    }
}
