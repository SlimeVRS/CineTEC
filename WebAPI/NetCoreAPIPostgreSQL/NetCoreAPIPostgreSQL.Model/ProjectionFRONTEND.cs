using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Model
{
    // Model of projection (just for better communication with front end)
    public class ProjectionFRONTEND
    {
        public int Id_Projection { get; set; }              // Id of the projection
        public string Time_Projection { get; set; }         // Time of the projection
        public string Name_Movie_Projection { get; set; }   // Name of the movie that will be projected 
        public int Id_Room_Projection { get; set; }         // Id of the room of the projection
    }
}
