using System.Collections.Generic;

namespace Manager.Domain
{
    /// <summary>
    /// 實體。
    /// </summary>
    public abstract class Entity
    {
        private List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        /// <summary>
        /// 取得領域事件的集合。
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents;

        /// <summary>
        /// 加入領域事件。
        /// </summary>
        /// <param name="domainEvent">領域事件。</param>
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

        /// <summary>
        /// 移除領域事件。
        /// </summary>
        /// <param name="domainEvent">領域事件。</param>
        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents.Remove(domainEvent);
        }
    }
}