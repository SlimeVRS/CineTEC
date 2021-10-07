using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Poster { get; set; }
        public int Price_Elder { get; set; }
        public int Price_Adult { get; set; }
        public int Price_Kid { get; set; }
        public int Id_Director { get; set; }
        public int Id_Classif { get; set; }
        public int Id_Protagonist { get; set; }
    }
}
