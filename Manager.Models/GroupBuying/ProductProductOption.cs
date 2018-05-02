using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品商品選項。
    /// </summary>
    [Table("ProductProductOption", Schema = "GroupBuying")]
    public class ProductProductOption
    {
        /// <summary>
        /// 取得或設定商品 ID。
        /// </summary>
        /// <value>商品 ID。</value>
        public int ProductId { get; set; }

        /// <summary>
        /// 取得或設定商品選項 ID。
        /// </summary>
        /// <value>商品選項 ID。</value>
        public int ProductOptionId { get; set; }

        /// <summary>
        /// 取得或設定商品。
        /// </summary>
        /// <value>商品。</value>
        public Product Product { get; set; }

        /// <summary>
        /// 取得或設定商品選項。
        /// </summary>
        /// <value>商品選項。</value>
        public ProductOption ProductOption { get; set; }
    }
}