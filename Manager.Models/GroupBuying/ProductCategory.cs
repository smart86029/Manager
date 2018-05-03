using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品分類。
    /// </summary>
    [Table("ProductCategory", Schema = "GroupBuying")]
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
        [Required]
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
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