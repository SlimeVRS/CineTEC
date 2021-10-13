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
                        WHERE id_movie = @Id_Movie";
            var response = await db.ExecuteAsync(sql, new { Id_Movie = movie.Id_Movie });
            return response > 0;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_movie, name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie
                        FROM public.""Movies"" ";
            return await db.QueryAsync<Movie>(sql, new { });
        }

        public async Task<Movie> GetMovieDetails(int id_movie)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_movie, name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie
                        FROM public.""Movies""
                        WHERE id_movie = @Id_Movie";
            return await db.QueryFirstOrDefaultAsync<Movie>(sql, new { Id_Movie = id_movie });
        }

        public async Task<bool> InsertMovie(Movie movie)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Movies"" (name_movie, duration_movie, poster_movie, price_elder_movie, price_adult_movie, price_kid_movie, id_director_movie, id_classif_movie, id_protagonist_movie)
                        VALUES (@Name_Movie, @Duration_Movie, @Poster_Movie, @Price_Elder_Movie, @Price_Adult_Movie, @Price_Kid_Movie, @Id_Director_Movie, @Id_Classif_Movie, @Id_Protagonist_Movie)";
            var response = await db.ExecuteAsync(sql, new
            {
                movie.Name_Movie,
                movie.Duration_Movie,
                movie.Poster_Movie,
                movie.Price_Elder_Movie,
                movie.Price_Adult_Movie,
                movie.Price_Kid_Movie,
                movie.Id_Director_Movie,
                movie.Id_Classif_Movie,
                movie.Id_Protagonist_Movie
            });
            return response > 0;
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Movies""
                        SET name_movie=@Name_Movie,
                            duration_movie=@Duration_Movie,
                            poster_movie=@Poster_Movie,
                            price_elder_movie=@Price_Elder_Movie,
                            price_adult_movie=@Price_Adult_Movie,
                            price_kid_movie= @Price_Kid_Movie,
                            id_director_movie=@Id_Director_Movie,
                            id_classif_movie=@Id_Classif_Movie,
                            id_protagonist_movie=@Id_Protagonist_Movie
                        WHERE id_movie = @Id_Movie";
            var response = await db.ExecuteAsync(sql, new
            {
                movie.Id_Movie,
                movie.Name_Movie,
                movie.Duration_Movie,
                movie.Poster_Movie,
                movie.Price_Elder_Movie,
                movie.Price_Adult_Movie,
                movie.Price_Kid_Movie,
                movie.Id_Director_Movie,
                movie.Id_Classif_Movie,
                movie.Id_Protagonist_Movie
            });
            return response > 0;
        }
    }
}
