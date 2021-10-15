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
        Task<IEnumerable<Projection>> GetAllProjections();
        Task<Projection> GetProjectionDetails(int id_projection);
        Task<bool> InsertProjection(Projection projection);
        Task<bool> UpdateProjection(Projection projection);
        Task<bool> DeleteProjection(Projection projection);
        Task<bool> InsertProjectionFrontEnd(ProjectionFRONTEND projection);
        Task<bool> UpdateInsertionByMovieName(ProjectionFRONTEND projection);
    }
}
