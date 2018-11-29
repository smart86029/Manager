using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Ordering.Domain.Products;

namespace MatchaLatte.Ordering.Domain.Stores
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
        /// <param name="isDefault">是否預設。</param>
        public ProductCategory(string name, bool isDefault) : this(GuidUtility.NewGuid(), name, isDefault)
        {
        }

        /// <summary>
        /// 初始化 <see cref="ProductCategory"/> 類別的新執行個體。
        /// </summary>
        /// <param name="productCategoryId">商品分類 ID。</param>
        /// <param name="name">名稱。</param>
        /// <param name="isDefault">是否預設。</param>
        public ProductCategory(Guid productCategoryId, string name, bool isDefault)
        {
            ProductCategoryId = productCategoryId;
            Name = name.Trim();
            IsDefault = isDefault;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid ProductCategoryId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否預設。
        /// </summary>
        /// <value>如果預設則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsDefault { get; private set; }

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
        /// 加入商品項目。
        /// </summary>
        /// <param name="product">商品。</param>
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}