using System.Threading.Tasks;
using Manager.App.ViewModels;
using Manager.App.ViewModels.System;

namespace Manager.App.Queries.System
{
    /// <summary>
    /// 權限查詢服務。
    /// </summary>
    public interface IPermissionQueryService
    {
        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有權限。</returns>
        Task<PaginationResult<PermissionSummary>> GetPermissionsAsync(PaginationOption option);

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        Task<Permission> GetPermissionAsync(int permissionId);
    }
}