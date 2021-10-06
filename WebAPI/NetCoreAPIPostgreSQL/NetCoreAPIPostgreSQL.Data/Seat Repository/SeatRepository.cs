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
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new { Id = seat.Id });
            return response > 0;
        }

        public async Task<IEnumerable<Seat>> GetAllSeats()
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, _row, _column, _state
                        FROM public.""Seats""";
            return await db.QueryAsync<Seat>(sql, new { });
        }

        public async Task<Seat> GetSeatDetails(int id)
        {
            var db = dbConnection();
            var sql = @"
                        SELECT id, _row, _column, _state
                        FROM public.""Seats""
                        WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Seat>(sql, new { Id = id });
        }

        public async Task<bool> InsertSeat(Seat seat)
        {
            var db = dbConnection();
            var sql = @"
                        INSERT INTO public.""Seats"" (_row, _column, _state)
                        VALUES (@Row, @Column, @State)";
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Row,
                seat.Column,
                seat.State
            });
            return response > 0;
        }

        public async Task<bool> UpdateSeat(Seat seat)
        {
            var db = dbConnection();
            var sql = @"
                        UPDATE public.""Seats""
                        SET _row = @Row,
                            _column = @Column,
                            _state = @State
                        WHERE id = @Id";
            var response = await db.ExecuteAsync(sql, new
            {
                seat.Id,
                seat.Row,
                seat.Column,
                seat.State
            });
            return response > 0;
        }
    }
}
