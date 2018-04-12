using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 以 EntityFramework 實作的工作單元類別。
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;

        /// <summary>
        /// 初始化 <see cref="UnitOfWork"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 提交認可到資料庫。
        /// </summary>
        public void Commit()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// 非同步提交認可到資料庫。
        /// </summary>
        /// <returns>表示非同步提交認可作業的工作。</returns>
        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}