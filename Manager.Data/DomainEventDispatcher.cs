using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Manager.Domain;
using Manager.Domain.Models.System;
namespace Manager.Data
{
    public class DomainEventDispatcher
    {
        private ILifetimeScope scope;

        public DomainEventDispatcher(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public async Task DispatchAsync<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : class, IDomainEvent
        {
            var handlers = scope.Resolve(typeof(IEnumerable<IDomainEventHandler<TDomainEvent>>)) as IEnumerable<IDomainEventHandler<TDomainEvent>>;
            var b = GetInstances<IDomainEventHandler<TDomainEvent>>();
            var a = scope.Resolve<IEnumerable<IDomainEventHandler<UserCreated>>>();
            //var c = Activator.CreateInstance()
            foreach (var handler in handlers)
                await handler.Handle();

            //return Task.CompletedTask;
        }

        private IEnumerable<T> GetInstances<T>()
        {
            return scope.Resolve(typeof(IEnumerable<T>)) as IEnumerable<T>;
        }
    }
}
