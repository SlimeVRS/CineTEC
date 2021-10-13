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
                        SELECT id_director, first_name_director, second_name_director, first_last_name_director, second_last_name_director
                        FROM public.""Directors""";
            return await db.QueryAsync<Director>(sql, new { });
        }

        public async Task<Director> GetDirectorDetails(int id_director)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_director, first_name_director, second_name_director, first_last_name_director, second_last_name_director
                        FROM public.""Directors""
                        WHERE id_director = @Id_Director";
            return await db.QueryFirstOrDefaultAsync<Director>(sql, new { Id_Director = id_director });
        }

        public async Task<bool> InsertDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Directors"" (first_name_director, second_name_director, first_last_name_director, second_last_name_director)
                        VALUES (@First_Name_Director, @Second_Name_Director, @First_Last_Name_Director, @Second_Last_Name_Director)";
            var response = await db.ExecuteAsync(sql, new
            {
                director.First_Name_Director,
                director.Second_Name_Director,
                director.First_Last_Name_Director,
                director.Second_Last_Name_Director
            });
            return response > 0;
        }

        public async Task<bool> UpdateDirector(Director director)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Directors""
                        SET first_name_director = @First_Name_Director,
                            second_name_director = @Second_Name_Director,
                            first_last_Name_director = @First_Last_Name_Director,
                            second_last_Name_director = @Second_Last_Name_Director
                            WHERE id_director = @Id_Director";
            var response = await db.ExecuteAsync(sql, new
            {
                director.Id_Director,
                director.First_Name_Director,
                director.Second_Name_Director,
                director.First_Last_Name_Director,
                director.Second_Last_Name_Director
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
