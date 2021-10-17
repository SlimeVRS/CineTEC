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
        Task<IEnumerable<Client>> GetAllClients();                              // Gets all clients
        Task<Client> GetClientDetails(int id_client);                           // Gets a client using id
        Task<bool> InsertClient(Client client);                                 // Inserts a new client
        Task<bool> UpdateClient(Client client);                                 // Updates a client
        Task<bool> DeleteClient(Client client);                                 // Deletes a client
        Task<Client> GetClientByUserPassword(string user, string password);     // Gets a client using the password and user
    }
}
