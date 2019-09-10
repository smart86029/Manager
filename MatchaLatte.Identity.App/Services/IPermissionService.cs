using System;
using System.Threading.Tasks;
using MatchaLatte.Identity.App.Commands.Permissions;
using MatchaLatte.Identity.App.Queries;
using MatchaLatte.Identity.App.Queries.Permissions;

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
        /// 建立權限。
        /// </summary>
        /// <param name="command">建立權限命令。</param>
        /// <returns>權限。</returns>
        Task<PermissionDetail> CreatePermissionAsync(CreatePermissionCommand command);

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="command">更新權限命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdatePermissionAsync(UpdatePermissionCommand command);
    }
}