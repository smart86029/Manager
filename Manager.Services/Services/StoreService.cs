using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manager.Data;
using Manager.Models.GroupBuying;
using Manager.ViewModels.Stores;

namespace Manager.Services
{
    /// <summary>
    /// 店家服務。
    /// </summary>
    public class StoreService
    {
        private IUnitOfWork unitOfWork;
        private IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="StoreService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家倉儲。</param>
        public StoreService(IUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork;
            this.storeRepository = storeRepository;
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>符合的店家。</returns>
        public async Task<StoreResult> GetStoreAsync(int id)
        {
            var store = await storeRepository.FirstOrDefaultAsync(s => s.StoreId == id, s => s.Products);
            var result = new StoreResult
            {
                StoreId = store.StoreId,
                Name = store.Name,
                Description = store.Description,
                Phone = store.Phone,
                Address = store.Address,
                Remark = store.Remark,
                Products = store.Products.Select(p => new StoreResult.Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };

            return result;
        }

        /// <summary>
        /// 取得所有店家。
        /// </summary>
        /// <returns>所有店家。</returns>
        public async Task<ICollection<Store>> GetStoresAsync()
        {
            var stores = await storeRepository.ManyAsync(null);

            return stores.ToList();
        }

        /// <summary>
        /// 新增店家。
        /// </summary>
        /// <param name="store">要新增的店家。</param>
        /// <returns>新增成功傳回是，否則為否。</returns>
        /// <exception cref="ArgumentNullException"><paramref name="store"/> 為 null。</exception>
        public async Task<bool> CreateAsync(Store store)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            storeRepository.Create(store);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="store">要更新的店家。</param>
        /// <param name="selectedUsers">使用者清單選擇的使用者。</param>
        /// <returns>更新成功傳回是，否則為否。</returns>
        /// <<exception cref="ArgumentNullException"><paramref name="store"/> 為 null。</exception>
        public async Task<bool> UpdateAsync(Store store, string[] selectedUsers)
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));

            storeRepository.Update(store);
            await unitOfWork.CommitAsync();

            return true;
        }

        /// <summary>
        /// 刪除店家。
        /// </summary>
        /// <param name="id">指定的 Id。</param>
        /// <returns>刪除成功傳回是，否則為否。 如果找不到符合的店家，則這個方法也會傳回否。</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var store = await storeRepository.FindAsync(id);
            if (store == null)
                return false;

            storeRepository.Delete(store);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}