using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Room_Repository
{
    public class RoomRepository : IRoomRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public RoomRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteRoom(Room room)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE FROM public.""Rooms""
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = room.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, capacity, rows, columns
                        FROM public.""Rooms""";
            return await db.QueryAsync<Room>(sql, new { });
        }

        public async Task<Room> GetRoomDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, capacity, rows, columns
                        FROM public.""Rooms""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Room>(sql, new { Id = id });
        }

        public async Task<bool> InsertRoom(Room room)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Rooms"" (capacity, rows, columns)
                        VALUES(@Capacity, @Rows, @Columns)";
            var response = await db.ExecuteAsync(sql, new
            {
                room.Capacity,
                room.Rows,
                room.Columns
            });
            return response > 0;
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Rooms""
                        SET capacity=@Capacity,
                            rows=@Rows,
                            columns=@Columns
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                room.Id,
                room.Capacity,
                room.Rows,
                room.Columns
            });
            return response > 0;
        }
    }
}
