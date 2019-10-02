namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 發布狀態。
    /// </summary>
    public enum PublishState
    {
        /// <summary>
        /// 等待中。
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// 進行中。
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// 已完成。
        /// </summary>
        Completed = 2,

        /// <summary>
        /// 失敗。
        /// </summary>
        Failed = 3,
    }
}