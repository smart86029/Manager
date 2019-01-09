using System;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件。
    /// </summary>
    public abstract class Event
    {
        public Event() : this(Guid.NewGuid(), DateTime.UtcNow)
        {
        }

        public Event(Guid eventId, DateTime createdOn)
        {
            EventId = eventId;
            CreatedOn = createdOn;
        }

        public Guid EventId { get; private set; }

        public DateTime CreatedOn { get; private set; }
    }
}