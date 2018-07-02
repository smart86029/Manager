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

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        public async Task<Permission> GetPermissionAsync(int permissionId)
        {
            return await context.Set<Permission>().Include(r => r.RolePermissions).SingleOrDefaultAsync(r => r.PermissionId == permissionId);
        }

        /// <summary>
        /// 加入權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        public void Add(Permission permission)
        {
            context.Set<Permission>().Add(permission);
        }

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        public void Update(Permission permission)
        {
            context.Entry(permission).State = EntityState.Modified;
        }
    }
}