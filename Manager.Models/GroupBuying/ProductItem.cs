namespace Manager.Models.GroupBuying
{
    /// <summary>
    /// 商品項目。
    /// </summary>
    public class ProductItem
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int ProductItemId { get; set; }

        /// <summary>
        /// 取得或設定名稱。
        /// </summary>
        /// <value>名稱。</value>
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