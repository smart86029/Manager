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
    /// 權限存放庫。
    /// </summary>
    public class PermissionRepository : IPermissionRepository
    {
        private readonly SystemContext context;

        /// <summary>
        /// 初始化 <see cref="PermissionRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">系統內容。</param>
        public PermissionRepository(SystemContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <returns>所有權限。</returns>
        public async Task<ICollection<Permission>> GetPermissionsAsync(Expression<Func<Permission, bool>> criteria)
        {
            var query = context.Set<Permission>().AsQueryable();
            if (criteria != null)
                query = query.Where(criteria);

            return await query.ToListAsync();
        }
    }
}