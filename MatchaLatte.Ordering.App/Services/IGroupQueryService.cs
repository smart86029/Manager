using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Groups;

namespace MatchaLatte.Ordering.App.Services
{
    /// <summary>
    /// 團查詢服務。
    /// </summary>
    public interface IGroupQueryService
    {
        /// <summary>
        /// 取得所有團。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有團。</returns>
        Task<PaginationResult<GroupSummary>> GetGroupsAsync(PaginationOption option);

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        Task<GroupDetail> GetGroupAsync(Guid groupId);

        /// <summary>
        /// 取得新團。
        /// </summary>
        /// <returns>新團。</returns>
        Task<GroupDetail> GetNewGroupAsync();
    }
}