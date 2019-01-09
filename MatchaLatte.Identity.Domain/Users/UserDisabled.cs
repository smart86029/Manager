using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Identity.Domain.Users
{
    public class UserDisabled : Event, IDomainEvent
    {
        public UserDisabled(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}