using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.User;

namespace MatchaLatte.Identity.App.Services
{
    /// <summary>
    /// 使用者服務。
    /// </summary>
    public interface IUserService
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
        Task<UserDetail> GetUserAsync(Guid userId);

        /// <summary>
        /// 取得新使用者。
        /// </summary>
        /// <returns>新使用者。</returns>
        Task<UserDetail> GetNewUserAsync();
    }
}