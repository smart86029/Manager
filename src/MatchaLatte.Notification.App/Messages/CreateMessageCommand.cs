using System;

namespace MatchaLatte.Notification.App.Messages
{
    public class CreateMessageCommand
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }
    }
}