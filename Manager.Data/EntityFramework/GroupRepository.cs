using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 團存放庫。
    /// </summary>
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        /// <summary>
        /// 初始化 <see cref="GroupRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public GroupRepository(DbContext db) : base(db)
        {
        }
    }
}