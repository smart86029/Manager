using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.App.Commands.Stores;
using MatchaLatte.Catalog.App.Queries;
using MatchaLatte.Catalog.App.Queries.Stores;
using MatchaLatte.Catalog.App.Services;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Catalog.Domain.Products;
using MatchaLatte.Catalog.Domain.Stores;

namespace MatchaLatte.Catalog.Services
{
    /// <summary>
    /// 店家服務。
    /// </summary>
    public class StoreService : IStoreService
    {
        private ICatalogUnitOfWork unitOfWork;
        private IStoreRepository storeRepository;
        private PictureSettings pictureSettings;

        /// <summary>
        /// 初始化 <see cref="StoreService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        /// <param name="pictureSettings">圖片設定。</param>
        public StoreService(ICatalogUnitOfWork unitOfWork, IStoreRepository storeRepository, PictureSettings pictureSettings)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            this.pictureSettings = pictureSettings ?? throw new ArgumentNullException(nameof(pictureSettings));
        }

        /// <summary>
        /// 取得店家的集合。
        /// </summary>
        /// <param name="option">分頁查詢。</param>
        /// <returns>店家的集合。</returns>
        public async Task<PaginationResult<StoreSummary>> GetStoresAsync(PaginationOption option)
        {
            var stores = await storeRepository.GetStoresAsync(option.Offset, option.Limit);
            var count = await storeRepository.GetCountAsync();
            var result = new PaginationResult<StoreSummary>
            {
                Items = stores
                    .Select(x => new StoreSummary
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        LogoUri = $"{pictureSettings.BaseUri}{x.Id}/logo"
                    })
                    .ToList(),
                ItemCount = count
            };

            return result;
        }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>店家。</returns>
        public async Task<StoreDetail> GetStoreAsync(Guid storeId)
        {
            var store = await storeRepository.GetStoreAsync(storeId);
            var result = new StoreDetail
            {
                Id = store.Id,
                Name = store.Name,
                Description = store.Description,
                Phone = store.Phone.PhoneNumber,
                Address = new AddressDetail
                {
                    PostalCode = store.Address.PostalCode,
                    Country = store.Address.Country,
                    City = store.Address.City,
                    District = store.Address.District,
                    Street = store.Address.Street
                },
                Remark = store.Remark,
                ProductCategories = store.ProductCategories
                    .Select(c => new ProductCategoryDetail
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsDefault = c.IsDefault,
                        Sequence = c.Sequence,
                        Products = c.Products
                            .Select(p => new ProductDetail
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Description = p.Description,
                                Sequence = p.Sequence,
                                ProductItems = p.ProductItems
                                    .Select(i => new ProductItemDetail
                                    {
                                        Id = i.Id,
                                        Name = i.Name,
                                        Price = i.Price
                                    })
                                    .ToList()
                            })
                            .ToList()
                    })
                    .ToList()
            };

            return result;
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
        public async Task<StoreDetail> CreateStoreAsync(CreateStoreCommand command)
        {
            var store = new Store(command.Name, command.Description, new Picture(""), new Phone(command.Phone),
                new Address(command.Address.City, command.Address.City, command.Address.City), command.Remark, Guid.Empty);

            foreach (var c in command.ProductCategories)
            {
                var productCategory = c.IsDefault ? store.ProductCategories.Single(x => x.IsDefault) : new ProductCategory(c.Name, false);
                foreach (var p in c.Products)
                {
                    var product = new Product(p.Name, p.Description);
                    foreach (var i in p.ProductItems)
                    {
                        var productItem = new ProductItem(i.Name, i.Price);
                        product.AddProductItem(productItem);
                    }

                    productCategory.AddProduct(product);
                }

                store.AddProductCategory(productCategory);
            }

            storeRepository.Add(store);
            await unitOfWork.CommitAsync();

            var result = new StoreDetail
            {
                Id = store.Id,
                Name = store.Name,
                Description = store.Description,
                Phone = store.Phone.PhoneNumber,
                Address = new AddressDetail
                {
                    PostalCode = store.Address.PostalCode,
                    Country = store.Address.Country,
                    City = store.Address.City,
                    District = store.Address.District,
                    Street = store.Address.Street
                },
                Remark = store.Remark
            };

            return result;
        }

        /// <summary>
        /// 更新店家。
        /// </summary>
        /// <param name="command">更新店家命令。</param>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> UpdateStoreAsync(UpdateStoreCommand command)
        {
            var store = await storeRepository.GetStoreAsync(command.id);

            store.UpdateName(command.Name);
            store.UpdateDescription(command.Description);
            store.UpdatePhone(new Phone(command.Phone));
            store.UpdateAddress(new Address(command.Address.City, command.Address.District, command.Address.Street));
            store.UpdateRemark(command.Remark);

            foreach (var c in command.ProductCategories)
            {
                var productCategory = c.id != Guid.Empty ?
                    store.ProductCategories.Single(x => x.Id == c.id) : new ProductCategory(c.Name, false);
                foreach (var p in c.Products)
                {
                    var product = p.id != Guid.Empty ?
                        productCategory.Products.Single(x => x.Id == p.id) : new Product(p.Name, p.Description);
                    foreach (var i in p.ProductItems)
                    {
                        var productItem = i.id != Guid.Empty ?
                            product.ProductItems.Single(x => x.Id == i.id) : new ProductItem(i.Name, i.Price);

                        if (i.id != Guid.Empty)
                        {
                            productItem.UpdateName(i.Name);
                            productItem.UpdatePrice(i.Price);
                        }
                        else
                            product.AddProductItem(productItem);
                    }

                    if (p.id != Guid.Empty)
                    {
                        product.UpdateName(p.Name);
                        product.UpdateDescription(p.Description);
                    }
                    else
                        productCategory.AddProduct(product);
                }

                if (c.id != Guid.Empty)
                    productCategory.UpdateName(c.Name);
                else
                    store.AddProductCategory(productCategory);
            }

            storeRepository.Update(store);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}