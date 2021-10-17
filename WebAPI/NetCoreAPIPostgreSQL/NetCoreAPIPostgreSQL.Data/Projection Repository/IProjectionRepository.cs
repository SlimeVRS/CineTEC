using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Projection_Repository
{
    public interface IProjectionRepository
    {
        Task<IEnumerable<Projection>> GetAllProjections();                      // Gets all projections
        Task<Projection> GetProjectionDetails(int id_projection);               // Gets a projection using id
        Task<bool> InsertProjection(Projection projection);                     // Inserts a new projection
        Task<bool> UpdateProjection(Projection projection);                     // Updates a projection
        Task<bool> DeleteProjection(Projection projection);                     // Deletes a projection
        Task<bool> InsertProjectionFrontEnd(ProjectionFRONTEND projection);     // Inserts a projection using the name of the movie
        Task<bool> UpdateInsertionByMovieName(ProjectionFRONTEND projection);   // Updates a projection with the name of the movie
    }
}
