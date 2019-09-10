using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Stores;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Stores;

namespace MatchaLatte.Catalog.App.Services
{
    public interface IStoreService
    {
        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="option">分頁選項。</param>
        /// <returns>店家的集合。</returns>
        Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option);

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        Task<StoreDetail> GetStoreAsync(Guid storeId);

        /// <summary>
        /// 取得商標檔案名稱。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>商標檔案名稱。</returns>
        Task<string> GetLogoFileNameAsync(Guid storeId);

        /// <summary>
        /// 建立店家。
        /// </summary>
        /// <param name="command">建立店家命令。</param>
        /// <returns>店家。</returns>
        Task<StoreDetail> CreateStoreAsync(CreateStoreCommand command);

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="command">更新店家命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateStoreAsync(UpdateStoreCommand command);
    }
}