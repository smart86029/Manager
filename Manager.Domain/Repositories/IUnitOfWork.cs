using System.Threading.Tasks;

namespace Manager.Domain.Repositories
{
    /// <summary>
    /// 工作單元介面。
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交認可。
        /// </summary>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> CommitAsync();
    }
}