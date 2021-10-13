using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Directors_Repository
{
    public interface IDirectorsRepository
    {
        Task<IEnumerable<Director>> GetAllDirectors();
        Task<Director> GetDirectorDetails(int id_director);
        Task<bool> InsertDirector(Director director);
        Task<bool> UpdateDirector(Director director);
        Task<bool> DeleteDirector(Director director);
    }
}
