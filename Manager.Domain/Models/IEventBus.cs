using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain
{
    public interface IEventBus
    {
        Task PublishAsync(IDomainEvent domainEvent);

        //void Subscribe<T, TH>() where T : IDomainEvent where TH : IDomainEventHandler<T>;
    }
}
