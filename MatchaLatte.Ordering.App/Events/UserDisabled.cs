using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Ordering.App.Events
{
    public class UserDisabled : Event
    {
        public UserDisabled(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}