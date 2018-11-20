using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.ViewModels;
using MatchaLatte.Identity.App.ViewModels.Permission;

namespace MatchaLatte.Identity.App.Services
{
    /// <summary>
    /// 權限服務。
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>所有權限。</returns>
        Task<PaginationResult<PermissionSummary>> GetPermissionsAsync(PaginationOption option);

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        Task<PermissionDetail> GetPermissionAsync(Guid permissionId);

        /// <summary>
        /// 新增權限。
        /// </summary>
        /// <param name="option">新增權限選項。</param>
        /// <returns>權限。</returns>
        Task<PermissionDetail> CreatePermissionAsync(CreatePermissionOption option);

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="option">更新權限選項。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdatePermissionAsync(UpdatePermissionOption option);
    }
}