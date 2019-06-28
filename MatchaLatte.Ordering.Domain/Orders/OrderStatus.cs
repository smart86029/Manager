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
        /// 已完成。
        /// </summary>
        Completed = 1,

        /// <summary>
        /// 已取消。
        /// </summary>
        Cancelled = 2,
    }
}