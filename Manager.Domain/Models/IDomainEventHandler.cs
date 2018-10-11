using System.Threading.Tasks;

namespace Manager.Domain
{
    public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        Task Handle();
    }
}