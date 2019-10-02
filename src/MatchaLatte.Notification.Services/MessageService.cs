using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Notification.App.Messages;
using MatchaLatte.Notification.Domain.Messages;

namespace MatchaLatte.Notification.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public Task<ICollection<MessageDetail>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task CreateMessageAsync(CreateMessageCommand command)
        {
            var message = new Message(command.SenderId, command.ReceiverId, command.Content, command.SentOn);

            await messageRepository.AddAsync(message);
        }
    }
}