using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Room_Repository
{
    // Room interface
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();                  // Gets all rooms
        Task<Room> GetRoomDetails(int id_room);                 // Gets a room by id
        Task<bool> InsertRoom(Room room);                       // Inserts a room
        Task<bool> UpdateRoom(Room room);                       // Updates a room
        Task<bool> DeleteRoom(Room room);                       // Deletes a room
        Task<bool> InsertRoomFrontEnd(RoomFRONTEND room);       // Inserts a room using the name of the branch
        Task<bool> UpdateRoomByBranchName(RoomFRONTEND room);   // Updates a room using the name of the branch
    }
}
