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
    public class ProjectionRepository : IProjectionRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public ProjectionRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProjection(Projection projection)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM public.""Projections""
                        WHERE id_projection = @Id_Projection";
            var response = await db.ExecuteAsync(sql, new { Id_Projection = projection.Id_Projection });
            return response > 0;
        }

        public async Task<IEnumerable<Projection>> GetAllProjections()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_projection, time_projection, id_movie_projection, id_room_projection
                        FROM public.""Projections""";
            return await db.QueryAsync<Projection>(sql, new { });
        }

        public async Task<Projection> GetProjectionDetails(int id_projection)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_projection, time_projection, id_movie_projection, id_room_projection
                        FROM public.""Projections""
                        WHERE id_projection = @Id_Projection";
            return await db.QueryFirstOrDefaultAsync<Projection>(sql, new { Id_Projection = id_projection });
        }

        public async Task<bool> InsertProjection(Projection projection)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Projections"" (time_projection, id_movie_projection, id_room_projection)
                        VALUES(@Time_Projection, @Id_Movie_Projection, @Id_Room_Projection)";
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Time_Projection,
                projection.Id_Movie_Projection,
                projection.Id_Room_Projection
            });
            return response > 0;
        }

        public async Task<bool> UpdateProjection(Projection projection)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Projections""
                        SET time_projection = @Time_Projection,
                            id_movie_projection = @Id_Movie_Projection,
                            id_room_projection = @Id_Room_Projection
                        WHERE id_projection = @Id_Projection";
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Id_Projection,
                projection.Time_Projection,
                projection.Id_Movie_Projection,
                projection.Id_Room_Projection
            });
            return response > 0;
        }

        public async Task<bool> InsertProjectionFrontEnd(ProjectionFRONTEND projection)
        {
            var db = dbConnection();
            var id_movie_sql = @"
                            SELECT id_movie
                            FROM public.""Movies""
                            WHERE name_movie = @Name_Movie_Projection";
            var id_movie = await db.QueryFirstOrDefaultAsync<Movie>(id_movie_sql, new { Name_Movie_Projection = projection.Name_Movie_Projection });
            var sql = @"
                        INSERT INTO public.""Projections"" (time_projection, id_movie_projection, id_room_projection)
                        VALUES(@Time_Projection, @Id_Movie, @Id_Room_Projection)";
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Time_Projection,
                id_movie.Id_Movie,
                projection.Id_Room_Projection
            });
            return response > 0;
        }
    }
}
