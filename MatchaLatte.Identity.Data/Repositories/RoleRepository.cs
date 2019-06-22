using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Identity.Data.Repositories
{
    /// <summary>
    /// 角色存放庫。
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityContext context;

        /// <summary>
        /// 初始化 <see cref="RoleRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">身分識別內容。</param>
        public RoleRepository(IdentityContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>
        public async Task<ICollection<Role>> GetRolesAsync()
        {
            return await context.Set<Role>().ToListAsync();
        }

        /// <summary>
        /// 取得所有符合條件的角色。
        /// </summary>
        /// <param name="criteria">條件。</param>
        /// <returns>所有符合條件的角色。</returns>
        public async Task<ICollection<Role>> GetRolesAsync(Expression<Func<Role, bool>> criteria)
        {
            return await context.Set<Role>().Where(criteria).ToListAsync();
        }

        /// <summary>
        /// 取得指定筆數的角色。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>指定筆數的角色。</returns>
        public async Task<ICollection<Role>> GetRolesAsync(int offset, int limit)
        {
            return await context.Set<Role>().Skip(offset).Take(limit).ToListAsync();
        }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        public async Task<Role> GetRoleAsync(Guid roleId)
        {
            return await context.Set<Role>().Include(r => r.RolePermissions).SingleOrDefaultAsync(r => r.Id == roleId);
        }

        /// <summary>
        /// 取得所有角色的數量。
        /// </summary>
        /// <returns>所有角色的數量。</returns>
        public async Task<int> GetCountAsync()
        {
            return await context.Set<Role>().CountAsync();
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