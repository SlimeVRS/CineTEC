using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.RolRepository
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> GetAllRoles();   // Gets all the roles
        Task<Rol> GetRolDetails(int id_rol);    // Gets a rol by id
        Task<bool> InsertRol(Rol movie);        // Inserts a new rol
        Task<bool> UpdateRol(Rol movie);        // Updates a rol
        Task<bool> DeleteRol(Rol movie);        // Deletes a rol
    }
}
