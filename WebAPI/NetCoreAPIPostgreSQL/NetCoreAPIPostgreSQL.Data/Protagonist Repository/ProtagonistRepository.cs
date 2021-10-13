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
                        WHERE id_protagonist = @Id_Protagonist";
            var response = await db.ExecuteAsync(sql, new { Id_Protagonist = protagonist.Id_Protagonist });
            return response > 0;
        }

        public async Task<IEnumerable<Protagonist>> GetAllProtagonists()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_protagonist, name_protagonist
                        FROM public.""Protagonists""";
            return await db.QueryAsync<Protagonist>(sql, new { });
        }

        public async Task<Protagonist> GetProtagonistDetails(int id_protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_protagonist, name_protagonist
                        FROM public.""Protagonists""
                        WHERE id_protagonist = @Id_Protagonist";
            return await db.QueryFirstOrDefaultAsync<Protagonist>(sql, new { Id_Protagonist = id_protagonist });
        }

        public async Task<bool> InsertProtagonist(Protagonist protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Protagonists"" (name_protagonist)
                        VALUES (@Name_Protagonist)";
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.Name_Protagonist
            });
            return response > 0;
        }

        public async Task<bool> UpdateProtagonist(Protagonist protagonist)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Protagonists""
                        SET name_protagonist=@Name_Protagonist
                            WHERE id_protagonist = @Id_Protagonist";
            var response = await db.ExecuteAsync(sql, new
            {
                protagonist.Id_Protagonist,
                protagonist.Name_Protagonist
            });
            return response > 0;
        }
    }
}
