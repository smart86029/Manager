using System;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.GroupBuying;
using Manager.Domain.Models.Generic;
using Manager.Domain.Models.GroupBuying;
using Manager.Domain.Repositories.GroupBuying;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.GroupBuying
{
    public class CreateStoreCommandHandler : ICommandHandler<CreateStoreCommand, App.ViewModels.GroupBuying.Store>
    {
        private readonly IGroupBuyingUnitOfWork unitOfWork;
        private readonly IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="CreateStoreCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        public CreateStoreCommandHandler(IGroupBuyingUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<App.ViewModels.GroupBuying.Store> HandleAsync(ICommand command)
        {
            var createStoreCommand = command as CreateStoreCommand ?? throw new NotSupportedException();
            var store = new Store(createStoreCommand.Name, createStoreCommand.Description, new Phone(createStoreCommand.Phone),
                new Address(createStoreCommand.Address), createStoreCommand.Remark, 1);

            foreach (var c in createStoreCommand.ProductCategories)
            {
                var productCategory = new ProductCategory(c.Name);
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

            var result = new App.ViewModels.GroupBuying.Store
            {
                StoreId = store.StoreId,
                Name = store.Name,
                Description = store.Description,
                Phone = store.Phone.ToString(),
                Address = store.Address.ToString(),
                Remark = store.Remark
            };

            return result;
        }
    }
}