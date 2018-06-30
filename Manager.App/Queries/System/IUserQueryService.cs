using System.Threading.Tasks;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.App.Queries.System
{
    /// <summary>
    /// 使用者查詢服務介面。
    /// </summary>
    public interface IUserQueryService
    {
        /// <summary>
        /// 取得所有使用者。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有使用者。</returns>
        Task<PaginationResult<UserSummary>> GetUsersAsync(PaginationOption option);

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <returns>使用者。</returns>
        Task<User> GetUserAsync(int userId);

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        Task<User> GetNewUserAsync();
    }
}