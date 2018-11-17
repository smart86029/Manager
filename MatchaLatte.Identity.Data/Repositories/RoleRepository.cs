using System;
using System.Collections.Generic;
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
        /// 取得角色。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <returns>角色。</returns>
        public async Task<Role> GetRoleAsync(Guid roleId)
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