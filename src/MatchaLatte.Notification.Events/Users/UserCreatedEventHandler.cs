using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.Notification.App.Users;
using MatchaLatte.Notification.Domain.Members;

namespace MatchaLatte.Notification.Events.Users
{
    public class UserCreatedEventHandler : IEventHandler<UserCreated>
    {
        private readonly IMemberRepository memberRepository;

        public UserCreatedEventHandler(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
        }

        public async Task HandleAsync(UserCreated @event)
        {
            var member = new Member(@event.Id, @event.DisplayName);

            await memberRepository.AddAsync(member);
        }
    }
}