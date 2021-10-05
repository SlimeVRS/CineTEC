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
    public class DirectorsRepository : IDirectorsRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public DirectorsRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
     
        public async Task<IEnumerable<Director>> GetAllDirectors()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name
                        FROM public.""Directors""";
            return await db.QueryAsync<Director>(sql, new { });
        }

        public async Task<Director> GetDirectorDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, first_name, second_name, first_last_name, second_last_name
                        FROM public.""Directors""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Director>(sql, new { Id = id});
        }

        public async Task<bool> InsertDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Directors"" (first_name, second_name, first_last_name, second_last_name)
                        VALUES (@First_Name, @Second_Name, @First_Last_Name, @Second_Last_Name)";
            var response = await db.ExecuteAsync(sql, new
            {
                director.First_Name,
                director.Second_Name,
                director.First_Last_Name,
                director.Second_Last_Name
            });
            return response > 0;
        }

        public async Task<bool> UpdateDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Directors""
                        SET first_name=@First_Name,
                            second_name=@Second_Name,
                            first_last_Name=@First_Last_Name,
                            second_last_Name=@Second_Last_Name
                            WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                director.Id,
                director.First_Name,
                director.Second_Name,
                director.First_Last_Name,
                director.Second_Last_Name
            });
            return response > 0;
        }

        public async Task<bool> DeleteDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Directors""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = director.Id });
            return response > 0;
        }
    }
}
