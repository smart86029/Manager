using System.Threading.Tasks;

namespace Manager.Data
{
    /// <summary>
    /// 工作單元介面
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交認可到資料庫。
        /// </summary>
        void Commit();

        /// <summary>
        /// 非同步提交認可到資料庫。
        /// </summary>
        /// <returns>表示非同步提交認可作業的工作。</returns>
        Task CommitAsync();
    }
}