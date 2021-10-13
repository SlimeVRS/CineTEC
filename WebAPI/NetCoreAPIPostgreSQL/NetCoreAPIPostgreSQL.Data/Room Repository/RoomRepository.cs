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
                        WHERE id_room = @Id_Room";
            var response = await db.ExecuteAsync(sql, new { Id_Room = room.Id_Room });
            return response > 0;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_room, capacity_room, rows_room, columns_room, id_branch_room
                        FROM public.""Rooms""";
            return await db.QueryAsync<Room>(sql, new { });
        }

        public async Task<Room> GetRoomDetails(int id_room)
        {
            var db = dbConnection();
            var sql = @"SELECT id_room, capacity_room, rows_room, columns_room, id_branch_room
                        FROM public.""Rooms""
                        WHERE id_room = @Id_Room";
            return await db.QueryFirstOrDefaultAsync<Room>(sql, new { Id_Room = id_room });
        }

        public async Task<bool> InsertRoom(Room room)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Rooms"" (capacity_room, rows_room, columns_room, id_branch_room)
                        VALUES(@Capacity_Room, @Rows_Room, @Columns_Room, @Id_Branch_Room)";
            var response = await db.ExecuteAsync(sql, new
            {
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                room.Id_Branch_Room
            });
            return response > 0;
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Rooms""
                        SET capacity_room=@Capacity_Room,
                            rows_room=@Rows_Room,
                            columns_room=@Columns_Room,
                            id_branch_room = @Id_Branch_Room
                        WHERE id_room = @Id_Room";
            var response = await db.ExecuteAsync(sql, new
            {
                room.Id_Room,
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                room.Id_Branch_Room
            });
            return response > 0;
        }
    }
}
