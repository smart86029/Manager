using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Stores;
using MatchaLatte.Ordering.App.Queries.Stores;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Products;
using MatchaLatte.Ordering.Domain.Stores;

namespace MatchaLatte.Ordering.Commands.Stores
{
    /// <summary>
    /// 新增店家命令處理常式。
    /// </summary>
    public class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, StoreDetail>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="CreateStoreCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        public CreateStoreCommandHandler(IOrderingUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">新增店家命令。</param>
        /// <returns>店家。</returns>
        public async Task<StoreDetail> HandleAsync(CreateStoreCommand command)
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
                StoreId = store.StoreId,
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
    }
}