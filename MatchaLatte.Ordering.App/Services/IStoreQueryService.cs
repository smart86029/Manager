using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.App.Queries;
using MatchaLatte.Ordering.App.Queries.Stores;

namespace MatchaLatte.Ordering.App.Services
{
    /// <summary>
    /// 店家查詢服務。
    /// </summary>
    public interface IStoreQueryService
    {
        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>所有店家。</returns>
        Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option);

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        Task<StoreDetail> GetStoreAsync(Guid storeId);

        /// <summary>
        /// 取得新店家。
        /// </summary>
        /// <returns>新店家。</returns>
        Task<StoreDetail> GetNewStoreAsync();

        /// <summary>
        /// 取得商標檔案名稱。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>商標檔案名稱。</returns>
        Task<string> GetLogoFileNameAsync(Guid storeId);
    }
}