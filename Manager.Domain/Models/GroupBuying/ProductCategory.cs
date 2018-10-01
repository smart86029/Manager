using System.Collections.Generic;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 商品分類。
    /// </summary>
    public class ProductCategory : Entity
    {
        private List<Product> products = new List<Product>();

        /// <summary>
        /// 初始化 <see cref="ProductCategory"/> 類別的新執行個體。
        /// </summary>
        private ProductCategory()
        {
        }

        /// <summary>
        /// 初始化 <see cref="ProductCategory"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        public ProductCategory(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductCategoryId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public int StoreId { get; private set; }

        /// <summary>
        /// 取得店家。
        /// </summary>
        /// <value>店家。</value>
        public Store Store { get; private set; }

        /// <summary>
        /// 取得商品的集合。
        /// </summary>
        /// <value>商品的集合。</value>
        public IReadOnlyCollection<Product> Products => products;

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 加入商品項目。
        /// </summary>
        /// <param name="product">商品。</param>
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}