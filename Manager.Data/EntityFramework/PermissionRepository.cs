using Manager.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 權限存放庫。
    /// </summary>
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        /// <summary>
        /// 初始化 <see cref="PermissionRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public PermissionRepository(DbContext db) : base(db)
        {
        }
    }
}