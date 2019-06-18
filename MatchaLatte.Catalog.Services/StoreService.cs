using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Stores;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Stores;
using MatchaLatte.Catalog.App.Services;
using MatchaLatte.Catalog.Domain;

namespace MatchaLatte.Catalog.Services
{
    public class StoreService : IStoreService
    {
        public StoreService(ICatalogUnitOfWork unitOfWork, PictureSettings pictureSettings)
        {

        }

        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>店家的集合。</returns>
        public Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public Task<StoreDetail> GetStoreAsync(Guid storeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得新店家。
        /// </summary>
        /// <returns>新店家。</returns>
        public Task<StoreDetail> GetNewStoreAsync()
        {
            var result = new StoreDetail
            {
                ProductCategories = new List<ProductCategoryDetail>
                {
                    new ProductCategoryDetail
                    {
                        Name = "Default",
                        IsDefault = true
                    }
                }
            };

            return Task.FromResult(result);
        }

        /// <summary>
        /// 取得商標檔案名稱。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>商標檔案名稱。</returns>
        public Task<string> GetLogoFileNameAsync(Guid storeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="command">新增店家命令。</param>
        /// <returns>使用者。</returns>
        public Task<StoreDetail> CreateStoreAsync(CreateStoreCommand command)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="command">更新店家命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public Task<bool> UpdateStoreAsync(UpdateStoreCommand command)
        {
            throw new NotImplementedException();
        }
    }
}