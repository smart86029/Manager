using System;
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
        /// <param name="option">分頁選項。</param>
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
        /// 取得商標檔案名稱。
        /// </summary>
        /// <param name="storeId">店家 ID。</param>
        /// <returns>商標檔案名稱。</returns>
        public async Task<string> GetLogoFileNameAsync(Guid storeId)
        {
            var store = await storeRepository.GetLogoAsync(storeId);

            return store.FileName;
        }

        /// <summary>
        /// 建立店家。
        /// </summary>
        /// <param name="command">建立店家命令。</param>
        /// <returns>店家。</returns>
        public async Task<StoreDetail> CreateStoreAsync(CreateStoreCommand command)
        {
            var store = new Store(command.Name, command.Description, new Picture(""), new Phone(command.Phone),
                new Address(command.Address.City, command.Address.City, command.Address.City), command.Remark, Guid.Empty);

            foreach (var c in command.ProductCategories)
            {
                store.AddProductCategory(c.Name);
                var productCategory = store.ProductCategories.Last();
                foreach (var p in c.Products)
                {
                    var product = new Product(p.Name, p.Description);
                    foreach (var i in p.ProductItems)
                    {
                        product.AddProductItem(i.Name, i.Price);
                    }

                    productCategory.AddProduct(product);
                }
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
                var productCategory = default(ProductCategory);
                if (c.Id == default)
                {
                    store.AddProductCategory(c.Name);
                    productCategory = store.ProductCategories.Last();
                }
                else
                {
                    productCategory = store.ProductCategories.Single(x => x.Id == c.Id);
                    productCategory.UpdateName(c.Name);
                }

                foreach (var p in c.Products)
                {
                    var product = default(Product);
                    if (p.Id == default)
                    {
                        product = new Product(p.Name, p.Description);
                        productCategory.AddProduct(product);
                    }
                    else
                    {
                        product = productCategory.Products.Single(x => x.Id == p.Id);
                        product.UpdateName(p.Name);
                        product.UpdateDescription(p.Description);
                    }

                    foreach (var i in p.ProductItems)
                    {
                        if (i.Id == default)
                        {
                            product.AddProductItem(i.Name, i.Price);
                        }
                        else
                        {
                            var productItem = product.ProductItems.Single(x => x.Id == i.Id);
                            productItem.UpdateName(i.Name);
                            productItem.UpdatePrice(i.Price);
                        }
                    }

                    var productItemIdsExist = p.ProductItems.Select(x => x.Id);
                    var productItemToRemove = product.ProductItems.Where(x => productItemIdsExist.Contains(x.Id)).ToList();
                    foreach (var i in productItemToRemove)
                        product.RemoveProductItem(i);
                }

                var productIdsExist = c.Products.Select(x => x.Id);
                var productToRemove = productCategory.Products.Where(x => !productIdsExist.Contains(x.Id)).ToList();
                foreach (var p in productToRemove)
                    productCategory.RemoveProduct(p);
            }

            var productCategoryIdsExist = command.ProductCategories.Select(x => x.Id);
            var productCategoryToRemove = store.ProductCategories.Where(x => !productCategoryIdsExist.Contains(x.Id)).ToList();
            foreach (var c in productCategoryToRemove)
                store.RemoveProductCategory(c);

            storeRepository.Update(store);
            await unitOfWork.CommitAsync();

            return true;
        }
    }
}