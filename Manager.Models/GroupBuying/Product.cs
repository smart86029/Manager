using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品。
    /// </summary>
    [Table("Product", Schema = "GroupBuying")]
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
        [Required]
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal Price { get; set; }

        /// <summary>
        /// 取得或設定店家 ID。
        /// </summary>
        /// <value>店家 ID。</value>
        public int StoreId { get; set; }

        /// <summary>
        /// 取得或設定店家。
        /// </summary>
        /// <value>店家。</value>
        public virtual Store Store { get; set; }
    }
}