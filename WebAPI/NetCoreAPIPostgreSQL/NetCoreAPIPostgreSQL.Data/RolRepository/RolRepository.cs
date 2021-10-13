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
                        WHERE id_rol = @Id_Rol";
            var response = await db.ExecuteAsync(sql, new { Id_Rol = rol.Id_Rol });
            return response > 0;
        }

        public async Task<IEnumerable<Rol>> GetAllRoles()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_rol, name_rol, description_rol
                        FROM public.""Roles"" ";
            return await db.QueryAsync<Rol>(sql, new { });
        }

        public async Task<Rol> GetRolDetails(int id_rol)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_rol, name_rol, description_rol
                        FROM public.""Roles""
                        WHERE id_rol = @Id_Rol";
            return await db.QueryFirstOrDefaultAsync<Rol>(sql, new { Id_Rol = id_rol });
        }

        public async Task<bool> InsertRol(Rol rol)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Roles"" (name_rol, description_rol)
                        VALUES (@Name_Rol, @Description_Rol)";
            var response = await db.ExecuteAsync(sql, new
            {
                rol.Name_Rol,
                rol.Description_Rol
            });
            return response > 0;
        }

        public async Task<bool> UpdateRol(Rol rol)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Roles""
                        SET name_rol = @Name_Rol,
                            description_rol = @Description_Rol
                        WHERE id_rol = @Id_Rol";
            var response = await db.ExecuteAsync(sql, new
            {
                rol.Id_Rol,
                rol.Name_Rol,
                rol.Description_Rol
            });
            return response > 0;
        }
    }
}
