using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatchaLatte.Identity.Domain.Permissions;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Identity.Data.Repositories
{
    /// <summary>
    /// 權限存放庫。
    /// </summary>
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IdentityContext context;

        /// <summary>
        /// 初始化 <see cref="PermissionRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">身分識別內容。</param>
        public PermissionRepository(IdentityContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <returns>所有權限。</returns>
        public async Task<ICollection<Permission>> GetPermissionsAsync()
        {
            return await context.Set<Permission>().ToListAsync();
        }

        /// <summary>
        /// 取得所有符合條件的權限。
        /// </summary>
        /// <param name="criteria">條件。</param>
        /// <returns>所有符合條件的權限。</returns>
        public async Task<ICollection<Permission>> GetPermissionsAsync(Expression<Func<Permission, bool>> criteria)
        {
            return await context.Set<Permission>().Where(criteria).ToListAsync();
        }

        /// <summary>
        /// 取得指定筆數的權限。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>指定筆數的權限。</returns>
        public async Task<ICollection<Permission>> GetPermissionsAsync(int offset, int limit)
        {
            return await context.Set<Permission>().Skip(offset).Take(limit).ToListAsync();
        }

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        public async Task<Permission> GetPermissionAsync(Guid permissionId)
        {
            return await context.Set<Permission>().SingleOrDefaultAsync(p => p.PermissionId == permissionId);
        }

        /// <summary>
        /// 取得所有權限的數量。
        /// </summary>
        /// <returns>所有權限的數量。</returns>
        public async Task<int> GetCountAsync()
        {
            return await context.Set<Permission>().CountAsync();
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