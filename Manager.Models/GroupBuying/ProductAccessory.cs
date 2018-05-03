using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品配件。
    /// </summary>
    [Table("ProductAccessory", Schema = "GroupBuying")]
    public class ProductAccessory
    {
        /// <summary>
        /// 取得或設定商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public int ProductAccessoryId { get; set; }

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
        /// 取得或設定商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public int ProductId { get; set; }
    }
}