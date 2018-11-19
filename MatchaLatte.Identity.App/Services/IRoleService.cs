using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.Role;

namespace MatchaLatte.Identity.App.Services
{
    /// <summary>
    /// 角色服務。
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有角色。</returns>
        Task<PaginationResult<RoleSummary>> GetRolesAsync(PaginationOption option);

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        Task<RoleDetail> GetRoleAsync(Guid roleId);

        /// <summary>
        /// 取得新角色。
        /// </summary>
        /// <returns>新角色。</returns>
        Task<RoleDetail> GetNewRoleAsync();

        /// <summary>
        /// 新增角色。
        /// </summary>
        /// <param name="option">新增角色選項。</param>
        /// <returns>角色。</returns>
        Task<RoleDetail> CreateRoleAsync(CreateRoleOption option);

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="option">更新角色選項。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateRoleAsync(UpdateRoleOption option);
    }
}