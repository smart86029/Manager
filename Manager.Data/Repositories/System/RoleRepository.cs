using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.Repositories.System
{
    /// <summary>
    /// 角色存放庫。
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly SystemContext context;

        /// <summary>
        /// 初始化 <see cref="RoleRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">系統內容。</param>
        public RoleRepository(SystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        public async Task<ICollection<Role>> GetRolesAsync(Expression<Func<Role, bool>> criteria)
        {
            var query = context.Set<Role>().AsQueryable();
            if (criteria != null)
                query = query.Where(criteria);

            return await query.ToListAsync();
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        public async Task<Role> GetRoleAsync(int roleId)
        {
            return await context.Set<Role>().Include(r => r.RolePermissions).SingleOrDefaultAsync(r => r.RoleId == roleId);
        }

        /// <summary>
        /// 加入角色。
        /// </summary>
        /// <param name="role">角色。</param>
        public void Add(Role role)
        {
            context.Set<Role>().Add(role);
        }

        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="role">角色。</param>
        public void Update(Role role)
        {
            context.Entry(role).State = EntityState.Modified;
        }
    }
}