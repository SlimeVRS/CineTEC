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

        public async Task<bool> InsertRoomFrontEnd(RoomFRONTEND room)
        {
            var db = dbConnection();
            var id_branch_sql = @"
                                    SELECT id_branch
                                    FROM public.""Branches""
                                    WHERE name_branch = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = room.Name_Branch_Room });
            var sql = @"
                        INSERT INTO public.""Rooms"" (capacity_room, rows_room, columns_room, id_branch_room)
                        VALUES(@Capacity_Room, @Rows_Room, @Columns_Room, @Id_Branch)";
            var response = await db.ExecuteAsync(sql, new
            {
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                id_branch.Id_Branch
            });
            var id_room_sql = @"SELECT id_room FROM public.""Rooms""
                                    ORDER BY 1 DESC LIMIT 1;";
            var id_room = await db.QueryFirstOrDefaultAsync<Room>(id_room_sql, new { });
            for(int row = 0; row < room.Rows_Room; row++)
            {
                for(int column = 0; column < room.Columns_Room; column++)
                {
                    var insert_seat_sql = @"
                        INSERT INTO public.""Seats"" (row_seat, column_seat, state_seat, id_room_seat)
                        VALUES(@Row_Seat, @Column_Seat, @State_Seat, @Id_Room_Seat)";
                    await db.ExecuteAsync(insert_seat_sql, new Seat
                    {
                        Row_Seat = row,
                        Column_Seat = column,
                        State_Seat = 1,
                        Id_Room_Seat = id_room.Id_Room
                    });
                }
            }
            return response > 0;
        }
    }
}
