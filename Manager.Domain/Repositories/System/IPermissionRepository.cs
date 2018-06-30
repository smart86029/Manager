using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Domain.Models.System;

namespace Manager.Domain.Repositories.System
{
    /// <summary>
    /// 權限存放庫介面。
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 取得所有權限。
        /// </summary>
        /// <returns>所有權限。</returns>
        Task<ICollection<Permission>> GetPermissionsAsync(Expression<Func<Permission, bool>> criteria);
    }
}