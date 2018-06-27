using System.Collections.Generic;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 商品。
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; set; }

        /// <summary>
        /// 取得或設定商品分類 ID。
        /// </summary>
        /// <value>商品分類 ID。</value>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 取得或設定商品分類。
        /// </summary>
        /// <value>商品分類。</value>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// 取得或設定商品項目的集合。
        /// </summary>
        /// <value>商品項目的集合。</value>
        public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();

        /// <summary>
        /// 取得或設定商品配件的集合。
        /// </summary>
        /// <value>商品配件的集合。</value>
        public ICollection<ProductAccessory> ProductAccessories { get; set; } = new List<ProductAccessory>();

        /// <summary>
        /// 取得或設定商品選項的集合。
        /// </summary>
        /// <value>商品選項的集合。</value>
        public ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}