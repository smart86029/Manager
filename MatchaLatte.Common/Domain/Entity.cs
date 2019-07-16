using System;
using System.Collections.Generic;
using MatchaLatte.Common.Utilities;

namespace MatchaLatte.Common.Domain
{
    /// <summary>
    /// 實體。
    /// </summary>
    public abstract class Entity
    {
        private Queue<DomainEvent> domainEvents = new Queue<DomainEvent>();

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid Id { get; protected set; } = GuidUtility.NewGuid();

        /// <summary>
        /// 取得領域事件的集合。
        /// </summary>
        public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents;

        /// <summary>
        /// 引發領域事件。
        /// </summary>
        /// <param name="domainEvent">領域事件。</param>
        public void RaiseDomainEvent(DomainEvent domainEvent)
        {
            domainEvents.Enqueue(domainEvent);
        }

        /// <summary>
        /// 同意變更。
        /// </summary>
        public void AcceptChanges()
        {
            domainEvents.Clear();
        }
    }
}