using System;
using System.Collections.Generic;
using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Catalog.Domain.Products
{
    /// <summary>
    /// 商品。
    /// </summary>
    public class Product : AggregateRoot
    {
        private List<ProductItem> productItems = new List<ProductItem>();

        /// <summary>
        /// 初始化 <see cref="Product"/> 類別的新執行個體。
        /// </summary>
        private Product()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Product"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        public Product(string name, string description)
        {
            Name = name.Trim();
            Description = description?.Trim();
        }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; private set; }

        /// <summary>
        /// 取得次序。
        /// </summary>
        /// <value>次序。</value>
        public int Sequence { get; private set; }

        /// <summary>
        /// 取得商品分類 ID。
        /// </summary>
        /// <value>商品分類 ID。</value>
        public Guid ProductCategoryId { get; private set; }

        /// <summary>
        /// 取得商品分類。
        /// </summary>
        /// <value>商品分類。</value>
        public ProductCategory ProductCategory { get; private set; }

        /// <summary>
        /// 取得商品項目的集合。
        /// </summary>
        /// <value>商品項目的集合。</value>
        public IReadOnlyCollection<ProductItem> ProductItems => productItems;

        ///// <summary>
        ///// 取得商品配件的集合。
        ///// </summary>
        ///// <value>商品配件的集合。</value>
        //public ICollection<ProductAccessory> ProductAccessories { get; private set; } = new List<ProductAccessory>();

        ///// <summary>
        ///// 取得商品選項的集合。
        ///// </summary>
        ///// <value>商品選項的集合。</value>
        //public ICollection<ProductOption> ProductOptions { get; private set; } = new List<ProductOption>();

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            Name = name.Trim();
        }

        /// <summary>
        /// 更新描述。
        /// </summary>
        /// <param name="description">描述。</param>
        public void UpdateDescription(string description)
        {
            Description = description?.Trim();
        }

        /// <summary>
        /// 加入商品項目。
        /// </summary>
        /// <param name="productItem">商品項目。</param>
        public void AddProductItem(ProductItem productItem)
        {
            productItems.Add(productItem);
        }

        /// <summary>
        /// 移除商品項目。
        /// </summary>
        /// <param name="productItem">商品項目。</param>
        public void RemoveProductItem(ProductItem productItem)
        {
            productItems.Remove(productItem);
        }
    }
}