using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Classification mdel
    public class Classification
    {
        public int Id_Classif { get; set; }     // Id of the classification
        public string Classif { get; set; }     // Name of the classification (eg. Adult)
    }
}
