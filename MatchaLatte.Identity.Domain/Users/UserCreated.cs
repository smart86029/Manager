using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Users
{
    public class UserCreated : DomainEvent
    {
        public UserCreated(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}