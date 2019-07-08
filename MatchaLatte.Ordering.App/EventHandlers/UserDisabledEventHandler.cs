using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Events;
using MatchaLatte.Ordering.App.Events;

namespace MatchaLatte.Ordering.App.EventHandlers
{
    public class UserDisabledEventHandler : IEventHandler<UserDisabled>
    {
        public Task HandleAsync(UserDisabled @event)
        {
            Console.WriteLine("A");

            return Task.CompletedTask;
        }
    }
}
