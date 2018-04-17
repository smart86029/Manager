using Manager.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 菜單存放庫類別。
    /// </summary>
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        /// <summary>
        /// 初始化 <see cref="MenuRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public MenuRepository(DbContext db) : base(db)
        {
        }
    }
}