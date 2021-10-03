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
        Task<IEnumerable<Rol>> GetAllRoles();
        Task<Rol> GetRolDetails(int id);
        Task<bool> InsertRol(Rol movie);
        Task<bool> UpdateRol(Rol movie);
        Task<bool> DeleteRol(Rol movie);
    }
}
