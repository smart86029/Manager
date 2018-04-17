using Manager.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 角色存放庫。
    /// </summary>
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        /// <summary>
        /// 初始化 <see cref="RoleRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public RoleRepository(DbContext db) : base(db)
        {
        }
    }
}