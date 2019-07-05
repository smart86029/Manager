namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單狀態。
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 已建立。
        /// </summary>
        Created = 0,

        /// <summary>
        /// 買家已確認。
        /// </summary>
        BuyerConfirmed = 1,

        /// <summary>
        /// 商品已確認。
        /// </summary>
        ProductConfirmed = 2,

        /// <summary>
        /// 已完成。
        /// </summary>
        Completed = 3,

        /// <summary>
        /// 已取消。
        /// </summary>
        Cancelled = 4,
    }
}