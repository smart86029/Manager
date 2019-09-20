using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Notification.Domain.Messages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MatchaLatte.Notification.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<Message> messages;


        public MessageRepository(IMongoDatabase database)
        {
            messages = database.GetCollection<Message>("message");
        }

        public Task<ICollection<Message>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Message message)
        {
            await messages.InsertOneAsync(message);
        }
    }
}