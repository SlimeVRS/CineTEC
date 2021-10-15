using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Protagonist_Repository
{
    public interface IProtagonistRepository
    {
        Task<IEnumerable<Protagonist>> GetAllProtagonists();            // Gets all the protagonists
        Task<Protagonist> GetProtagonistDetails(int id_protagonist);    // Gets a protagonist by id
        Task<bool> InsertProtagonist(Protagonist protagonist);          // Inserts a new protagonist
        Task<bool> UpdateProtagonist(Protagonist protagonist);          // Updates a protagonist
        Task<bool> DeleteProtagonist(Protagonist protagonist);          // Deletes a protagonist
    }
}
