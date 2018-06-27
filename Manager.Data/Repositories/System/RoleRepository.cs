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
                query.Where(criteria);

            return await query.ToListAsync();
        }
    }
}