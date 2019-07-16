using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Users
{
    public class UserDisabled : DomainEvent
    {
        public UserDisabled(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}