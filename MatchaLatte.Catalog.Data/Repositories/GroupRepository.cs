using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Domain.Groups;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Catalog.Data.Repositories
{
    /// <summary>
    /// 團存放庫。
    /// </summary>
    public class GroupRepository : IGroupRepository
    {
        private readonly CatalogContext context;

        /// <summary>
        /// 初始化 <see cref="GroupRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">目錄內容。</param>
        public GroupRepository(CatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得團的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>團的集合。</returns>
        public async Task<ICollection<Group>> GetGroupsAsync(int offset, int limit)
        {
            var result = await context
                .Set<Group>()
                .Include(g => g.Store)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// 取得進行中團的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>進行中團的集合。</returns>
        public async Task<ICollection<Group>> GetActiveGroupsAsync(int offset, int limit)
        {
            var result = await context
                .Set<Group>()
                .Include(g => g.Store)
                .Where(g => g.StartOn <= DateTime.UtcNow && g.EndOn > DateTime.UtcNow)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// 取得團。
        /// </summary>
        /// <param name="groupId">團 ID。</param>
        /// <returns>團。</returns>
        public async Task<Group> GetGroupAsync(Guid groupId)
        {
            var result = await context
                .Set<Group>()
                .Include(g => g.Store)
                .SingleOrDefaultAsync(s => s.Id == groupId);

            return result;
        }

        /// <summary>
        /// 取得所有團的數量。
        /// </summary>
        /// <returns>所有團的數量。</returns>
        public async Task<int> GetGroupsCountAsync()
        {
            return await context.Set<Group>().CountAsync();
        }

        /// <summary>
        /// 取得所有進行中團的數量。
        /// </summary>
        /// <returns>所有進行中團的數量。</returns>
        public async Task<int> GetActiveGroupsCountAsync()
        {
            var result = await context
                .Set<Group>()
                .CountAsync(g => g.StartOn <= DateTime.UtcNow && g.EndOn > DateTime.UtcNow);

            return result;
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