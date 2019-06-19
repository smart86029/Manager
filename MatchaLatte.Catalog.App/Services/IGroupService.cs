using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Groups;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Groups;

namespace MatchaLatte.Catalog.App.Services
{
    /// <summary>
    /// 團服務。
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// 取得團的集合。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>團的集合。</returns>
        Task<PaginationResult<GroupSummary>> GetGroupsAsync(GroupOption option);

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        Task<GroupDetail> GetGroupAsync(Guid groupId);

        /// <summary>
        /// 新增團。
        /// </summary>
        /// <param name="command">新增團命令。</param>
        /// <returns>團。</returns>
        Task<GroupDetail> CreateGroupAsync(CreateGroupCommand command);

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="command">更新團命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateGroupAsync(UpdateGroupCommand command);
    }
}