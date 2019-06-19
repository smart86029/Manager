using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Stores
{
    /// <summary>
    /// 店家存放庫。
    /// </summary>
    public interface IStoreRepository : IRepository<Store>
    {
        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="offset">略過的筆數。</param>
        /// <param name="limit">限制的筆數。</param>
        /// <returns>店家的集合。</returns>
        Task<ICollection<Store>> GetStoresAsync(int offset, int limit);

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        Task<Store> GetStoreAsync(Guid storeId);

        /// <summary>
        /// 取得所有店家的數量。
        /// </summary>
        /// <returns>所有店家的數量。</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 加入店家。
        /// </summary>
        /// <param name="store">店家。</param>
        void Add(Store store);

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="store">店家。</param>
        void Update(Store store);
    }
}