using System;
using System.Collections.Generic;
using MatchaLatte.Catalog.Domain.Products;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Stores
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
        internal ProductCategory(string name)
        {
            Name = name?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得次序。
        /// </summary>
        /// <value>次序。</value>
        public int Sequence { get; private set; }

        /// <summary>
        /// 取得店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public Guid StoreId { get; private set; }

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
            Name = name.Trim();
        }

        /// <summary>
        /// 加入商品。
        /// </summary>
        /// <param name="product">商品。</param>
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        /// <summary>
        /// 移除商品。
        /// </summary>
        /// <param name="product">商品。</param>
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
    }
}