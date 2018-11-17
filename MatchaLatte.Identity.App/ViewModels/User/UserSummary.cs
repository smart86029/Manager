using System;

namespace MatchaLatte.Identity.App.ViewModels.User
{
    public class UserSummary
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
    }
}