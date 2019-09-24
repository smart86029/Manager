using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchaLatte.Notification.App.Messages
{
    public interface IMessageService
    {
        Task<ICollection<MessageDetail>> GetMessagesAsync();

        Task CreateMessageAsync(CreateMessageCommand command);
    }
}