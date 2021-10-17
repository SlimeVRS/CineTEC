using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Seat_Repository
{
    // Interface of the seat
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllSeats();              // Gets all the seats
        Task<Seat> GetSeatDetails(int id_seat);             // Gets a seat by id
        Task<bool> InsertSeat(Seat seat);                   // Insert a new seat
        Task<bool> UpdateSeat(Seat seat);                   // Updates a seat
        Task<bool> DeleteSeat(Seat seat);                   // Deletes a seat
        Task<IEnumerable<Seat>> GetSeatByRoomId(int id);    // Gets a all the seats in a room using the room id
        Task<bool> UpdateSeatByRoomIdandState(Seat seat);   // Updates a seat using: room id, row and column
    }
}
