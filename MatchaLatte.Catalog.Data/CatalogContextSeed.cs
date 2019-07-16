using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Catalog.Domain.Products;
using MatchaLatte.Catalog.Domain.Stores;

namespace MatchaLatte.Catalog.Data
{
    public class CatalogContextSeed
    {
        private readonly CatalogContext context;

        public CatalogContextSeed(CatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SeedAsync()
        {
            try
            {
                if (!context.Set<Store>().Any())
                {
                    var stores = GetStores();

                    context.Set<Store>().AddRange(stores);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        private IEnumerable<Store> GetStores()
        {
            var store = new Store("茶湯會", string.Empty, new Picture(string.Empty), new Phone("26582882"), new Address("台北市", "內湖區", "江南街117號"), string.Empty, Guid.Empty);
            var category = new ProductCategory("排行榜", false);
            category.AddProduct(new Product("觀音拿鐵", string.Empty));
            store.AddProductCategory(category);

            var result = new Store[]
            {
                store
            };

            return result;
        }
    }
}