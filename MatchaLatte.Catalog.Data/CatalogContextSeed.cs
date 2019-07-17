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
            var store = new Store("茶湯會", string.Empty, new Picture("茶湯會.png"), new Phone("26582882"), new Address("台北市", "內湖區", "江南街117號"), string.Empty, Guid.Empty);
            var category = new ProductCategory("排行榜");
            var product = new Product("觀音拿鐵", null);
            product.AddProductItem("冰", 59);
            product.AddProductItem("熱", 59);
            category.AddProduct(product);
            product = new Product("珍珠紅豆拿鐵", null);
            product.AddProductItem("冰", 69);
            product.AddProductItem("熱", 69);
            category.AddProduct(product);
            product = new Product("翡翠檸檬", null);
            product.AddProductItem("冰", 55);
            category.AddProduct(product);
            product = new Product("珍珠奶茶", null);
            product.AddProductItem("冰", 49);
            product.AddProductItem("熱", 49);
            category.AddProduct(product);
            product = new Product("新鮮水果茶", null);
            product.AddProductItem("冰", 59);
            product.AddProductItem("熱", 59);
            category.AddProduct(product);
            store.AddProductCategory(category);

            category = new ProductCategory("原味茶");
            product = new Product("蔗香紅茶", null);
            product.AddProductItem("冰", 25);
            product.AddProductItem("熱", 25);
            category.AddProduct(product);
            product = new Product("茉香綠茶", null);
            product.AddProductItem("冰", 30);
            category.AddProduct(product);
            product = new Product("包種清茶", null);
            product.AddProductItem("冰", 35);
            category.AddProduct(product);
            product = new Product("特級翡翠綠", null);
            product.AddProductItem("冰", 35);
            product.AddProductItem("熱", 35);
            category.AddProduct(product);
            product = new Product("碳燒鐵觀音", null);
            product.AddProductItem("冰", 35);
            product.AddProductItem("熱", 35);
            category.AddProduct(product);
            product = new Product("珍珠紅茶", null);
            product.AddProductItem("冰", 35);
            product.AddProductItem("熱", 35);
            category.AddProduct(product);
            product = new Product("珍珠綠茶", null);
            product.AddProductItem("冰", 39);
            product.AddProductItem("熱", 39);
            category.AddProduct(product);
            store.AddProductCategory(category);

            var result = new Store[]
            {
                store
            };

            return result;
        }
    }
}