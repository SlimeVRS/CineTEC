using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Client_Repository
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientDetails(int id);
        Task<bool> InsertClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(Client client); 
    }
}
