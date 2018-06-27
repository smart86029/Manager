using System.Threading.Tasks;
using Manager.Domain.Models.System;

namespace Manager.Domain.Repositories.System
{
    /// <summary>
    /// 使用者存放庫介面。
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        Task<User> GetUserAsync(int userId);

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="passwordHash">密碼雜湊。</param>
        /// <returns>使用者。</returns>
        Task<User> GetUserAsync(string userName, string passwordHash);

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        void Create(User user);

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="user">使用者。</param>
        void Update(User user);
    }
}