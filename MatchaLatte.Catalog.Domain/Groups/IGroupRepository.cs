using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Groups
{
    /// <summary>
    /// 團存放庫。
    /// </summary>
    public interface IGroupRepository : IRepository<Group>
    {
        /// <summary>
        /// 取得團的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>團的集合。</returns>
        Task<ICollection<Group>> GetGroupsAsync(int offset, int limit);

        /// <summary>
        /// 取得進行中團的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>進行中團的集合。</returns>
        Task<ICollection<Group>> GetActiveGroupsAsync(int offset, int limit);

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        Task<Group> GetGroupAsync(Guid groupId);

        /// <summary>
        /// 取得所有團的數量。
        /// </summary>
        /// <returns>所有團的數量。</returns>
        Task<int> GetGroupsCountAsync();

        /// <summary>
        /// 取得所有進行中團的數量。
        /// </summary>
        /// <returns>所有進行中團的數量。</returns>
        Task<int> GetActiveGroupsCountAsync();

        /// <summary>
        /// 加入團。
        /// </summary>
        /// <param name="group">團。</param>
        void Add(Group group);

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="group">團。</param>
        void Update(Group group);
    }
}