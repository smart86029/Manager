using System;
using System.Threading.Tasks;
using Manager.Domain.Models.GroupBuying;
using Manager.Domain.Repositories.GroupBuying;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.Repositories.GroupBuying
{
    /// <summary>
    /// 店家存放庫。
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        private readonly GroupBuyingContext context;

        /// <summary>
        /// 初始化 <see cref="StoreRepository"/> 類別的新執行個體。
        /// </summary>
        /// <param name="context">團購內容。</param>
        public StoreRepository(GroupBuyingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public Task<Store> GetStoreAsync(int storeId)
        {
            throw new NotImplementedException();
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