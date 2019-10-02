using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Ordering.App.Users
{
    public class UserCreated : Event
    {
        public UserCreated(Guid userId, string name, string displayName)
        {
            UserId = userId;
            Name = name;
            DisplayName = displayName;
        }

        public Guid UserId { get; private set; }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }
    }
}