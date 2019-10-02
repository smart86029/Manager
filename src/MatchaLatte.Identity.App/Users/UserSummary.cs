using System;

namespace MatchaLatte.Identity.App.Users
{
    public class UserSummary
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public bool IsEnabled { get; set; }
    }
}