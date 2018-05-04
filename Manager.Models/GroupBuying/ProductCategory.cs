using System.Collections.Generic;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品分類。
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public int StoreId { get; set; }

        /// <summary>
        /// 取得或設定店家。
        /// </summary>
        /// <value>店家。</value>
        public Store Store { get; set; }

        /// <summary>
        /// 取得或設定商品的集合。
        /// </summary>
        /// <value>商品的集合。</value>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}