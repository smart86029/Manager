using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Notification.Domain.Rooms
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<ICollection<Room>> GetRoomsAsync(Guid memberId);

        Task AddAsync(Room room);
    }
}