using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.Domain.Groups;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Ordering.Data.Repositories
{
    /// <summary>
    /// 團存放庫。
    /// </summary>
    public class GroupRepository : IGroupRepository
    {
        private readonly OrderingContext context;

        /// <summary>
        /// 初始化 <see cref="GroupRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">訂購內容。</param>
        public GroupRepository(OrderingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        public async Task<Group> GetGroupAsync(Guid groupId)
        {
            return await context.Set<Group>().SingleOrDefaultAsync(s => s.GroupId == groupId);
        }

        /// <summary>
        /// 加入團。
        /// </summary>
        /// <param name="group">團。</param>
        public void Add(Group group)
        {
            context.Set<Group>().Add(group);
        }

        /// <summary>
        /// 更新團。
        /// </summary>
        /// <param name="group">團。</param>
        public void Update(Group group)
        {
            context.Entry(group).State = EntityState.Modified;
        }
    }
}