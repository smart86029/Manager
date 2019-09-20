using System;
using System.Threading.Tasks;
using MatchaLatte.Notification.App.Messages;
using Microsoft.AspNetCore.SignalR;

namespace MatchaLatte.Notification.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService messageService;

        public ChatHub(IMessageService messageService)
        {
            this.messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        public async Task SendMessage(string user, string message)
        {
            var command = new CreateMessageCommand { SenderId = Guid.Empty, ReceiverId = Guid.Empty, Content = message, SentOn = DateTime.UtcNow };
            await messageService.CreateMessageAsync(command);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}