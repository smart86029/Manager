using System;
using System.Threading.Tasks;
using MatchaLatte.Ordering.App.ViewModels;

namespace MatchaLatte.Ordering.App.Queries
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
        Task<Store> GetStoreAsync(Guid storeId);
    }
}