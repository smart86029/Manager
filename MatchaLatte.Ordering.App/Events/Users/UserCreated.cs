using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Ordering.App.Events.Users
{
    public class UserCreated : Event
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