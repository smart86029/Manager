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
        /// <param name="option">分頁查詢。</param>
        /// <returns>店家的集合。</returns>
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

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="command">新增店家命令。</param>
        /// <returns>使用者。</returns>
        Task<StoreDetail> CreateUserAsync(CreateStoreCommand command);

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="command">更新店家命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        Task<bool> UpdateUserAsync(UpdateStoreCommand command);
    }
}