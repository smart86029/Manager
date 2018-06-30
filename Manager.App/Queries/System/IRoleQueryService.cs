using System.Threading.Tasks;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.App.Queries.System
{
    /// <summary>
    /// 角色查詢服務介面。
    /// </summary>
    public interface IRoleQueryService
    {
        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有角色。</returns>
        Task<PaginationResult<RoleSummary>> GetRolesAsync(PaginationOption option);

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        Task<Role> GetRoleAsync(int roleId);
    }
}