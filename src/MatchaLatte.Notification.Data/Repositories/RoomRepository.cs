using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Notification.Domain.Rooms;
using MongoDB.Driver;

namespace MatchaLatte.Notification.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Room> rooms;

        public RoomRepository(IMongoDatabase database)
        {
            rooms = database.GetCollection<Room>("room");
        }

        public async Task<ICollection<Room>> GetRoomsAsync(Guid memberId)
        {
            return await rooms.AsQueryable().ToListAsync();
        }

        public async Task AddAsync(Room room)
        {
            await rooms.InsertOneAsync(room);
        }
    }
}