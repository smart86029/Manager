namespace Manager.Domain.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}