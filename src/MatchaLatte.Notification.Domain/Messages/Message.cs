using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Notification.Domain.Messages
{
    public class Message : AggregateRoot
    {
        private Message()
        {
        }

        public Message(Guid senderId, Guid receiverId, string content, DateTime sentOn)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content.Trim();
            SentOn = sentOn.ToUniversalTime();
        }

        /// <summary>
        /// 取得寄件者 ID。
        /// </summary>
        public Guid SenderId { get; private set; }

        /// <summary>
        /// 取得收件者 ID。
        /// </summary>
        public Guid ReceiverId { get; private set; }

        /// <summary>
        /// 取得內容。
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// 取得寄件時間。
        /// </summary>
        public DateTime SentOn { get; private set; }

        /// <summary>
        /// 取得建立時間。
        /// </summary>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    }
}