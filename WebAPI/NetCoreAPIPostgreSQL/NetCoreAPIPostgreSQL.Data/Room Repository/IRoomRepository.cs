using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Room_Repository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomDetails(int id_room);
        Task<bool> InsertRoom(Room room);
        Task<bool> UpdateRoom(Room room);
        Task<bool> DeleteRoom(Room room);
        Task<bool> InsertRoomFrontEnd(RoomFRONTEND room);
    }
}
