using System;
using System.Threading.Tasks;
using MatchaLatte.Notification.App.Rooms;
using MatchaLatte.Notification.Domain.Rooms;

namespace MatchaLatte.Notification.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
        }

        public Task<RoomDetail> GetRooms(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRoomAsync(CreateRoomCommand command)
        {
            var room = new Room(string.Empty, command.MemberIds);

            await roomRepository.AddAsync(room);
        }
    }
}