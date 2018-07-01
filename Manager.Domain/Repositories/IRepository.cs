namespace Manager.Domain.Repositories
{
    /// <summary>
    /// 存放庫。
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根。</typeparam>
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
    }
}