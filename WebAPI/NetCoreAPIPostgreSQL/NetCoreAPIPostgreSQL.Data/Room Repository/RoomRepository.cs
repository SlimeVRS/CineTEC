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
    // Repository of rooms
    public class RoomRepository : IRoomRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public RoomRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for a room
        public async Task<bool> DeleteRoom(Room room)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE FROM public.""Rooms""
                        WHERE id_room = @Id_Room";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Room = room.Id_Room });
            // Returns if one or more room were deleted
            return response > 0;
        }

        // Get method for all the rooms
        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_room, capacity_room, rows_room, columns_room, id_branch_room
                        FROM public.""Rooms""";
            // Returns all the rooms
            return await db.QueryAsync<Room>(sql, new { });
        }

        // Get method for one room using id
        public async Task<Room> GetRoomDetails(int id_room)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"SELECT id_room, capacity_room, rows_room, columns_room, id_branch_room
                        FROM public.""Rooms""
                        WHERE id_room = @Id_Room";

            // Returns a room by id
            return await db.QueryFirstOrDefaultAsync<Room>(sql, new { Id_Room = id_room });
        }

        // Create a new room
        public async Task<bool> InsertRoom(Room room)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Rooms"" (capacity_room, rows_room, columns_room, id_branch_room)
                        VALUES(@Capacity_Room, @Rows_Room, @Columns_Room, @Id_Branch_Room)";

            // New room's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                room.Id_Branch_Room
            });

            // Returns true if one or more rooms were added
            return response > 0;
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Rooms""
                        SET capacity_room=@Capacity_Room,
                            rows_room=@Rows_Room,
                            columns_room=@Columns_Room,
                            id_branch_room = @Id_Branch_Room
                        WHERE id_room = @Id_Room";

            // The attributes of the room
            var response = await db.ExecuteAsync(sql, new
            {
                room.Id_Room,
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                room.Id_Branch_Room
            });

            // Returns true if one or more rooms were modified
            return response > 0;
        }

        public async Task<bool> InsertRoomFrontEnd(RoomFRONTEND room)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            // It searchs the branch that matches a name
            var id_branch_sql = @"
                                    SELECT id_branch
                                    FROM public.""Branches""
                                    WHERE name_branch = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = room.Name_Branch_Room });

            // Another SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Rooms"" (capacity_room, rows_room, columns_room, id_branch_room)
                        VALUES(@Capacity_Room, @Rows_Room, @Columns_Room, @Id_Branch)";

            // New room's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                id_branch.Id_Branch
            });

            // Another SQL query, it uses double quotes because of the upper case
            // Searches the very last room added
            var id_room_sql = @"SELECT id_room FROM public.""Rooms""
                                    ORDER BY 1 DESC LIMIT 1;";
            var id_room = await db.QueryFirstOrDefaultAsync<Room>(id_room_sql, new { });
            
            // For loop from 0 to the room's row
            for(int row = 0; row < room.Rows_Room; row++)
            {
                // For loop from 0 to the room's column
                for (int column = 0; column < room.Columns_Room; column++)
                {
                    // Another SQL query, it uses double quotes because of the upper case
                    var insert_seat_sql = @"
                        INSERT INTO public.""Seats"" (row_seat, column_seat, state_seat, id_room_seat)
                        VALUES(@Row_Seat, @Column_Seat, @State_Seat, @Id_Room_Seat)";
                    // New seat's attributes, the id isn't here because it is auto incremental
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

        // Updates room using branch name
        public async Task<bool> UpdateRoomByBranchName(RoomFRONTEND room)
        {
            // Stablishing connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            // It searchs the branch that matches a name
            var id_branch_sql = @"
                                SELECT id_branch 
                                FROM public.""Branches""
                                WHERE name_branch = @Branch_Name";
            var id_branch = await db.QueryFirstOrDefaultAsync<Branch>(id_branch_sql, new { Branch_Name = room.Name_Branch_Room });

            // Another SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Rooms""
                        SET capacity_room=@Capacity_Room,
                            rows_room=@Rows_Room,
                            columns_room=@Columns_Room,
                            id_branch_room = @Id_Branch_Room
                        WHERE id_room = @Id_Room";

            // The attributes of the room
            var response = await db.ExecuteAsync(sql, new
            {
                room.Id_Room,
                room.Capacity_Room,
                room.Rows_Room,
                room.Columns_Room,
                id_branch.Id_Branch
            });
            // Returns true if one or more room were modified
            return response > 0;
        }
    }
}
