using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    public class Movie
    {
        public int Id_Movie { get; set; }
        public string Name_Movie { get; set; }
        public string Duration_Movie { get; set; }
        public string Poster_Movie { get; set; }
        public int Price_Elder_Movie { get; set; }
        public int Price_Adult_Movie { get; set; }
        public int Price_Kid_Movie { get; set; }
        public int Id_Director_Movie { get; set; }
        public int Id_Classif_Movie { get; set; }
        public int Id_Protagonist_Movie { get; set; }
    }
}
