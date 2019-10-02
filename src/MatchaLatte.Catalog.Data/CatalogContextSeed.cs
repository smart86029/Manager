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
            var result = new List<Store>();
            var store = new Store("茶湯會", "內湖江南店", new Picture("茶湯會.png"), new Phone("26582882"), new Address("臺北市", "內湖區", "江南街117號"), "測試資料", Guid.Empty);
            store.AddProductCategory("排行榜");
            var category = store.ProductCategories.Last();
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

            store.AddProductCategory("原味茶");
            category = store.ProductCategories.Last();
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

            store.AddProductCategory("調味茶");
            category = store.ProductCategories.Last();
            product = new Product("豆漿紅茶", null);
            product.AddProductItem("冰", 39);
            product.AddProductItem("熱", 39);
            category.AddProduct(product);
            product = new Product("青梅凍飲", null);
            product.AddProductItem("冰", 40);
            product.AddProductItem("熱", 40);
            category.AddProduct(product);
            product = new Product("冬瓜鐵觀音", null);
            product.AddProductItem("冰", 45);
            product.AddProductItem("熱", 45);
            category.AddProduct(product);
            product = new Product("蜜香清茶", null);
            product.AddProductItem("冰", 45);
            category.AddProduct(product);
            product = new Product("百香綠茶", null);
            product.AddProductItem("冰", 50);
            category.AddProduct(product);
            product = new Product("蜂蜜綠茶", null);
            product.AddProductItem("冰", 50);
            category.AddProduct(product);
            product = new Product("梅好冬瓜", "9月上市");
            product.AddProductItem("冰", 55);
            category.AddProduct(product);
            product = new Product("水蜜桃纖果綠", null);
            product.AddProductItem("冰", 69);
            category.AddProduct(product);

            store.AddProductCategory("奶香茶");
            category = store.ProductCategories.Last();
            product = new Product("豆漿奶茶", null);
            product.AddProductItem("冰", 45);
            product.AddProductItem("熱", 45);
            category.AddProduct(product);
            product = new Product("蔗香奶茶", null);
            product.AddProductItem("冰", 45);
            product.AddProductItem("熱", 45);
            category.AddProduct(product);
            product = new Product("茉香奶茶", null);
            product.AddProductItem("冰", 45);
            product.AddProductItem("熱", 45);
            category.AddProduct(product);
            product = new Product("鐵觀音奶茶", null);
            product.AddProductItem("冰", 45);
            product.AddProductItem("熱", 45);
            category.AddProduct(product);
            product = new Product("珍珠奶綠", null);
            product.AddProductItem("冰", 49);
            product.AddProductItem("熱", 49);
            category.AddProduct(product);

            store.AddProductCategory("鮮調茶");
            category = store.ProductCategories.Last();
            product = new Product("檸檬紅茶", null);
            product.AddProductItem("冰", 50);
            product.AddProductItem("熱", 50);
            category.AddProduct(product);
            product = new Product("冬瓜檸檬", null);
            product.AddProductItem("冰", 55);
            category.AddProduct(product);
            product = new Product("檸檬蜜茶", null);
            product.AddProductItem("冰", 55);
            category.AddProduct(product);

            store.AddProductCategory("拿鐵茶");
            category = store.ProductCategories.Last();
            product = new Product("冬瓜拿鐵", null);
            product.AddProductItem("冰", 49);
            product.AddProductItem("熱", 49);
            category.AddProduct(product);
            product = new Product("紅茶拿鐵", null);
            product.AddProductItem("冰", 59);
            product.AddProductItem("熱", 59);
            category.AddProduct(product);
            product = new Product("翡翠拿鐵", null);
            product.AddProductItem("冰", 59);
            product.AddProductItem("熱", 59);
            category.AddProduct(product);
            product = new Product("紅豆拿鐵", null);
            product.AddProductItem("冰", 60);
            product.AddProductItem("熱", 60);
            category.AddProduct(product);
            product = new Product("紅茶珍珠拿鐵", null);
            product.AddProductItem("冰", 65);
            product.AddProductItem("熱", 65);
            category.AddProduct(product);
            product = new Product("翡翠珍珠拿鐵", null);
            product.AddProductItem("冰", 65);
            product.AddProductItem("熱", 65);
            category.AddProduct(product);
            product = new Product("觀音珍珠拿鐵", null);
            product.AddProductItem("冰", 65);
            product.AddProductItem("熱", 65);
            category.AddProduct(product);

            store.AddProductCategory("季節限定");
            category = store.ProductCategories.Last();
            product = new Product("黃金輕焙烏龍", null);
            product.AddProductItem("冰", 30);
            category.AddProduct(product);
            product = new Product("蜜香烏龍", null);
            product.AddProductItem("冰", 45);
            category.AddProduct(product);
            product = new Product("布丁奶茶", null);
            product.AddProductItem("冰", 49);
            category.AddProduct(product);
            product = new Product("養樂多綠茶", null);
            product.AddProductItem("冰", 50);
            category.AddProduct(product);
            product = new Product("檸檬蘆薈蜜", null);
            product.AddProductItem("冰", 60);
            category.AddProduct(product);
            product = new Product("蔓越莓冰醋", null);
            product.AddProductItem("冰", 60);
            category.AddProduct(product);
            product = new Product("桑葚凍飲茶", null);
            product.AddProductItem("冰", 60);
            category.AddProduct(product);
            product = new Product("愛文芒果綠", null);
            product.AddProductItem("冰", 65);
            category.AddProduct(product);
            product = new Product("愛文芒果拿鐵", null);
            product.AddProductItem("冰", 75);
            category.AddProduct(product);

            store.AddProductCategory("功夫系列");
            category = store.ProductCategories.Last();
            product = new Product("功夫紅茶", null);
            product.AddProductItem("冰", 35);
            product.AddProductItem("熱", 35);
            category.AddProduct(product);
            product = new Product("珍珠冬瓜觀音", null);
            product.AddProductItem("冰", 49);
            product.AddProductItem("熱", 49);
            category.AddProduct(product);
            product = new Product("鮮桔檸檬", null);
            product.AddProductItem("冰", 55);
            product.AddProductItem("熱", 55);
            category.AddProduct(product);
            product = new Product("功夫茶拿鐵", null);
            product.AddProductItem("冰", 60);
            product.AddProductItem("熱", 60);
            category.AddProduct(product);
            product = new Product("東方美人", null);
            product.AddProductItem("冰", 60);
            product.AddProductItem("熱", 60);
            category.AddProduct(product);
            product = new Product("蘋果百香多多", null);
            product.AddProductItem("冰", 65);
            product.AddProductItem("熱", 65);
            category.AddProduct(product);

            result.Add(store);

            store = new Store("約翰紅茶公司", "內湖江南店", new Picture("約翰紅茶公司.jpg"), new Phone("26594567"), new Address("臺北市", "內湖區", "江南街98號"), "測試資料", Guid.Empty);
            store.AddProductCategory("紅茶經典");
            category = store.ProductCategories.Last();
            product = new Product("康提紅茶", "斯里蘭卡");
            product.AddProductItem("冰M", 25);
            product.AddProductItem("冰L", 30);
            category.AddProduct(product);
            product = new Product("雨果紅茶", "斯里蘭卡");
            product.AddProductItem("冰M", 30);
            product.AddProductItem("冰L", 35);
            product.AddProductItem("熱M", 35);
            category.AddProduct(product);
            product = new Product("曼非紅茶", "肯亞");
            product.AddProductItem("冰M", 30);
            product.AddProductItem("冰L", 35);
            product.AddProductItem("熱M", 35);
            category.AddProduct(product);
            product = new Product("茶中香檳", "斯里蘭卡");
            product.AddProductItem("冰M", 35);
            product.AddProductItem("冰L", 40);
            product.AddProductItem("熱M", 40);
            category.AddProduct(product);
            product = new Product("錫金紅茶", "尼泊爾-夏摘");
            product.AddProductItem("冰M", 45);
            category.AddProduct(product);
            product = new Product("夢幻紅茶", "台灣");
            product.AddProductItem("冰M", 50);
            category.AddProduct(product);

            store.AddProductCategory("紅茶那堤");
            category = store.ProductCategories.Last();
            product = new Product("珍珠那堤", "斯里蘭卡");
            product.AddProductItem("冰L", 60);
            product.AddProductItem("熱M", 60);
            category.AddProduct(product);
            product = new Product("雨果那堤", "斯里蘭卡");
            product.AddProductItem("冰M", 50);
            product.AddProductItem("冰L", 55);
            product.AddProductItem("熱M", 55);
            category.AddProduct(product);
            product = new Product("曼非那堤", "肯亞");
            product.AddProductItem("冰M", 50);
            product.AddProductItem("冰L", 55);
            product.AddProductItem("熱M", 55);
            category.AddProduct(product);
            product = new Product("烏瓦那堤", "斯里蘭卡");
            product.AddProductItem("冰M", 55);
            product.AddProductItem("冰L", 60);
            product.AddProductItem("熱M", 60);
            category.AddProduct(product);
            product = new Product("抹茶那堤", "台灣");
            product.AddProductItem("冰M", 60);
            product.AddProductItem("熱M", 60);
            category.AddProduct(product);
            product = new Product("煮濃那堤", "斯里蘭卡");
            product.AddProductItem("冰M", 60);
            category.AddProduct(product);

            store.AddProductCategory("紅茶調飲");
            category = store.ProductCategories.Last();
            product = new Product("生乳紅茶", "斯里蘭卡");
            product.AddProductItem("冰M", 50);
            category.AddProduct(product);
            product = new Product("生乳抹茶", "台灣");
            product.AddProductItem("冰M", 55);
            category.AddProduct(product);
            product = new Product("糖檸紅茶", "斯里蘭卡");
            product.AddProductItem("冰L", 55);
            category.AddProduct(product);
            product = new Product("玉釀紅茶", "斯里蘭卡");
            product.AddProductItem("冰L", 55);
            category.AddProduct(product);
            product = new Product("冰淇淋紅茶", "斯里蘭卡");
            product.AddProductItem("冰L", 60);
            category.AddProduct(product);

            result.Add(store);

            return result;
        }
    }
}