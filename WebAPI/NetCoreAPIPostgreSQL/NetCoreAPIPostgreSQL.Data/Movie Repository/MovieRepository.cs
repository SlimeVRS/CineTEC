using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Movie_Repository
{
    public class MovieRepository : IMovieRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public MovieRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteMovie(Movie movie)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Movies""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = movie.Id});
            return response > 0;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, duration, poster, price_elder, price_adult, price_kid, id_director, id_classif, id_protagonist
                        FROM public.""Movies"" ";
            return await db.QueryAsync<Movie>(sql, new { });
        }

        public async Task<Movie> GetMovieDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, name, duration, poster, price_elder, price_adult, price_kid, id_director, id_classif, id_protagonist
                        FROM public.""Movies""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Movie>(sql, new { Id = id });
        }

        public async Task<bool> InsertMovie(Movie movie)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Movies"" (name, duration, poster, price_elder, price_adult, price_kid, id_director, id_classif, id_protagonist)
                        VALUES (@Name, @Duration, @Poster, @Price_Elder, @Price_Adult, @Price_Kid, @Id_Director, @Id_Classif, @Id_Protagonist)";
            var response = await db.ExecuteAsync(sql, new
            {
                movie.Name,
                movie.Duration,
                movie.Poster,
                movie.Price_Elder,
                movie.Price_Adult,
                movie.Price_Kid,
                movie.Id_Director,
                movie.Id_Classif,
                movie.Id_Protagonist
            });
            return response > 0;
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Movies""
                        SET name=@Name,
                            duration=@Duration,
                            poster=@Poster,
                            price_elder=@Price_Elder,
                            price_adult=@Price_Adult,
                            price_kid= @Price_Kid,
                            id_director=@Id_Director,
                            id_classif=@Id_Classif,
                            id_protagonist=@Id_Protagonist
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                movie.Id,
                movie.Name,
                movie.Duration,
                movie.Poster,
                movie.Price_Elder,
                movie.Price_Adult,
                movie.Price_Kid,
                movie.Id_Director,
                movie.Id_Classif,
                movie.Id_Protagonist
            });
            return response > 0;
        }
    }
}
