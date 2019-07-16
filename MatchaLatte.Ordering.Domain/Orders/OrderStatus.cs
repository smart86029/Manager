namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單狀態。
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 建立中。
        /// </summary>
        Creating = 0,

        /// <summary>
        /// 已建立。
        /// </summary>
        Created = 1,

        /// <summary>
        /// 已確認。
        /// </summary>
        Confirmed = 2,

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