using System;
using System.Threading.Tasks;

namespace MatchaLatte.Notification.App.Rooms
{
    public interface IRoomService
    {
        Task<RoomDetail> GetRooms(Guid memberId);

        Task CreateRoomAsync(CreateRoomCommand command);
    }
}