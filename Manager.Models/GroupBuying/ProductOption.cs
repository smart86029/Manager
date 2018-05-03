using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品選項。
    /// </summary>
    [Table("ProductOption", Schema = "GroupBuying")]
    public class ProductOption
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductOptionId { get; set; }

        /// <summary>
        /// 取得或設定商品選項類型。
        /// </summary>
        /// <value>商品選項類型。</value>
        public ProductOptionType ProductOptionType { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
        [Required]
        [StringLength(32, ErrorMessage = "長度不可超過 32")]
        public string Name { get; set; }

        /// <summary>
        /// 取得或設定商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public int ProductId { get; set; }
    }
}