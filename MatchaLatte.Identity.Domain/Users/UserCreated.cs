using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Identity.Domain.Users
{
    public class UserCreated : DomainEvent
    {
        public UserCreated(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid UserId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}