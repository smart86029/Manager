using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Domain.Stores;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Catalog.Data.Repositories
{
    /// <summary>
    /// 店家存放庫。
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        private readonly CatalogContext context;

        /// <summary>
        /// 初始化 <see cref="StoreRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">訂購內容。</param>
        public StoreRepository(CatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public async Task<Store> GetStoreAsync(Guid storeId)
        {
            var store = await context.Set<Store>()
                .Include(s => s.ProductCategories)
                    .ThenInclude(c => c.Products)
                    .ThenInclude(p => p.ProductItems)
                .SingleOrDefaultAsync(s => s.StoreId == storeId);

            return store;
        }

        /// <summary>
        /// 加入店家。
        /// </summary>
        /// <param name="store">店家。</param>
        public void Add(Store store)
        {
            context.Set<Store>().Add(store);
        }

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="store">店家。</param>
        public void Update(Store store)
        {
            context.Entry(store).State = EntityState.Modified;
        }
    }
}