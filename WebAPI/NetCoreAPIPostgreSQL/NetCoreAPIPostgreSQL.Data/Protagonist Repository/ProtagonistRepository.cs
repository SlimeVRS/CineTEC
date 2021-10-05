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
    public class ProtagonistRepository : IProtagonistRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public ProtagonistRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProtagonist(Protagonist protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Protagonists""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = protagonist.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Protagonist>> GetAllProtagonists()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name
                        FROM public.""Protagonists""";
            return await db.QueryAsync<Protagonist>(sql, new { });
        }

        public async Task<Protagonist> GetProtagonistDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name
                        FROM public.""Protagonists""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Protagonist>(sql, new { Id = id });
        }

        public async Task<bool> InsertProtagonist(Protagonist protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Protagonists"" (first_name, second_name, first_last_name, second_last_name)
                        VALUES (@First_Name, @Second_Name, @First_Last_Name, @Second_Last_Name)";
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.First_Name,
                protagonist.Second_Name,
                protagonist.First_Last_Name,
                protagonist.Second_Last_Name
            });
            return response > 0;
        }

        public async Task<bool> UpdateProtagonist(Protagonist protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Protagonists""
                        SET first_name=@First_Name,
                            second_name=@Second_Name,
                            first_last_Name=@First_Last_Name,
                            second_last_Name=@Second_Last_Name
                            WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.Id,
                protagonist.First_Name,
                protagonist.Second_Name,
                protagonist.First_Last_Name,
                protagonist.Second_Last_Name
            });
            return response > 0;
        }
    }
}
