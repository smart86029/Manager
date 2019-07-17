using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Domain;
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
        /// <param name="context">目錄內容。</param>
        public StoreRepository(CatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>店家的集合。</returns>
        public async Task<ICollection<Store>> GetStoresAsync(int offset, int limit)
        {
            var result = await context
                .Set<Store>()
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public async Task<Store> GetStoreAsync(Guid storeId)
        {
            var result = await context
                .Set<Store>()
                .Include(s => s.ProductCategories)
                .ThenInclude(c => c.Products)
                .ThenInclude(p => p.ProductItems)
                .SingleOrDefaultAsync(s => s.Id == storeId);

            return result;
        }

        /// <summary>
        /// 取得商標。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>商標。</returns>
        public async Task<Picture> GetLogoAsync(Guid storeId)
        {
            var result = await context
                .Set<Store>()
                .Where(s => s.Id == storeId)
                .Select(s => s.Logo)
                .SingleOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// 取得所有店家的數量。
        /// </summary>
        /// <returns>所有店家的數量。</returns>
        public async Task<int> GetCountAsync()
        {
            return await context.Set<Store>().CountAsync();
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