using System.Collections.Generic;

namespace Manager.Domain.Models.GroupBuying
{
    /// <summary>
    /// 商品。
    /// </summary>
    public class Product : IEntity
    {


        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductId { get; private set; }

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
        /// 取得商品分類 ID。
        /// </summary>
        /// <value>商品分類 ID。</value>
        public int ProductCategoryId { get; private set; }

        /// <summary>
        /// 取得商品分類。
        /// </summary>
        /// <value>商品分類。</value>
        public ProductCategory ProductCategory { get; private set; }

        /// <summary>
        /// 取得商品項目的集合。
        /// </summary>
        /// <value>商品項目的集合。</value>
        public ICollection<ProductItem> ProductItems { get; private set; } = new List<ProductItem>();

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
    }
}