using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain
{
    public interface IEventBus
    {
        void Publish(IDomainEvent domainEvent);

        //void Subscribe<T, TH>() where T : IDomainEvent where TH : IIntegrationEventHandler<T>;
    }
}
