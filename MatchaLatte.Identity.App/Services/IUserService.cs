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
        /// <param name="option">分頁選項。</param>
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

        /// <summary>
        /// 新增使用者。
        /// </summary>
        /// <param name="option">新增使用者選項。</param>
        /// <returns>使用者。</returns>
        Task<UserDetail> CreateUserAsync(CreateUserOption option);

        /// <summary>
        /// 更新使用者。
        /// </summary>
        /// <param name="option">更新使用者選項。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateUserAsync(UpdateUserOption option);
    }
}