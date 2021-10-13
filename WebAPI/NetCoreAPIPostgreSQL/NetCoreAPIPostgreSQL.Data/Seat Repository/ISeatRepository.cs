using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Seat_Repository
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetAllSeats();
        Task<Seat> GetSeatDetails(int id_seat);
        Task<bool> InsertSeat(Seat seat);
        Task<bool> UpdateSeat(Seat seat);
        Task<bool> DeleteSeat(Seat seat);
    }
}
