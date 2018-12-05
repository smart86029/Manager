using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Groups
{
    /// <summary>
    /// 團存放庫。
    /// </summary>
    public interface IGroupRepository : IRepository<Group>
    {
        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        Task<Group> GetGroupAsync(Guid groupId);

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