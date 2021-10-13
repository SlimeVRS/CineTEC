using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Director
    {
        public int Id_Director { get; set; }
        public string First_Name_Director { get; set; }
        public string Second_Name_Director { get; set; }
        public string First_Last_Name_Director { get; set; }
        public string Second_Last_Name_Director { get; set; }
    }
}
