using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 店家存放庫。
    /// </summary>
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        /// <summary>
        /// 初始化 <see cref="StoreRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="db">內容執行個體。</param>
        public StoreRepository(DbContext db) : base(db)
        {
        }

        public override async Task<Store> SingleOrDefaultAsync(Expression<Func<Store, bool>> predicate, params Expression<Func<Store, object>>[] paths)
        {
            var result = Context.Set<Store>()
                .Include(s => s.ProductCategories)
                .ThenInclude(c => c.Products)
                .ThenInclude(p => p.ProductItems)
                .FirstOrDefaultAsync(predicate);

            return await result;
        }
    }
}