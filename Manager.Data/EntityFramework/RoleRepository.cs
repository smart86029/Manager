using System.Data.Entity;
using Manager.Models.System;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 角色倉儲。
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