using System;
using System.Threading.Tasks;
using MatchaLatte.Notification.App.Members;
using MatchaLatte.Notification.App.Messages;
using Microsoft.AspNetCore.SignalR;

namespace MatchaLatte.Notification.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMemberService memberService;
        private readonly IMessageService messageService;

        public ChatHub(IMemberService memberService, IMessageService messageService)
        {
            this.memberService = memberService ?? throw new ArgumentNullException(nameof(memberService));
            this.messageService = messageService ?? throw new ArgumentNullException(nameof(messageService));
        }

        public async Task GetMembers()
        {
            var members = await memberService.GetMembersAsync();
            await Clients.Caller.SendAsync("ReceiveMembers", members);

            var a = Context.User.Identity;
            var b = 1;
        }

        public async Task SendMessage(string user, string message)
        {
            var command = new CreateMessageCommand
            {
                SenderId = Guid.Empty,
                ReceiverId = Guid.Empty,
                Content = message,
                SentOn = DateTime.UtcNow
            };
            await messageService.CreateMessageAsync(command);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}