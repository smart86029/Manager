namespace Manager.Domain.Repositories
{
    /// <summary>
    /// 倉儲介面。
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根。</typeparam>
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
    }
}