using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Notification.Domain.Messages
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<ICollection<Message>> GetMessagesAsync();

        Task AddAsync(Message message);
    }
}