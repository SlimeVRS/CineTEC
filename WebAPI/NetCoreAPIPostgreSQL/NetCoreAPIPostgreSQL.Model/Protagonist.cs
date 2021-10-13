using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Protagonist
    {
        public int Id_Protagonist { get; set; }
        public string First_Name_Protagonist { get; set; }
        public string Second_Name_Protagonist { get; set; }
        public string First_Last_Name_Protagonist { get; set; }
        public string Second_Last_Name_Protagonist { get; set; }
    }
}
