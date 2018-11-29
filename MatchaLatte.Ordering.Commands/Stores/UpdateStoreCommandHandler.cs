using System;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Commands.Stores;
using MatchaLatte.Ordering.Domain;
using MatchaLatte.Ordering.Domain.Products;
using MatchaLatte.Ordering.Domain.Stores;

namespace MatchaLatte.Ordering.Commands.Stores
{
    /// <summary>
    /// 修改店家命令處理常式。
    /// </summary>
    public class UpdateStoreCommandHandler : ICommandHandler<UpdateStoreCommand, bool>
    {
        private readonly IOrderingUnitOfWork unitOfWork;
        private readonly IStoreRepository storeRepository;

        /// <summary>
        /// 初始化 <see cref="CreateStoreCommandHandler"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="storeRepository">店家存放庫。</param>
        public UpdateStoreCommandHandler(IOrderingUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">修改店家命令。</param>
        /// <returns>成功返回為 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> HandleAsync(UpdateStoreCommand command)
        {
            var store = await storeRepository.GetStoreAsync(command.StoreId);

            store.UpdateName(command.Name);
            store.UpdateDescription(command.Description);
            store.UpdatePhone(new Phone(command.Phone));
            store.UpdateAddress(new Address(command.Address.City, command.Address.District, command.Address.Street));
            store.UpdateRemark(command.Remark);

            foreach (var c in command.ProductCategories)
            {
                var productCategory = c.ProductCategoryId != Guid.Empty ?
                    store.ProductCategories.Single(x => x.ProductCategoryId == c.ProductCategoryId) : new ProductCategory(c.Name, false);
                foreach (var p in c.Products)
                {
                    var product = p.ProductId != Guid.Empty ?
                        productCategory.Products.Single(x => x.ProductId == p.ProductId) : new Product(p.Name, p.Description);
                    foreach (var i in p.ProductItems)
                    {
                        var productItem = i.ProductItemId != Guid.Empty ?
                            product.ProductItems.Single(x => x.ProductItemId == i.ProductItemId) : new ProductItem(i.Name, i.Price);

                        if (i.ProductItemId != Guid.Empty)
                        {
                            productItem.UpdateName(i.Name);
                            productItem.UpdatePrice(i.Price);
                        }
                        else
                            product.AddProductItem(productItem);
                    }

                    if (p.ProductId != Guid.Empty)
                    {
                        product.UpdateName(p.Name);
                        product.UpdateDescription(p.Description);
                    }
                    else
                        productCategory.AddProduct(product);
                }

                if (c.ProductCategoryId != Guid.Empty)
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