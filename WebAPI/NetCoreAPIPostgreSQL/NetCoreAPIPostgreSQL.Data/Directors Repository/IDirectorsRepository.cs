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
        Task<IEnumerable<Director>> GetAllDirectors();          // Gets all the directors
        Task<Director> GetDirectorDetails(int id_director);     // Gets a director using id
        Task<bool> InsertDirector(Director director);           // Inserts a new director
        Task<bool> UpdateDirector(Director director);           // Updates a director
        Task<bool> DeleteDirector(Director director);           // Deletes a director
    }
}
