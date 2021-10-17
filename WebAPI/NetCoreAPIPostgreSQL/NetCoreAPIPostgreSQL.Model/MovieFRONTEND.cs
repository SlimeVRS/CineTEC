using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model of the movie (just for better communication with the front end)
    public class MovieFRONTEND
    {
        public int Id_Movie { get; set; }                   // Id of the movie
        public string Name_Movie { get; set; }              // Name of the movie
        public string Duration_Movie { get; set; }          // Duration of the movie
        public string Poster_Movie { get; set; }            // Poster of the movie
        public int Price_Elder_Movie { get; set; }          // Elder price of the movie
        public int Price_Adult_Movie { get; set; }          // Adult price of the movie
        public int Price_Kid_Movie { get; set; }            // Kid price of the movie
        public string Name_Director_Movie { get; set; }     // Director's name of the movie
        public string Classif_Movie { get; set; }           // Classification of the movie
        public string Name_Protagonist_Movie { get; set; }  // Protagonist's name of the movie
    }
}
