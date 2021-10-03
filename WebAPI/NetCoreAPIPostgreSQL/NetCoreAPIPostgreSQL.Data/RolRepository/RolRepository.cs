using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.RolRepository
{
    public class RolRepository : IRolRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public RolRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteRol(Rol rol)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Roles""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = rol.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Rol>> GetAllRoles()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, description
                        FROM public.""Roles"" ";
            return await db.QueryAsync<Rol>(sql, new { });
        }

        public async Task<Rol> GetRolDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, description
                        FROM public.""Roles""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
        }

        public async Task<bool> InsertRol(Rol rol)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Roles"" (name, description)
                        VALUES (@Name, @Description)";
            var response = await db.ExecuteAsync(sql, new
            {
                rol.Name,
                rol.Description
            });
            return response > 0;
        }

        public async Task<bool> UpdateRol(Rol rol)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Roles""
                        SET name = @Name,
                            description = @Description
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                rol.Id,
                rol.Name,
                rol.Description
            });
            return response > 0;
        }
    }
}
