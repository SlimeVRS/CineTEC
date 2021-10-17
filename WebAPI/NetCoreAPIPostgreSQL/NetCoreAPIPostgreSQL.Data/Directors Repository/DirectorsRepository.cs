using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Directors_Repository
{
    // Repository of Directors
    public class DirectorsRepository : IDirectorsRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public DirectorsRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Get method for all the directors
        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_director, name_director
                        FROM public.""Directors""";
            // Returns all the seats
            return await db.QueryAsync<Director>(sql, new { });
        }

        // Get method for one director using id
        public async Task<Director> GetDirectorDetails(int id_director)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_director, name_director
                        FROM public.""Directors""
                        WHERE id_director = @Id_Director";

            // Returns a director by id
            return await db.QueryFirstOrDefaultAsync<Director>(sql, new { Id_Director = id_director });
        }

        // Creates a new director
        public async Task<bool> InsertDirector(Director director)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Directors"" (name_director)
                        VALUES (@Name_Director)";

            // New director's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                director.Name_Director
            });
            // Returns true if one or more directors were added
            return response > 0;
        }

        // Update for a director
        public async Task<bool> UpdateDirector(Director director)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Directors""
                        SET name_director = @Name_Director
                        WHERE id_director = @Id_Director";

            // The attributes of the director
            var response = await db.ExecuteAsync(sql, new
            {
                director.Id_Director,
                director.Name_Director
            });
            // Returns true if one or more directors were modified
            return response > 0;
        }

        // Delete method for a seat
        public async Task<bool> DeleteDirector(Director director)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE FROM public.""Directors""
                        WHERE id_director = @Id_Director";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Director = director.Id_Director });
            // Returns if one or more seat were deleted
            return response > 0;
        }
    }
}
