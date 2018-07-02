using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Domain.Models.System;

namespace Manager.Domain.Repositories.System
{
    /// <summary>
    /// 權限存放庫。
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <returns>所有權限。</returns>
        Task<ICollection<Permission>> GetPermissionsAsync(Expression<Func<Permission, bool>> criteria);

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <returns>權限。</returns>
        Task<Permission> GetPermissionAsync(int permissionId);

        /// <summary>
        /// 加入權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        void Add(Permission permission);

        /// <summary>
        /// 更新權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        void Update(Permission permission);
    }
}