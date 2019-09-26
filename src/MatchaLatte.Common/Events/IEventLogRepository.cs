namespace MatchaLatte.Common.Events
{
    /// <summary>
    /// 事件日誌存放庫。
    /// </summary>
    public interface IEventLogRepository
    {
        /// <summary>
        /// 加入事件日誌。
        /// </summary>
        /// <param name="eventLog">事件日誌。</param>
        void Add(EventLog eventLog);
    }
}