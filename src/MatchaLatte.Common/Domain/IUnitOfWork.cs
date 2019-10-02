using System.Threading.Tasks;

namespace MatchaLatte.Common.Domain
{
    /// <summary>
    /// 工作單元。
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