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
    // Repository of rols
    public class RolRepository : IRolRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public RolRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for a rol
        public async Task<bool> DeleteRol(Rol rol)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE FROM public.""Roles""
                        WHERE id_rol = @Id_Rol";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Rol = rol.Id_Rol });
            // Returns if one or more rol were deleted
            return response > 0;
        }

        // Get method for all the rols
        public async Task<IEnumerable<Rol>> GetAllRoles()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_rol, name_rol, description_rol
                        FROM public.""Roles"" ";

            // Returns all the roles
            return await db.QueryAsync<Rol>(sql, new { });
        }

        // Get method for one rol using id
        public async Task<Rol> GetRolDetails(int id_rol)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_rol, name_rol, description_rol
                        FROM public.""Roles""
                        WHERE id_rol = @Id_Rol";

            // Returns a rol by id
            return await db.QueryFirstOrDefaultAsync<Rol>(sql, new { Id_Rol = id_rol });
        }

        // Creates a new rol
        public async Task<bool> InsertRol(Rol rol)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Roles"" (name_rol, description_rol)
                        VALUES (@Name_Rol, @Description_Rol)";

            // New roles' attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                rol.Name_Rol,
                rol.Description_Rol
            });

            // Returns true if one or more roles were added
            return response > 0;
        }

        // Update for a rol
        public async Task<bool> UpdateRol(Rol rol)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Roles""
                        SET name_rol = @Name_Rol,
                            description_rol = @Description_Rol
                        WHERE id_rol = @Id_Rol";

            // The attributes of the rol
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
