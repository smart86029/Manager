using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.GroupBuying;
using Manager.Domain.Models.Generic;
using Manager.Domain.Models.GroupBuying;
using Manager.Domain.Repositories.GroupBuying;
using Manager.Domain.Repositories.System;

namespace Manager.Commands.GroupBuying
{
    public class UpdateStoreCommandHandler : ICommandHandler<UpdateStoreCommand, bool>
    {
        private readonly IGroupBuyingUnitOfWork unitOfWork;
        private readonly IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="UpdateStoreCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        public UpdateStoreCommandHandler(IGroupBuyingUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<bool> HandleAsync(ICommand command)
        {
            var updateStoreCommand = command as UpdateStoreCommand ?? throw new NotSupportedException();
            var store = await storeRepository.GetStoreAsync(updateStoreCommand.StoreId);

            store.UpdateName(updateStoreCommand.Name);
            store.UpdateDescription(updateStoreCommand.Description);
            store.UpdatePhone(new Phone(updateStoreCommand.Phone));
            store.UpdateAddress(new Address(updateStoreCommand.Address));
            store.UpdateRemark(updateStoreCommand.Remark);

            foreach (var c in updateStoreCommand.ProductCategories)
            {
                var productCategory = c.ProductCategoryId > 0 ?
                    store.ProductCategories.Single(x => x.ProductCategoryId == c.ProductCategoryId) : new ProductCategory(c.Name);
                foreach (var p in c.Products)
                {
                    var product = p.ProductId > 0 ?
                        productCategory.Products.Single(x => x.ProductId == p.ProductId) : new Product(p.Name, p.Description);
                    foreach (var i in p.ProductItems)
                    {
                        var productItem = i.ProductItemId > 0 ?
                            product.ProductItems.Single(x => x.ProductItemId == i.ProductItemId) : new ProductItem(i.Name, i.Price);

                        if (i.ProductItemId > 0)
                        {
                            productItem.UpdateName(i.Name);
                            productItem.UpdatePrice(i.Price);
                        }
                        else
                            product.AddProductItem(productItem);
                    }

                    if (p.ProductId > 0)
                    {
                        product.UpdateName(p.Name);
                        product.UpdateDescription(p.Description);
                    }
                    else
                        productCategory.AddProduct(product);
                }

                if (c.ProductCategoryId > 0)
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