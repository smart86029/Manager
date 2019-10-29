using System;

namespace MatchaLatte.Notification.App.Members
{
    public class CreateMemberCommand
    {
        public Guid UserId { get; set; }

        public string DisplayName { get; set; }
    }
}