using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class ShowProjection
    {
        public string name_movie { get; set; }
        public string duration_movie { get; set; }
        public string poster_movie { get; set; }
        public string name_protagonist { get; set; }
        public string name_director{ get; set; }
        public int price_adult_movie { get; set; }
        public int price_kid_movie { get; set; } 
        public int price_elder_movie { get; set; }
        public int id_room { get; set; }
        public string name_branch { get; set; }
    }
}
