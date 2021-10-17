using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Protagonist_Repository
{
    // Repository of protagonist
    public class ProtagonistRepository : IProtagonistRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public ProtagonistRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for a protagonist
        public async Task<bool> DeleteProtagonist(Protagonist protagonist)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE FROM public.""Protagonists""
                        WHERE id_protagonist = @Id_Protagonist";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Protagonist = protagonist.Id_Protagonist });
            // Returns if one or more protagonist were deleted
            return response > 0;
        }

        // Get method for all the seats
        public async Task<IEnumerable<Protagonist>> GetAllProtagonists()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_protagonist, name_protagonist
                        FROM public.""Protagonists""";
            // Returns all the seats
            return await db.QueryAsync<Protagonist>(sql, new { });
        }

        // Get method for one protagonist using id
        public async Task<Protagonist> GetProtagonistDetails(int id_protagonist)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_protagonist, name_protagonist
                        FROM public.""Protagonists""
                        WHERE id_protagonist = @Id_Protagonist";
            // Returns a protagonist by id
            return await db.QueryFirstOrDefaultAsync<Protagonist>(sql, new { Id_Protagonist = id_protagonist });
        }

        // Creates a new protagonist
        public async Task<bool> InsertProtagonist(Protagonist protagonist)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Protagonists"" (name_protagonist)
                        VALUES (@Name_Protagonist)";
            // New protagonist's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.Name_Protagonist
            });

            // Returns true if one or more protagonists were added
            return response > 0;
        }

        // Update for a protagonist
        public async Task<bool> UpdateProtagonist(Protagonist protagonist)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Protagonists""
                        SET name_protagonist=@Name_Protagonist
                            WHERE id_protagonist = @Id_Protagonist";

            // The attributes of the protagonist
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.Id_Protagonist,
                protagonist.Name_Protagonist
            });
            // Returns true if one or more protagonists were modified
            return response > 0;
        }
    }
}
