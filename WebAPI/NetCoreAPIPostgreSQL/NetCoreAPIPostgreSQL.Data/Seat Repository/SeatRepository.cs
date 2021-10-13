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
    public class SeatRepository : ISeatRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public SeatRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteSeat(Seat seat)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE
                        FROM public.""Seats""
                        WHERE id_seat = @Id_Seat";
            var response = await db.ExecuteAsync(sql, new { Id_Seat = seat.Id_Seat });
            return response > 0;
        }

        public async Task<IEnumerable<Seat>> GetAllSeats()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_seat, row_seat, column_seat, state_seat, id_room_seat
                        FROM public.""Seats""";
            return await db.QueryAsync<Seat>(sql, new { });
        }

        public async Task<Seat> GetSeatDetails(int id_seat)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id_seat, row_seat, column_seat, state_seat, id_room_seat
                        FROM public.""Seats""
                        WHERE id_seat = @Id_Seat";
            return await db.QueryFirstOrDefaultAsync<Seat>(sql, new { Id_Seat = id_seat });
        }

        public async Task<bool> InsertSeat(Seat seat)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Seats"" (row_seat, column_seat, state_seat, id_room_seat)
                        VALUES (@Row_Seat, @Column_Seat, @State_Seat, @Id_Room_Seat)";
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Row_Seat,
                seat.Column_Seat,
                seat.State_Seat,
                seat.Id_Room_Seat
            });
            return response > 0;
        }

        public async Task<bool> UpdateSeat(Seat seat)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Seats""
                        SET row_seat = @Row_Seat,
                            column_seat = @Column_Seat,
                            state_seat = @State_Seat,
                            id_room_seat = @Id_Room_Seat
                        WHERE id_seat = @Id_Seat";
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Id_Seat,
                seat.Row_Seat,
                seat.Column_Seat,
                seat.State_Seat,
                seat.Id_Room_Seat
            });
            return response > 0;
        }
    }
}
