using System.Data.Entity;
using Manager.Models;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 使用者倉儲類別。
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// 初始化 <see cref="UserRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public UserRepository(DbContext db) : base(db)
        {
        }
    }
}