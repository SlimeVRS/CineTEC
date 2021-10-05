using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.ClassificationRepository
{
    public class ClassificationRepository : IClassificationRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public ClassificationRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteClassification(Classification classification)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM public.""Classifications""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = classification.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Classification>> GetAllClassifications()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, classif
                        FROM public.""Classifications""";
            return await db.QueryAsync<Classification>(sql, new { });
        }

        public async Task<Classification> GetClassificationDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, classif
                        FROM public.""Classifications""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Classification>(sql, new { Id = id});
        }

        public async Task<bool> InsertClassification(Classification classification)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Classifications"" (classif)
                        VALUES(@Classif)";
            var response = await db.ExecuteAsync(sql, new { classification.Classif });
            return response > 0;
        }

        public async Task<bool> UpdateClassification(Classification classification)
        {
            var db = dbConnection();
            var sql = @"
                        Update public.""Classifications""
                        SET classif=@Classif
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { classification.Id, classification.Classif });
            return response > 0;
        }
    }
}
