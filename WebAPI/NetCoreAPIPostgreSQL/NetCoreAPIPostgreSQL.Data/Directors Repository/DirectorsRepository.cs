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
                        SELECT id_director, name_director
                        FROM public.""Directors""";
            return await db.QueryAsync<Director>(sql, new { });
        }

        public async Task<Director> GetDirectorDetails(int id_director)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_director, name_director
                        FROM public.""Directors""
                        WHERE id_director = @Id_Director";
            return await db.QueryFirstOrDefaultAsync<Director>(sql, new { Id_Director = id_director });
        }

        public async Task<bool> InsertDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Directors"" (name_director)
                        VALUES (@Name_Director)";
            var response = await db.ExecuteAsync(sql, new
            {
                director.Name_Director
            });
            return response > 0;
        }

        public async Task<bool> UpdateDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Directors""
                        SET name_director = @Name_Director
                        WHERE id_director = @Id_Director";
            var response = await db.ExecuteAsync(sql, new
            {
                director.Id_Director,
                director.Name_Director
            });
            return response > 0;
        }

        public async Task<bool> DeleteDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Directors""
                        WHERE id_director = @Id_Director";
            var response = await db.ExecuteAsync(sql, new { Id_Director = director.Id_Director });
            return response > 0;
        }
    }
}
