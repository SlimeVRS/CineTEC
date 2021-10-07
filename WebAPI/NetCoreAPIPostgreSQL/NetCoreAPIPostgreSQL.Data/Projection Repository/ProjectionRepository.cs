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
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = projection.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Projection>> GetAllProjections()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, _time, id_movie, id_room
                        FROM public.""Projections""";
            return await db.QueryAsync<Projection>(sql, new { });
        }

        public async Task<Projection> GetProjectionDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, _time, id_movie, id_room
                        FROM public.""Projections""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Projection>(sql, new { Id = id });
        }

        public async Task<bool> InsertProjection(Projection projection)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Projections"" (_time, id_movie, id_room)
                        VALUES(@Time, @Id_Movie, @Id_Room)";
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Time,
                projection.Id_Movie,
                projection.Id_Room
            });
            return response > 0;
        }

        public async Task<bool> UpdateProjection(Projection projection)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Projections""
                        SET _time = @Time,
                            id_movie = @Id_Movie,
                            id_room = @Id_Room
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                projection.Id,
                projection.Time,
                projection.Id_Movie,
                projection.Id_Room
            });
            return response > 0;
        }
    }
}
