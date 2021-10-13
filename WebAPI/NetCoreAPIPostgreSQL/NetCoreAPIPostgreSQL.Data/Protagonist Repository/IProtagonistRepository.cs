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
        Task<IEnumerable<Protagonist>> GetAllProtagonists();
        Task<Protagonist> GetProtagonistDetails(int id_protagonist);
        Task<bool> InsertProtagonist(Protagonist protagonist);
        Task<bool> UpdateProtagonist(Protagonist protagonist);
        Task<bool> DeleteProtagonist(Protagonist protagonist);
    }
}
