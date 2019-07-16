using System;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件。
    /// </summary>
    public abstract class Event
    {
        public Guid Id { get; private set; } = GuidUtility.NewGuid();

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    }
}