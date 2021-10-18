using Dapper;
using NetCoreAPIPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Seat_Repository
{
    // Repository of seats
    public class SeatRepository : ISeatRepository
    {
        // Varible connection with postgreSQL
        private PostgreSQLConfiguration _connectionString;

        // Assignation of all the necessary information
        public SeatRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        // Connection with postgreSQL
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        // Delete method for a seat
        public async Task<bool> DeleteSeat(Seat seat)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        DELETE
                        FROM public.""Seats""
                        WHERE id_seat = @Id_Seat";
            // Waiting of the response if a row were deleted
            var response = await db.ExecuteAsync(sql, new { Id_Seat = seat.Id_Seat });
            // Returns if one or more seat were deleted
            return response > 0;
        }

        // Get method for all the seats
        public async Task<IEnumerable<Seat>> GetAllSeats()
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_seat, row_seat, column_seat, state_seat, id_room_seat
                        FROM public.""Seats""";
            // Returns all the seats
            return await db.QueryAsync<Seat>(sql, new { });
        }

        // Get method for one seat using id
        public async Task<Seat> GetSeatDetails(int id_seat)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_seat, row_seat, column_seat, state_seat, id_room_seat
                        FROM public.""Seats""
                        WHERE id_seat = @Id_Seat";

            // Returns a seat by id
            return await db.QueryFirstOrDefaultAsync<Seat>(sql, new { Id_Seat = id_seat });
        }

        // Creates a new seat
        public async Task<bool> InsertSeat(Seat seat)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        INSERT INTO public.""Seats"" (row_seat, column_seat, state_seat, id_room_seat)
                        VALUES (@Row_Seat, @Column_Seat, @State_Seat, @Id_Room_Seat)";

            // New seat's attributes, the id isn't here because it is auto incremental
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Row_Seat,
                seat.Column_Seat,
                seat.State_Seat,
                seat.Id_Room_Seat
            });

            // Returns true if one or more seats were added
            return response > 0;
        }

        // Update for a seat
        public async Task<bool> UpdateSeat(Seat seat)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Seats""
                        SET row_seat = @Row_Seat,
                            column_seat = @Column_Seat,
                            state_seat = @State_Seat,
                            id_room_seat = @Id_Room_Seat
                        WHERE id_seat = @Id_Seat";

            // The attributes of the seat
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Id_Seat,
                seat.Row_Seat,
                seat.Column_Seat,
                seat.State_Seat,
                seat.Id_Room_Seat
            });
            // Returns true if one or more seats were modified
            return response > 0;
        }

        // Get method for all the seats using room id 
        public async Task<IEnumerable<Seat>> GetSeatByRoomId(int id)
        {
            // Stablishing a connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        SELECT id_seat, row_seat, column_seat, state_seat, id_room_seat
                        FROM public.""Seats""
                        WHERE id_room_seat = @Id_Room_Seat";

            // Returns all the seats that match the room id
            return await db.QueryAsync<Seat>(sql, new { Id_Room_Seat = id}); 
        }

        // Update a seat using varius attributes
        public async Task<bool> UpdateSeatByRoomIdandState(Seat seat)
        {
            // Stablishing connection
            var db = dbConnection();

            // SQL query, it uses double quotes because of the upper case
            var sql = @"
                        UPDATE public.""Seats""
                        SET state_seat = @State_Seat
                        WHERE row_seat = @Row_Seat AND column_seat = @Column_Seat AND id_room_seat = @Id_Room_Seat";

            // The new seat attributes that matches all the conditions
            var response = await db.ExecuteAsync(sql, new
            {
                seat.State_Seat,
                seat.Row_Seat,
                seat.Column_Seat,
                seat.Id_Room_Seat
            });

            // Returns if one or more seat were modified
            return response > 0;
        }

        public async Task<IEnumerable<Seat>> GetOcupiedseats(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT row_seat, column_seat
                        FROM public.""Seats""
                        WHERE id_room_seat = @Id_Room_Seat AND state_seat = 2";
            return await db.QueryAsync<Seat>(sql, new { Id_Room_Seat = id });
        }
    }
}
