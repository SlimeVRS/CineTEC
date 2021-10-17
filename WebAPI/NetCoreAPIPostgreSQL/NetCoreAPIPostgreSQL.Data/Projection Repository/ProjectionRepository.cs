using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Projection_Repository
{
    // Repository of seats
    public class ProjectionRepository : IProjectionRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public ProjectionRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for a projection
        public async Task<bool> DeleteProjection(Projection projection)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE 
                        FROM public.""Projections""
                        WHERE id_projection = @Id_Projection";

            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Projection = projection.Id_Projection });
            // Returns if one or more projections were deleted
            return response > 0;
        }

        // Get method for all the projections
        public async Task<IEnumerable<Projection>> GetAllProjections()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_projection, time_projection, day_projection, id_movie_projection, id_room_projection
                        FROM public.""Projections""";
            // Returns all the protagonists
            return await db.QueryAsync<Projection>(sql, new { });
        }

        // Get method for one projections using id
        public async Task<Projection> GetProjectionDetails(int id_projection)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_projection, time_projection, day_projection, id_movie_projection, id_room_projection
                        FROM public.""Projections""
                        WHERE id_projection = @Id_Projection";
            return await db.QueryFirstOrDefaultAsync<Projection>(sql, new { Id_Projection = id_projection });
        }

        // Creates a new projection
        public async Task<bool> InsertProjection(Projection projection)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Projections"" (time_projection, day_projection, id_movie_projection, id_room_projection)
                        VALUES(@Time_Projection, Day_Projection, @Id_Movie_Projection, @Id_Room_Projection)";
            // New projection's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Time_Projection,
                projection.Day_Projection,
                projection.Id_Movie_Projection,
                projection.Id_Room_Projection
            });

            // Returns true if one or more projections were added
            return response > 0;
        }

        // Update for a projection
        public async Task<bool> UpdateProjection(Projection projection)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Projections""
                        SET time_projection = @Time_Projection,
                            day_projection = @Day_Projection,
                            id_movie_projection = @Id_Movie_Projection,
                            id_room_projection = @Id_Room_Projection
                        WHERE id_projection = @Id_Projection";

            // The attributes of the projection
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Id_Projection,
                projection.Day_Projection,
                projection.Time_Projection,
                projection.Id_Movie_Projection,
                projection.Id_Room_Projection
            });
            // Returns true if one or more projections were modified
            return response > 0;
        }

        // Inserts a projection using the movie's name
        public async Task<bool> InsertProjectionFrontEnd(ProjectionFRONTEND projection)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            // It searches a movie by its name 
            var id_movie_sql = @"
                            SELECT id_movie
                            FROM public.""Movies""
                            WHERE name_movie = @Name_Movie_Projection";
            var id_movie = await db.QueryFirstOrDefaultAsync<Movie>(id_movie_sql, new { Name_Movie_Projection = projection.Name_Movie_Projection });
            if (id_movie == null)
                return false;

            // Another SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Projections"" (time_projection, day_projection, id_movie_projection, id_room_projection)
                        VALUES(@Time_Projection, @Day_Projection, @Id_Movie, @Id_Room_Projection)";

            // New projection's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Time_Projection,
                projection.Day_Projection,
                id_movie.Id_Movie,
                projection.Id_Room_Projection
            });
            // Returns true if a projection was added
            return response > 0;
        }

        // Update a projection using varius movie's name
        public async Task<bool> UpdateInsertionByMovieName(ProjectionFRONTEND projection)
        {
            // Stablishing connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            // It searches a movie by its name
            var id_movie_sql = @"
                            SELECT id_movie
                            FROM public.""Movies""
                            WHERE name_movie = @Name_Movie_Projection";

            var id_movie = await db.QueryFirstOrDefaultAsync<Movie>(id_movie_sql, new { Name_Movie_Projection = projection.Name_Movie_Projection });
            if (id_movie == null)
                return false;

            // Another SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Projections""
                        SET time_projection = @Time_Projection,
                            day_projection = @Day_Projection,
                            id_room_projection = @Id_Room_Projection,
                            id_movie_projection = @Id_Movie
                        WHERE id_projection = @Id_Projection";

            // The new projection's attributes that matches all the conditions
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Id_Projection,
                projection.Time_Projection,
                projection.Day_Projection,
                projection.Id_Room_Projection,
                id_movie.Id_Movie
            });

            // Returns if one or more projections were modified
            return response > 0;
        }

        public async Task<IEnumerable<ShowProjection>> GetDetailedProjections()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT name_movie, duration_movie, poster_movie, name_protagonist, name_director, price_adult_movie, price_kid_movie, price_elder_movie
                        FROM public.""Projections""
                        INNER JOIN public.""Movies""
                        ON id_movie_projection = id_movie
                        INNER JOIN public.""Protagonists""
                        ON id_protagonist = id_protagonist_movie
                        INNER JOIN public.""Directors""
                        ON id_director = id_director_movie
";
        
            return await db.QueryAsync<ShowProjection>(sql, new { });
        }
    }
}
